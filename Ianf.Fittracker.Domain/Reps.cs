 namespace Ianf.Fittracker.Domain {
    public record Reps {
        public Weight Weight { get; init; } = default;
        public RepCount RepCount { get; init; } = default;
        public Outcome Outcome { get; init; } = Outcome.Failure;
    }
 }