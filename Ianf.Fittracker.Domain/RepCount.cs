namespace Ianf.Fittracker.Domain
{
    public struct RepCount {
        public int repCount { get; init; }

        public RepCount(int _repCount) {
            this.repCount = _repCount;
        }

        public int GetValue() => this.repCount;
    }
}
