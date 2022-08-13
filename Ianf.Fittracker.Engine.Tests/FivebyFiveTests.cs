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

        private List<Exercise> deadliftHistorySingleExercise = new List<Exercise> {
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
        };

        private List<Exercise> noExercisesList = new List<Exercise>();

        [Fact]
        public void TestGenerateExercisesForNextWorkoutBenchPressFailureFailure() {
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
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.BenchPress});

            // Assert
            Assert.Equal(new Weight(47.5), result.First().ExerciseSet.First().Weight);

            penultimateSet = benchPressHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[1].ExerciseSet.RemoveAt(4);
            benchPressHistory[1].ExerciseSet.Add(penultimateSet);

            finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateExercisesForNextWorkoutBenchPressSuccessFailure() {
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
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.BenchPress});

            // Assert
            Assert.Equal(new Weight(50.0), result.First().ExerciseSet.First().Weight);

            finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateExercisesForNextWorkoutBenchPressSuccessSuccess() {
            // Assemble
            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.BenchPress,
                    benchPressHistory
                }
            };

            // Act
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.BenchPress});

            // Assert
            Assert.Equal(new Weight(52.5), result.First().ExerciseSet.First().Weight);
        }

        [Fact]
        public void TestGenerateExercisesForNextWorkoutDeadliftFailureFailure() {
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
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.Deadlift});

            // Assert
            Assert.Equal(new Weight(45.0), result.First().ExerciseSet.First().Weight);

            penultimateSet = deadliftHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[1].ExerciseSet.RemoveAt(4);
            deadliftHistory[1].ExerciseSet.Add(penultimateSet);

            finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateExercisesForNextWorkoutDeadliftSuccessFailure() {
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
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.Deadlift});

            // Assert
            Assert.Equal(new Weight(50.0), result.First().ExerciseSet.First().Weight);

            finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateExercisesForNextWorkoutDeadliftSuccessSuccess() {
            // Assemble
            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.Deadlift,
                    deadliftHistory
                }
            };

            // Act
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.Deadlift});

            // Assert
            Assert.Equal(new Weight(55.0), result.First().ExerciseSet.First().Weight);
        }
        
        [Fact]
        public void TestGenerateExercisesForNextWorkoutDeadliftOneExercise() {
            // Assemble
            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.Deadlift,
                    deadliftHistorySingleExercise
                }
            };

            // Act
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.Deadlift});

            // Assert
            Assert.Equal(new Weight(50.0), result.First().ExerciseSet.First().Weight);
        }

        [Fact]
        public void TestGenerateExercisesForNextWorkoutDeadliftNoExercises() {
            // Assemble
            var exerciseList = new Dictionary<ExerciseType, List<Exercise>> {
                {
                    ExerciseType.Deadlift,
                    noExercisesList
                }
            };

            // Act
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, exerciseList, new List<ExerciseType>(){ ExerciseType.Deadlift});

            // Assert
            Assert.Equal(new Weight(0.0), result.First().ExerciseSet.First().Weight);
        }

        [Fact]
        public void TestGenerateExercisesForNextWorkout() {
            // Assemble

            // Act
            var result = GenerateExercisesForNextWorkout(WorkoutSubType.WorkoutA, new Dictionary<ExerciseType, List<Exercise>>(), new List<ExerciseType>());

            // Assert
            Assert.Empty(result);
        }
    }
}