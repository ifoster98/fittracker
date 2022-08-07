using LanguageExt;

namespace Ianf.Fittracker.Domain
{
    public struct RepCount {
        private int repCount;

        public RepCount(int _repCount) {
            this.repCount = _repCount;
        }

        public int GetValue() => this.repCount;
    }
}
