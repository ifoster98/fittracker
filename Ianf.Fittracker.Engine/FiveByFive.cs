using Ianf.Fittracker.Domain;
using Ianf.Fittracker.Interfaces;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Engine;

public class FiveByFive : IEngine {
    private Dictionary<WorkoutSubType, List<ExerciseType>> WorkoutSubTypes = new Dictionary<WorkoutSubType, List<ExerciseType>>{
        { WorkoutSubType.WorkoutA, new List<ExerciseType> {ExerciseType.Squat, ExerciseType.BenchPress, ExerciseType.BentOverRows} },
        { WorkoutSubType.WorkoutB, new List<ExerciseType> {ExerciseType.Squat, ExerciseType.OverheadPress, ExerciseType.Deadlift} }
    };

    private Weight Inc(ExerciseType et, Weight w) => 
        et == ExerciseType.Deadlift 
            ? new Weight(w.GetValue() + 5) 
            : new Weight(w.GetValue() + 2.5);

    private Weight Dec(ExerciseType et, Weight w) => 
        et == ExerciseType.Deadlift 
            ? BottomLimit(new Weight(w.GetValue() - 5))
            : BottomLimit(new Weight(w.GetValue() - 2.5));

    private Weight BottomLimit(Weight w) => w.GetValue() < 0 ? new Weight(0) : w;

    private IEnumerable<Exercise> TakeLast(IEnumerable<Exercise> exs, int amount) => 
        exs.Any() 
            ? Enumerable.Reverse(Enumerable.Reverse(exs).Take(amount))
            : exs;

    private Weight GetWeight(Exercise ex) => 
        ex.ExerciseSet.Any()
            ? ex.ExerciseSet.First().Weight
            : new Weight(0);

    private Outcome GetOutcomeFromReps(List<Reps> reps) =>
        reps.Where(r => r.Outcome == Outcome.Failure).Any()
            ? Outcome.Failure
            : Outcome.Success;

    private Outcome GetOutcome(Exercise ex) =>
        ex.ExerciseSet.Any()
            ? GetOutcomeFromReps(ex.ExerciseSet)
            : Outcome.Failure;

    private Weight CalculateNextWeight(ExerciseType et, Weight w, (Outcome, Outcome) history) => history switch
    {
        (Outcome, Outcome) t when t.Item1 == Outcome.Failure && t.Item2 == Outcome.Failure => Dec(et, w),
        (Outcome, Outcome) t when t.Item2 == Outcome.Failure => w,
        _ => Inc(et, w)
    };

    private Weight GetLastWeight(IEnumerable<Exercise> exs) => 
        exs != null && exs.Any()
            ? GetWeight(exs.Last())
            : new Weight(0.0);

    private (Outcome, Outcome) GetLastTwoOutcomes(IEnumerable<Exercise> exs) =>
        exs != null && exs.Any()
            ? (
                GetOutcome(TakeLast(exs, 2).First()), 
                GetOutcome(TakeLast(exs, 1).First())
              )
            : (Outcome.Failure, Outcome.Failure);

    private Weight GetNextWeight(ExerciseType et, Dictionary<ExerciseType, List<Exercise>> exerciseList) =>
        exerciseList != null && exerciseList.ContainsKey(et)
            ? CalculateNextWeight(et, GetLastWeight(exerciseList[et]), GetLastTwoOutcomes(exerciseList[et]))
            : new Weight(0);

    private List<Reps> GenerateRepsForNextWorkout(Weight w) => 
        Enumerable
            .Repeat(new Reps{Weight = w, RepCount = new RepCount(5), Outcome = Outcome.Failure}, 5)
                .ToList();

    private Exercise GetNextExercise(ExerciseType et, Dictionary<ExerciseType, List<Exercise>> exerciseList) {
        var nextWeight = GetNextWeight(et, exerciseList);
        var reps = GenerateRepsForNextWorkout(nextWeight);
        return new Exercise{ExerciseType = et, ExerciseTime = None, ExerciseSet = reps};
    }

    private List<Exercise> GenerateExercisesForNextWorkout(WorkoutSubType wst, 
        Dictionary<ExerciseType, List<Exercise>> exerciseList, 
        List<ExerciseType> exerciseTypes) =>
        exerciseTypes != null && exerciseTypes.Any()
            ? exerciseTypes.Select(et => GetNextExercise(et, exerciseList)).ToList()
            : new List<Exercise>();

    private WorkoutSubType GetNextWorkoutSubType(WorkoutSubType w) => w == WorkoutSubType.WorkoutA ? WorkoutSubType.WorkoutB : WorkoutSubType.WorkoutA;

    public Workout GenerateNextWorkout(WorkoutSubType wst, Database database){
        var newWorkoutSubType = GetNextWorkoutSubType(wst);
        return new Workout {
            WorkoutType = WorkoutType.FiveByFive,
            WorkoutSubType = newWorkoutSubType,
            WorkoutTime = None,
            Exercises = GenerateExercisesForNextWorkout(newWorkoutSubType, database.ExerciseLookup, WorkoutSubTypes[newWorkoutSubType])
        };
    }

    public Workout DefaultWorkout() =>
        new Workout {
            WorkoutType = WorkoutType.FiveByFive,
            WorkoutSubType = WorkoutSubType.WorkoutA,
            WorkoutTime = None,
            Exercises = GetDefaultExercises()
        };

    private List<Exercise> GetDefaultExercises() => 
        new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.Squat,
                ExerciseTime = new DateTime(2022, 08, 01),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.BenchPress,
                ExerciseTime = new DateTime(2022, 08, 01),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.BentOverRows,
                ExerciseTime = new DateTime(2022, 08, 01),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            }
        };
}
