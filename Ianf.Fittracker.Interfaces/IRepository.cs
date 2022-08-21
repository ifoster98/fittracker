using LanguageExt;
using Ianf.Fittracker.Domain;

namespace Ianf.Fittracker.Interfaces;

public interface IWorkoutRepository
{
    Either<FittrackerError, Unit> AddWorkout(Workout workout);
    Either<FittrackerError, Unit> SetProposedWorkout(Workout workout);
    Either<FittrackerError, Option<Workout>> GetNextWorkout();
    Either<FittrackerError, Database> GetDatabase();
}