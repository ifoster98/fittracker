using Ianf.Fittracker.Interfaces;
using Ianf.Fittracker.Domain;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Service;

public class WorkoutService: IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IEngine _engine;

    public WorkoutService(IWorkoutRepository workoutRepository,
        IEngine engine) {
        _workoutRepository = workoutRepository;
        _engine = engine;
    }

    public void SaveWorkout(Workout workout) {
        workout = EnsureDatesAreSet(workout);
        _workoutRepository.AddWorkout(workout);
        SetupNextWorkout(workout);
    }

    private Workout EnsureDatesAreSet(Workout workout)
    {
        if(workout.WorkoutTime.IsNone) workout = workout with {WorkoutTime = DateTime.Now };
        workout = workout with { Exercises = workout.Exercises.Select(ex => UpdateDatesForExercises(ex)).ToList() };
        return workout;
    }

    private Exercise UpdateDatesForExercises(Exercise ex) {
        if(ex.ExerciseTime.IsNone) ex = ex with {ExerciseTime = DateTime.Now};
        return ex;
    } 

    private Either<FittrackerError, Unit> SetupNextWorkout(Workout workout)  =>
        _workoutRepository.GetDatabase().Bind((db) =>
        {
            var newWorkout = _engine.GenerateNextWorkout(workout.WorkoutSubType, db);
            return _workoutRepository.SetProposedWorkout(newWorkout);
        });

    public Workout GetNextWorkout() =>
        _workoutRepository.GetNextWorkout().Match(
            Left: (err) => _engine.DefaultWorkout(),
            Right: (optWorkout) => optWorkout.Match(
                Some: (s) => s,
                None: () => _engine.DefaultWorkout()
            ));
}