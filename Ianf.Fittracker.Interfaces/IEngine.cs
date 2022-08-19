using Ianf.Fittracker.Domain;

namespace Ianf.Fittracker.Interfaces;

public interface IEngine
{
    Workout GenerateNextWorkout(WorkoutSubType wst, Database database);
}