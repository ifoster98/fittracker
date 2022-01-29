using Ianf.Fittracker.Services.Interfaces;

namespace Ianf.Fittracker.Services
{
    public class WorkoutService : IWorkoutService 
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository) 
        {
            _workoutRepository = workoutRepository;
        }

        public string IsAlive() => "Is Alive";
    }
}