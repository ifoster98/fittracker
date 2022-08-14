using LanguageExt;
using Ianf.Fittracker.Domain;
using Ianf.Fittracker.Interfaces;
using Newtonsoft.Json;

namespace Ianf.Fittracker.Repositories
{
    public class WorkoutFileRepository : IWorkoutRepository
    {
        private string dataDirectory = "data";
        private string dataFile = "fittrack.json";

        public void AddWorkout(Workout workout)
        {
            var database = GetDatabase();
;            //database.Workouts.Add(workout);
            //SaveDatabase(database);
        }

        public void SetProposedWorkout(Workout workout) 
        {

        }

        public Option<Workout> GetNextWorkout()
        {
            var database = GetDatabase();
            return database.ProposedWorkout;
        }

        public Database GetDatabase() 
        {
            var storage = $"{dataDirectory}/{dataFile}";
            if(!File.Exists(storage)) return new Database();
            return JsonConvert.DeserializeObject<Database>(File.ReadAllText(storage));
        }

        private void SaveDatabase(Database database) {
            if(!Directory.Exists(dataDirectory)) Directory.CreateDirectory(dataDirectory);
            var storage = $"{dataDirectory}/{dataFile}";
            File.WriteAllText(storage, JsonConvert.SerializeObject(database));
        }
    }
}