using Ianf.Fittracker.Domain;

namespace Ianf.Fittracker.Engine
{
    public static class FiveByFive {
        public static Weight Inc(ExerciseType et, Weight w) => 
            et == ExerciseType.Deadlift 
                ? new Weight(w.GetValue() + 5) 
                : new Weight(w.GetValue() + 2.5);

        public static Weight Dec(ExerciseType et, Weight w) => 
            et == ExerciseType.Deadlift 
                ? BottomLimit(new Weight(w.GetValue() - 5))
                : BottomLimit(new Weight(w.GetValue() - 2.5));

        private static Weight BottomLimit(Weight w) => w.GetValue() < 0 ? new Weight(0) : w;

        public static IEnumerable<Exercise> TakeLast(IEnumerable<Exercise> exs, int amount) => 
            exs.Any() 
                ? Enumerable.Reverse(Enumerable.Reverse(exs).Take(amount))
                : exs;

        public static Weight GetWeight(Exercise ex) => 
            ex.ExerciseSet.Any()
                ? ex.ExerciseSet.First().Weight
                : new Weight(0);

        private static Outcome GetOutcomeFromReps(List<Reps> reps) =>
            reps.Where(r => r.Outcome == Outcome.Failure).Any()
                ? Outcome.Failure
                : Outcome.Success;

        public static Outcome GetOutcome(Exercise ex) =>
            ex.ExerciseSet.Any()
                ? GetOutcomeFromReps(ex.ExerciseSet)
                : Outcome.Failure;

        public static Weight CalculateNextWeight(ExerciseType et, Weight w, (Outcome, Outcome) history) => history switch
        {
            (Outcome, Outcome) t when t.Item1 == Outcome.Failure && t.Item2 == Outcome.Failure => Dec(et, w),
            (Outcome, Outcome) t when t.Item2 == Outcome.Failure => w,
            _ => Inc(et, w)
        };

        public static Weight GetLastWeight(IEnumerable<Exercise> exs) => 
            exs.Any()
                ? GetWeight(exs.Last())
                : new Weight(0.0);
    }
}