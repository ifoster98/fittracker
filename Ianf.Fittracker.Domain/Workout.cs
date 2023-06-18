using LanguageExt;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Domain;

public record struct Workout {
    public Workout() {}
    public WorkoutType WorkoutType { get; init; } = WorkoutType.FiveByFive;
    public WorkoutSubType WorkoutSubType { get; init; } = WorkoutSubType.WorkoutA;
    public DateTime WorkoutTime { get; init; } = DateTime.MinValue;
    public List<Exercise> Exercises { get; init; } = new List<Exercise>();
}