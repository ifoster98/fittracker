using Ianf.Fittracker.Domain;

namespace Ianf.Fittracker.Interfaces
{
    public interface IWorkoutService
    {
        void SaveWorkout(Workout workout);
        Workout GetNextWorkout();
    }
}