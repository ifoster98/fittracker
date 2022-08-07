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
    }
}