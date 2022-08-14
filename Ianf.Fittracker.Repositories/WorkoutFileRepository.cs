using LanguageExt;
using static LanguageExt.Prelude;
using Ianf.Fittracker.Domain;
using Ianf.Fittracker.Interfaces;
using Newtonsoft.Json;

namespace Ianf.Fittracker.Repositories
{
    public class WorkoutFileRepository : IWorkoutRepository
    {
        private string dataDirectory = "data";
        private string dataFile = "fittrack.json";

        public Option<Workout> GetNextWorkout()
        {
            var context = GetDatabase();
            return context.ProposedWorkout;
        }

        public void AddWorkout(Workout workout)
        {
            var context = GetDatabase();
            //context.Workouts.Add(workout);
            //SaveDatabase(context);
        }

        private Database GetDatabase() 
        {
            var storage = $"{dataDirectory}/{dataFile}";
            if(!File.Exists(storage)) return new Database();
            return JsonConvert.DeserializeObject<Database>(File.ReadAllText(storage));
        }

        private void SaveDatabase(Database context) {
            if(!Directory.Exists(dataDirectory)) Directory.CreateDirectory(dataDirectory);
            var storage = $"{dataDirectory}/{dataFile}";
            File.WriteAllText(storage, JsonConvert.SerializeObject(context));
        }
    }
}