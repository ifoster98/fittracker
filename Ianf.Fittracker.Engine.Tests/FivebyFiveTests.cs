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
                Sets = new List<Reps> {
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
                Sets = new List<Reps> {
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
                Sets = new List<Reps> {
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
        public void TestInc() {
            // Assemble
            var weight = new Weight(5.0);

            // Act
            var updatedWeight = Inc(Domain.ExerciseType.Deadlift, weight);

            // Assert
            Assert.Equal(10.0, updatedWeight.GetValue());
        }

        [Fact]
        public void TestIncDeadlift() {
            // Assemble
            var weight = new Weight(5.0);

            // Act
            var updatedWeight = Inc(Domain.ExerciseType.Squat, weight);

            // Assert
            Assert.Equal(7.5, updatedWeight.GetValue());
        }

        [Fact]
        public void TestDec() {
            // Assemble
            var weight = new Weight(5.0);

            // Act
            var updatedWeight = Dec(Domain.ExerciseType.Deadlift, weight);

            // Assert
            Assert.Equal(0.0, updatedWeight.GetValue());
        }

        [Fact]
        public void TestDecDeadlift() {
            // Assemble
            var weight = new Weight(5.0);

            // Act
            var updatedWeight = Dec(Domain.ExerciseType.Squat, weight);

            // Assert
            Assert.Equal(2.5, updatedWeight.GetValue());
        }

        [Fact]
        public void TestDecBottomLimit() {
            // Assemble
            var weight = new Weight(0.0);

            // Act
            var updatedWeight = Dec(Domain.ExerciseType.Deadlift, weight);

            // Assert
            Assert.Equal(0.0, updatedWeight.GetValue());
        }

        [Fact]
        public void TestDecDeadliftBottomLimit() {
            // Assemble
            var weight = new Weight(0.0);

            // Act
            var updatedWeight = Dec(Domain.ExerciseType.Squat, weight);

            // Assert
            Assert.Equal(0.0, updatedWeight.GetValue());
        }

        [Fact]
        public void TestTakeLast() {
            // Assemble
            var expected = benchPressHistory[1];

            // Act
            var result = TakeLast(benchPressHistory, 2);

            // Assert
            Assert.Equal(expected, result.First());
        }

        [Fact]
        public void TestTakeLastEmptyList() {
            // Assemble
            var expected = new List<Exercise>();

            // Act
            var result = TakeLast(new List<Exercise>(), 2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestTakeLastNegativeNumber() {
            // Assemble
            var expected = new List<Exercise>();

            // Act
            var result = TakeLast(benchPressHistory, -1);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestTakeLastZero() {
            // Assemble
            var expected = new List<Exercise>();

            // Act
            var result = TakeLast(benchPressHistory, 0);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}