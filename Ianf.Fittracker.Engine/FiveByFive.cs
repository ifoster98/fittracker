using Ianf.Fittracker.Domain;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Engine
{
    public static class FiveByFive {
        private static Dictionary<WorkoutSubType, List<ExerciseType>> WorkoutSubTypes = new Dictionary<WorkoutSubType, List<ExerciseType>>{
            { WorkoutSubType.WorkoutA, new List<ExerciseType> {ExerciseType.Squat, ExerciseType.BenchPress, ExerciseType.BentOverRows} },
            { WorkoutSubType.WorkoutB, new List<ExerciseType> {ExerciseType.Squat, ExerciseType.OverheadPress, ExerciseType.Deadlift} }
        };

        private static Weight Inc(ExerciseType et, Weight w) => 
            et == ExerciseType.Deadlift 
                ? new Weight(w.GetValue() + 5) 
                : new Weight(w.GetValue() + 2.5);

        private static Weight Dec(ExerciseType et, Weight w) => 
            et == ExerciseType.Deadlift 
                ? BottomLimit(new Weight(w.GetValue() - 5))
                : BottomLimit(new Weight(w.GetValue() - 2.5));

        private static Weight BottomLimit(Weight w) => w.GetValue() < 0 ? new Weight(0) : w;

        private static IEnumerable<Exercise> TakeLast(IEnumerable<Exercise> exs, int amount) => 
            exs.Any() 
                ? Enumerable.Reverse(Enumerable.Reverse(exs).Take(amount))
                : exs;

        private static Weight GetWeight(Exercise ex) => 
            ex.ExerciseSet.Any()
                ? ex.ExerciseSet.First().Weight
                : new Weight(0);

        private static Outcome GetOutcomeFromReps(List<Reps> reps) =>
            reps.Where(r => r.Outcome == Outcome.Failure).Any()
                ? Outcome.Failure
                : Outcome.Success;

        private static Outcome GetOutcome(Exercise ex) =>
            ex.ExerciseSet.Any()
                ? GetOutcomeFromReps(ex.ExerciseSet)
                : Outcome.Failure;

        private static Weight CalculateNextWeight(ExerciseType et, Weight w, (Outcome, Outcome) history) => history switch
        {
            (Outcome, Outcome) t when t.Item1 == Outcome.Failure && t.Item2 == Outcome.Failure => Dec(et, w),
            (Outcome, Outcome) t when t.Item2 == Outcome.Failure => w,
            _ => Inc(et, w)
        };

        private static Weight GetLastWeight(IEnumerable<Exercise> exs) => 
            exs.Any()
                ? GetWeight(exs.Last())
                : new Weight(0.0);

        private static (Outcome, Outcome) GetLastTwoOutcomes(IEnumerable<Exercise> exs) =>
            exs.Any()
                ? (
                    GetOutcome(TakeLast(exs, 2).First()), 
                    GetOutcome(TakeLast(exs, 1).First())
                  )
                : (Outcome.Failure, Outcome.Failure);

        private static Weight GetNextWeight(ExerciseType et, Dictionary<ExerciseType, List<Exercise>> exerciseList) =>
            CalculateNextWeight(
                et, 
                GetLastWeight(exerciseList[et]), 
                GetLastTwoOutcomes(exerciseList[et])
            );

        private static List<Reps> GenerateRepsForNextWorkout(Weight w) => 
            Enumerable
                .Repeat(new Reps{Weight = w, RepCount = new RepCount(5), Outcome = Outcome.Failure}, 5)
                    .ToList();

        private static Exercise GetNextExercise(ExerciseType et, Dictionary<ExerciseType, List<Exercise>> exerciseList) {
            var nextWeight = GetNextWeight(et, exerciseList);
            var reps = GenerateRepsForNextWorkout(nextWeight);
            return new Exercise{ExerciseType = et, ExerciseTime = None, ExerciseSet = reps};
        }

        private static List<Exercise> GenerateExercisesForNextWorkout(WorkoutSubType wst, 
            Dictionary<ExerciseType, List<Exercise>> exerciseList, 
            List<ExerciseType> exerciseTypes) =>
            exerciseTypes != null && exerciseTypes.Any()
                ? exerciseTypes.Select(et => GetNextExercise(et, exerciseList)).ToList()
                : new List<Exercise>();

        private static WorkoutSubType GetNextWorkoutSubType(WorkoutSubType w) => w == WorkoutSubType.WorkoutA ? WorkoutSubType.WorkoutB : WorkoutSubType.WorkoutA;

        public static Workout GenerateNextWorkout(WorkoutSubType wst, Dictionary<ExerciseType, List<Exercise>> exerciseList) =>
            new Workout {
                WorkoutType = WorkoutType.FiveByFive,
                WorkoutSubType = GetNextWorkoutSubType(wst),
                WorkoutTime = None,
                Exercises = GenerateExercisesForNextWorkout(GetNextWorkoutSubType(wst), exerciseList, WorkoutSubTypes[wst])
            };
    }
}