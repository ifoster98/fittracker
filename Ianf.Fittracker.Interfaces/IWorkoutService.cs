using Ianf.Fittracker.Domain;
using LanguageExt;

namespace Ianf.Fittracker.Interfaces;

public interface IWorkoutService
{
    void SaveWorkout(Workout workout);
    Option<Workout> GetNextWorkout();
}