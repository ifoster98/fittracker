using Ianf.Fittracker.Engine;
using Ianf.Fittracker.Domain;
using Xunit;

namespace Ianf.Fittracker.Engine.Tests
{
    public class FiveByFiveTests {
        private FiveByFive sut = new FiveByFive();

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

        private List<Exercise> squatHistory = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.Squat,
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

        private List<Exercise> overheadPressHistory = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.OverheadPress,
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

        private List<Exercise> bentoverrowHistory = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.BentOverRows,
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
        public void TestGenerateNextWorkoutBenchPressFailureFailure() {
            // Assemble
            var penultimateSet = benchPressHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            benchPressHistory[1].ExerciseSet.RemoveAt(4);
            benchPressHistory[1].ExerciseSet.Add(penultimateSet);

            var finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);

            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, deadliftHistory},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutA, database);

            // Assert
            Assert.Equal(new Weight(47.5), result.Exercises.Where(e => e.ExerciseType == ExerciseType.BenchPress).First().ExerciseSet.First().Weight);

            penultimateSet = benchPressHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[1].ExerciseSet.RemoveAt(4);
            benchPressHistory[1].ExerciseSet.Add(penultimateSet);

            finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateNextWorkoutBenchPressSuccessFailure() {
            // Assemble
            var finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);

            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, deadliftHistory},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                } 
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutA, database);

            // Assert
            Assert.Equal(new Weight(50.0), result.Exercises.Where(e => e.ExerciseType == ExerciseType.BenchPress).First().ExerciseSet.First().Weight);

            finalSet = benchPressHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            benchPressHistory[2].ExerciseSet.RemoveAt(4);
            benchPressHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateNextWorkoutBenchPressSuccessSuccess() {
            // Assemble
            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, deadliftHistory},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutA, database);

            // Assert
            Assert.Equal(new Weight(52.5), result.Exercises.Where(e => e.ExerciseType == ExerciseType.BenchPress).First().ExerciseSet.First().Weight);
        }

        [Fact]
        public void TestGenerateNextWorkoutDeadliftFailureFailure() {
            // Assemble
            var penultimateSet = deadliftHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            deadliftHistory[1].ExerciseSet.RemoveAt(4);
            deadliftHistory[1].ExerciseSet.Add(penultimateSet);

            var finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);

            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, deadliftHistory},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(45.0), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight);

            penultimateSet = deadliftHistory[1].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[1].ExerciseSet.RemoveAt(4);
            deadliftHistory[1].ExerciseSet.Add(penultimateSet);

            finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateNextWorkoutDeadliftSuccessFailure() {
            // Assemble
            var finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Failure};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);

            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, deadliftHistory},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(50.0), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight);

            finalSet = deadliftHistory[2].ExerciseSet.Last() with {Outcome = Outcome.Success};
            deadliftHistory[2].ExerciseSet.RemoveAt(4);
            deadliftHistory[2].ExerciseSet.Add(finalSet);
        }

        [Fact]
        public void TestGenerateNextWorkoutDeadliftSuccessSuccess() {
            // Assemble
            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, deadliftHistory},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Ac
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(55.0), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight);
        }
        
        [Fact]
        public void TestGenerateNextWorkoutOneExercise() {
            // Assembl
            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, deadliftHistorySingleExercise},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Ac
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(50.0).GetValue(), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight.GetValue());
        }

        [Fact]
        public void TestGenerateNextWorkoutNoExercises() {
            // Assemble
            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, noExercisesList},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(0.0).GetValue(), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight.GetValue());
        }

        [Fact]
        public void TestGenerateNextWorkoutNoEntryForExercise() {
            // Assemble
            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(0.0).GetValue(), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight.GetValue());
        }

        [Fact]
        public void TestGenerateNextWorkoutNullEntryForExercise() {
            // Assemble
            var database = new Database {
                ExerciseLookup = new Dictionary<ExerciseType, List<Exercise>> {
                {ExerciseType.BenchPress, benchPressHistory},
                {ExerciseType.Deadlift, null},
                {ExerciseType.OverheadPress, overheadPressHistory},
                {ExerciseType.BentOverRows, bentoverrowHistory},
                {ExerciseType.Squat, squatHistory}
                }
            };

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(0.0).GetValue(), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight.GetValue());
        }

        [Fact]
        public void TestGenerateNextWorkoutEmptyDatabase() {
            // Assemble
            var database = new Database();

            // Act
            var result = sut.GenerateNextWorkout(WorkoutSubType.WorkoutB, database);

            // Assert
            Assert.Equal(new Weight(0.0).GetValue(), result.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight.GetValue());
        }
    }
}