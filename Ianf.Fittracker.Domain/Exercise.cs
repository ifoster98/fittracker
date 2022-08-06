using LanguageExt;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Domain {
    public record Exercise {
        public ExerciseType ExerciseType { get; init; } = ExerciseType.Squat;
        public Option<DateTime> ExerciseTime { get; init; } = None;
        public List<Reps> Sets { get; init; } = new List<Reps>();
    }
}