using static Ianf.Fittracker.Engine.FiveByFive;
using Ianf.Fittracker.Domain;
using Xunit;

namespace Ianf.Fittracker.Engine.Tests
{
    public class FiveByFiveTests {
        private List<Exercise> benchPressHistory = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.BenchPress,
                ExerciseTime = DateTime.Now,
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(45.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(45.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(45.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(45.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(45.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.BenchPress,
                ExerciseTime = DateTime.Now,
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(47.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(47.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(47.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(47.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(47.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.BenchPress,
                ExerciseTime = DateTime.Now,
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(50.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            }
        };

        [Fact]
        public void TestGetWeight() {
            // Assemble

            // Act
            var result = GetWeight(benchPressHistory.First());

            // Assert
            Assert.Equal(new Weight(45.0), result);
        }

        [Fact]
        public void TestGetWeightNoSets() {
            // Assemble
            var newExercise = benchPressHistory.First() with { ExerciseSet = new List<Reps>() };

            // Act
            var result = GetWeight(newExercise);

            // Assert
            Assert.Equal(new Weight(0), result);
        }

        [Fact]
        public void TestGetOutcome() {
            // Assemble
            var expected = Outcome.Success;

            // Act
            var result = GetOutcome(benchPressHistory.First());

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetOutcomeFailure() {
            // Assemble
            var toTest = benchPressHistory.First() with { ExerciseSet = new List<Reps>{new Reps{ Weight = new Weight(50.0), Outcome = Outcome.Failure, RepCount = new RepCount(5)}}};
            var expected = Outcome.Failure;

            // Act
            var result = GetOutcome(toTest);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestCalculateNextWeightBenchPressFailureFailure() {
            // Assemble
            var w = new Weight(50.0);

            // Act
            var result = CalculateNextWeight(ExerciseType.BenchPress, w, (Outcome.Failure, Outcome.Failure));

            // Assert
            Assert.Equal(new Weight(47.5), result);
        }

        [Fact]
        public void TestCalculateNextWeightBenchPressSuccessFailure() {
            // Assemble
            var w = new Weight(50.0);

            // Act
            var result = CalculateNextWeight(ExerciseType.BenchPress, w, (Outcome.Success, Outcome.Failure));

            // Assert
            Assert.Equal(new Weight(50.0), result);
        }

        [Fact]
        public void TestCalculateNextWeightBenchPressSuccessSuccess() {
            // Assemble
            var w = new Weight(50.0);

            // Act
            var result = CalculateNextWeight(ExerciseType.BenchPress, w, (Outcome.Success, Outcome.Success));

            // Assert
            Assert.Equal(new Weight(52.5), result);
        }

        [Fact]
        public void TestCalculateNextWeightDeadliftFailureFailure() {
            // Assemble
            var w = new Weight(50.0);

            // Act
            var result = CalculateNextWeight(ExerciseType.Deadlift, w, (Outcome.Failure, Outcome.Failure));

            // Assert
            Assert.Equal(new Weight(45.0), result);
        }

        [Fact]
        public void TestCalculateNextWeightDeadliftSuccessFailure() {
            // Assemble
            var w = new Weight(50.0);

            // Act
            var result = CalculateNextWeight(ExerciseType.Deadlift, w, (Outcome.Success, Outcome.Failure));

            // Assert
            Assert.Equal(new Weight(50.0), result);
        }

        [Fact]
        public void TestCalculateNextWeightDeadliftSuccessSuccess() {
            // Assemble
            var w = new Weight(50.0);

            // Act
            var result = CalculateNextWeight(ExerciseType.Deadlift, w, (Outcome.Success, Outcome.Success));

            // Assert
            Assert.Equal(new Weight(55.0), result);
        }

        [Fact]
        public void TestCalculateNextWeightDeadliftAtZeroFailureFailure() {
            // Assemble
            var w = new Weight(0.0);

            // Act
            var result = CalculateNextWeight(ExerciseType.Deadlift, w, (Outcome.Failure, Outcome.Failure));

            // Assert
            Assert.Equal(new Weight(0.0), result);
        }

        [Fact]
        public void TestGetLastWeight() {
            // Assemble

            // Act
            var result = GetLastWeight(benchPressHistory);

            // Assert
            Assert.Equal(new Weight(50.0), GetWeight(benchPressHistory.Last()));
        }

        [Fact]
        public void TestGetLastWeightEmptyList() {
            // Assemble
            var toTest = new List<Exercise>();
            var expected = new Weight(0);

            // Act
            var result = GetLastWeight(toTest);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetLastTwoOutcomes() {
            // Assemble
            var expected = (Outcome.Success, Outcome.Success);

            // Act
            var result = GetLastTwoOutcomes(benchPressHistory);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetLastTwoOutcomesSingleExercise() {
            // Assemble
            var toTest = new List<Exercise> {benchPressHistory.First()};
            var expected = (Outcome.Success, Outcome.Success);

            // Act
            var result = GetLastTwoOutcomes(toTest);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetLastTwoOutcomesEmptyList() {
            // Assemble
            var toTest = new List<Exercise>();
            var expected = (Outcome.Failure, Outcome.Failure);

            // Act
            var result = GetLastTwoOutcomes(toTest);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}