using LanguageExt;
using Ianf.Fittracker.Domain;
using Ianf.Fittracker.Interfaces;
using Newtonsoft.Json;

namespace Ianf.Fittracker.Repositories;

public class WorkoutFileRepository : IWorkoutRepository
{
    public string Storage { get; set; }

    public WorkoutFileRepository() {
        Storage = "/Users/ianfoster/dev/fittracker/data/fittrack.json";
    }

    public Either<FittrackerError, Unit> AddWorkout(Workout workout) =>
        GetDatabase().Bind((db) =>
        {
            workout.Exercises.ForEach(exercise => GetUpdatedExerciseList(db, exercise));
            return SaveDatabase(db);
        });

    private void GetUpdatedExerciseList(Database database, Exercise ex)
    {
        if (!database.ExerciseLookup.ContainsKey(ex.ExerciseType))
            database.ExerciseLookup[ex.ExerciseType] = new List<Exercise>();
        database.ExerciseLookup[ex.ExerciseType].Add(ex);
    }

    public Either<FittrackerError, Unit> SetProposedWorkout(Workout workout) =>
        GetDatabase().Bind((db) => { return SaveDatabase(db with { ProposedWorkout = workout}); });

    public Either<FittrackerError, Option<Workout>> GetNextWorkout() =>
        GetDatabase().Bind((db) => { return GetNextWorkoutInternal(db); });

    private Either<FittrackerError, Option<Workout>> GetNextWorkoutInternal(Database db) => db.ProposedWorkout;

    public Either<FittrackerError, Database> GetDatabase()
    {
        if (!File.Exists(Storage)) return new Database();
        try
        {
            return JsonConvert.DeserializeObject<Database>(File.ReadAllText(Storage));
        }
        catch (Exception ex)
        {
            return new FittrackerError($"Could not load database from {Storage}. {ex.Message}. {ex.StackTrace}.");
        }
    }

    private Either<FittrackerError, Unit> SaveDatabase(Database database)
    {
        try
        {
            if (!File.Exists(Storage)) File.Create(Storage);
            File.WriteAllText(Storage, JsonConvert.SerializeObject(database));
            return new Unit();
        }
        catch (Exception ex)
        {
            return new FittrackerError($"Unable to save database to ${Storage}. {ex.Message}. {ex.StackTrace}.");
        }
    }
}