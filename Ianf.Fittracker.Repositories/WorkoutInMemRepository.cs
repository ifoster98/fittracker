using Ianf.Fittracker.Interfaces;
using Ianf.Fittracker.Domain;
using LanguageExt;

namespace Ianf.Fittracker.Repositories;

public class WorkoutInMemRepository : IWorkoutRepository
{
    private Database database = new Database();

    private void GetUpdatedExerciseList(Exercise ex)
    {
        if(database.ExerciseLookup.ContainsKey(ex.ExerciseType)) {
            database.ExerciseLookup[ex.ExerciseType].Add(ex);
        } else {
            database.ExerciseLookup[ex.ExerciseType] = new List<Exercise> { ex };
        }
    }

    public Either<FittrackerError, Unit> AddWorkout(Workout workout)
    {
        workout.Exercises.ForEach(GetUpdatedExerciseList);
        return new Unit();
    }

    public Either<FittrackerError, Unit> SetProposedWorkout(Workout workout)
    {
        database = database with { ProposedWorkout = workout };
        return new Unit();
    }

    public Either<FittrackerError, Option<Workout>> GetNextWorkout() => database.ProposedWorkout;

    public Either<FittrackerError, Database> GetDatabase() => database;
}
