using Ianf.Fittracker.Interfaces;
using Ianf.Fittracker.Domain;
using LanguageExt;

namespace Ianf.Fittracker.Repositories
{
    public class WorkoutInMemRepository : IWorkoutRepository
    {
        private Database database = new Database();

        public void AddWorkout(Workout workout) => 
            workout.Exercises.ForEach(GetUpdatedExerciseList);

        private void GetUpdatedExerciseList(Exercise ex)
        {
            if(database.ExerciseLookup.ContainsKey(ex.ExerciseType)) {
                database.ExerciseLookup[ex.ExerciseType].Add(ex);
            } else {
                database.ExerciseLookup[ex.ExerciseType] = new List<Exercise> { ex };
            }
        }

        public void SetProposedWorkout(Workout workout) => database = database with { ProposedWorkout = workout };

        public Option<Workout> GetNextWorkout() => database.ProposedWorkout;

        public Database GetDatabase() => database;
    }
}
