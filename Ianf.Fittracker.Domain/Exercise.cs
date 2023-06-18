namespace Ianf.Fittracker.Domain;

public record struct Exercise {
    public Exercise(){}
    public ExerciseType ExerciseType { get; init; } = ExerciseType.Squat;
    public DateTime ExerciseTime { get; init; } = DateTime.MinValue;
    public List<Reps> ExerciseSet { get; init; } = new List<Reps>();
}