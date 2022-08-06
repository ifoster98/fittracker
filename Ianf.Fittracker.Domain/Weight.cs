using LanguageExt;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Domain {
    public struct Weight {
        private double weight;

        public Weight(double _weight) {
            this.weight = _weight;
        }

        public double GetValue() => this.weight;
    }
}