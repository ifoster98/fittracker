namespace Ianf.Fittracker.Domain
{
    public enum Outcome {
        Success = 1,
        Failure = 0
    }

    public enum WorkoutType {
        FiveByFive,
        MadCow,
        UpperLowerSplit
    }

    public enum WorkoutSubType {
        WorkoutA,
        WorkoutB
    }

    public enum ExerciseType {
        Squat,
        BenchPress,
        Deadlift,
        OverheadPress,
        BentOverRows
    }
}