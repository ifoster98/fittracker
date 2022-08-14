using Ianf.Fittracker.Interfaces;
using Ianf.Fittracker.Domain;
using Ianf.Fittracker.Engine;

namespace Ianf.Fittracker.CompilerServices
{
    public class WorkoutService: IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository) {
            _workoutRepository = workoutRepository;
        }

        public void SaveWorkout(Workout workout) {
            _workoutRepository.AddWorkout(workout);
            SetupNextWorkout(workout);
        }

        private void SetupNextWorkout(Workout workout) 
        {
            var database = _workoutRepository.GetDatabase();
            var newWorkout = FiveByFive.GenerateNextWorkout(workout.WorkoutSubType, database);
            _workoutRepository.SetProposedWorkout(newWorkout);
        }

        public Workout GetNextWorkout() => _workoutRepository.GetNextWorkout();
    }
}