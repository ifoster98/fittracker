using LanguageExt;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Domain {
    public record Workout {
        public WorkoutType WorkoutType { get; init; } = WorkoutType.FiveByFive;
        public WorkoutSubType WorkoutSubType { get; init; } = WorkoutSubType.WorkoutA;
        public Option<DateTime> WorkoutTime { get; init; } = None;
        public List<Exercise> Exercises { get; init; } = new List<Exercise>();
    }
}