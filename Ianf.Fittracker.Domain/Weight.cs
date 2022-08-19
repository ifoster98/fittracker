namespace Ianf.Fittracker.Domain;

public struct Weight {
    public double weight { get; init; }

    public Weight(double _weight) {
        this.weight = _weight;
    }

    public double GetValue() => this.weight;
}