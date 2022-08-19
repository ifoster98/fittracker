using Ianf.Fittracker.Interfaces;
using Ianf.Fittracker.Domain;
using LanguageExt;

namespace Ianf.Fittracker.Service
{
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
            _workoutRepository.AddWorkout(workout);
            SetupNextWorkout(workout);
        }

        private void SetupNextWorkout(Workout workout) 
        {
            var database = _workoutRepository.GetDatabase();
            var newWorkout = _engine.GenerateNextWorkout(workout.WorkoutSubType, database);
            _workoutRepository.SetProposedWorkout(newWorkout);
        }

        public Option<Workout> GetNextWorkout() => _workoutRepository.GetNextWorkout();
    }
}