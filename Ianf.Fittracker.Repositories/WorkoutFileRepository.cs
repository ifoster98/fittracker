using LanguageExt;
using Ianf.Fittracker.Domain;
using Ianf.Fittracker.Interfaces;
using Newtonsoft.Json;

namespace Ianf.Fittracker.Repositories;

public class WorkoutFileRepository : IWorkoutRepository
{
    private string dataDirectory = "/Users/ianfoster/dev/fittracker/data/";
    private string dataFile = "fittrack.json";

    public void AddWorkout(Workout workout)
    {
        var database = GetDatabase();
        workout.Exercises.ForEach(exercise => GetUpdatedExerciseList(database, exercise));
        SaveDatabase(database);
    }

    private void GetUpdatedExerciseList(Database database, Exercise ex)
    {
        if(database.ExerciseLookup.ContainsKey(ex.ExerciseType)) {
            database.ExerciseLookup[ex.ExerciseType].Add(ex);
        } else {
            database.ExerciseLookup[ex.ExerciseType] = new List<Exercise> { ex };
        }
    }


    public void SetProposedWorkout(Workout workout) 
    {
        var database = GetDatabase();
        SaveDatabase(database = database with {ProposedWorkout = workout});
    }

    public Option<Workout> GetNextWorkout() => GetDatabase().ProposedWorkout;

    public Database GetDatabase() 
    {
        var storage = $"{dataDirectory}/{dataFile}";
        if(!File.Exists(storage)) return new Database();
        return JsonConvert.DeserializeObject<Database>(File.ReadAllText(storage));
    }

    private void SaveDatabase(Database database) {
        if(!Directory.Exists(dataDirectory)) Directory.CreateDirectory(dataDirectory);
        var storage = $"{dataDirectory}/{dataFile}";
        var foo = JsonConvert.SerializeObject(database);
        File.WriteAllText(storage, JsonConvert.SerializeObject(database));
    }
}