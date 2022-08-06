using LanguageExt;

namespace Ianf.Fittracker.Domain
{
    public struct RepCount {
        private int repCount;

        private RepCount(int _repCount) {
            this.repCount = _repCount;
        }

        public static Either<FittrackerError, RepCount> CreateRepCount(int _repCount) {
            if(ValidateInput(_repCount)) return new RepCount(_repCount);
            return new FittrackerError($"Value {_repCount} must be a positive integer.");
        }

        private static bool ValidateInput(int input) {
            if(input <= 0) return false;
            return true;
        }
    }
}
