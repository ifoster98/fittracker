using LanguageExt;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Domain {
    public record Database {
        public Dictionary<ExerciseType, List<Exercise>> ExerciseLookup { get; init; } = new Dictionary<ExerciseType, List<Exercise>>();
        public Option<Workout> ProposedWorkout { get; init; } = None;
    }
}