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

        private List<Exercise> deadliftHistory = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.Deadlift,
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
                ExerciseType = ExerciseType.Deadlift,
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
                ExerciseType = ExerciseType.Deadlift,
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

        // test with only one exercise in list

        // test with no exercises in list

        [Fact]
        public void TestGetNextWeightBenchPressFailureFailure() {
            // Assemble
            var penultimateSet = benchPressHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            benchPressHistory[1].ExerciseSet.RemoveAt(4);
            benchPressHistory[1].ExerciseSet.Add(penultimateSet);

            var finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);

            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.BenchPress,
                    benchPressHistory
                }
            };

            // Act
            var result = GetNextWeight(ExerciseType.BenchPress, exerciseList);

            // Assert
            Assert.Equal(new Weight(47.5), result);

            penultimateSet = benchPressHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[1].ExerciseSet.RemoveAt(4);
            benchPressHistory[1].ExerciseSet.Add(penultimateSet);

            finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGetNextWeightBenchPressSuccessFailure() {
            // Assemble
            var finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);

            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.BenchPress,
                    benchPressHistory
                }
            };

            // Act
            var result = GetNextWeight(ExerciseType.BenchPress, exerciseList);

            // Assert
            Assert.Equal(new Weight(50.0), result);

            finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGetNextWeightBenchPressSuccessSuccess() {
            // Assemble
            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.BenchPress,
                    benchPressHistory
                }
            };

            // Act
            var result = GetNextWeight(ExerciseType.BenchPress, exerciseList);

            // Assert
            Assert.Equal(new Weight(52.5), result);
        }

        [Fact]
        public void TestGetNextWeightDeadliftFailureFailure() {
            // Assemble
            var penultimateSet = deadliftHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            deadliftHistory[1].ExerciseSet.RemoveAt(4);
            deadliftHistory[1].ExerciseSet.Add(penultimateSet);

            var finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);

            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.Deadlift,
                    deadliftHistory
                }
            };

            // Act
            var result = GetNextWeight(ExerciseType.Deadlift, exerciseList);

            // Assert
            Assert.Equal(new Weight(45.0), result);

            penultimateSet = deadliftHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[1].ExerciseSet.RemoveAt(4);
            deadliftHistory[1].ExerciseSet.Add(penultimateSet);

            finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGetNextWeightDeadliftSuccessFailure() {
            // Assemble
            var finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);

            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.Deadlift,
                    deadliftHistory
                }
            };

            // Act
            var result = GetNextWeight(ExerciseType.Deadlift, exerciseList);

            // Assert
            Assert.Equal(new Weight(50.0), result);

            finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGetNextWeightDeadliftSuccessSuccess() {
            // Assemble
            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.Deadlift,
                    deadliftHistory
                }
            };

            // Act
            var result = GetNextWeight(ExerciseType.Deadlift, exerciseList);

            // Assert
            Assert.Equal(new Weight(55.0), result);
        }
    }
}