using Xunit;
using Ianf.Fittracker.Repositories;
using Ianf.Fittracker.Engine;
using Ianf.Fittracker.Interfaces;
using Ianf.Fittracker.Domain;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Ianf.Fittracker.Service.Tests;

public class WorkoutServiceTests
{
    private IWorkoutRepository _repository;
    private IEngine _engine;
    private IWorkoutService _sut;
    private Workout workout1 = new Workout{
        WorkoutType = WorkoutType.FiveByFive,
        WorkoutSubType = WorkoutSubType.WorkoutA,
        WorkoutTime = new DateTime(2022, 08, 01),
        Exercises = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.Squat,
                ExerciseTime = new DateTime(2022, 08, 01),
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
            },
            new Exercise() {
                ExerciseType = ExerciseType.BenchPress,
                ExerciseTime = new DateTime(2022, 08, 01),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(40.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.BentOverRows,
                ExerciseTime = new DateTime(2022, 08, 01),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(30.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            }
        }
    };
    private Workout workout2 = new Workout{
        WorkoutType = WorkoutType.FiveByFive,
        WorkoutSubType = WorkoutSubType.WorkoutB,
        WorkoutTime = new DateTime(2022, 08, 02),
        Exercises = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.Squat,
                ExerciseTime = new DateTime(2022, 08, 02),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(52.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(52.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(52.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(52.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(52.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.OverheadPress,
                ExerciseTime = new DateTime(2022, 08, 02),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(25.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(25.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(25.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(25.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(25.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.Deadlift,
                ExerciseTime = new DateTime(2022, 08, 02),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(60.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(60.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(60.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(60.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(60.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            }
        }
    };
    private Workout workout3 = new Workout{
        WorkoutType = WorkoutType.FiveByFive,
        WorkoutSubType = WorkoutSubType.WorkoutA,
        WorkoutTime = new DateTime(2022, 08, 03),
        Exercises = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.Squat,
                ExerciseTime = new DateTime(2022, 08, 03),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(55.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(55.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(55.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(55.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(55.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.BenchPress,
                ExerciseTime = new DateTime(2022, 08, 03),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(42.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(42.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(42.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(42.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(42.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.BentOverRows,
                ExerciseTime = new DateTime(2022, 08, 03),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(32.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(32.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(32.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(32.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(32.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            }
        }
    };
    private Workout workout4 = new Workout{
        WorkoutType = WorkoutType.FiveByFive,
        WorkoutSubType = WorkoutSubType.WorkoutB,
        WorkoutTime = new DateTime(2022, 08, 04),
        Exercises = new List<Exercise> {
            new Exercise() {
                ExerciseType = ExerciseType.Squat,
                ExerciseTime = new DateTime(2022, 08, 04),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(57.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(57.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(57.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(57.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(57.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.OverheadPress,
                ExerciseTime = new DateTime(2022, 08, 04),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(27.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(27.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(27.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(27.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(27.5),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            },
            new Exercise() {
                ExerciseType = ExerciseType.Deadlift,
                ExerciseTime = new DateTime(2022, 08, 04),
                ExerciseSet = new List<Reps> {
                    new Reps {
                        Weight = new Weight(65.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(65.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(65.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(65.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    },
                    new Reps {
                        Weight = new Weight(65.0),
                        RepCount = new RepCount(5),
                        Outcome = Outcome.Success
                    }
                }
            }
        }
    };

    public WorkoutServiceTests()
    {
        _repository = new WorkoutInMemRepository();
        _engine = new FiveByFive();
        _sut = new WorkoutService(_repository, _engine);
    }

    [Fact]
    public void TestGenerateCorrectWorkoutA() {
        // Assemble
        _sut.SaveWorkout(workout1);
        _sut.SaveWorkout(workout2);
        _sut.SaveWorkout(workout3);
        _sut.SaveWorkout(workout4);

        // Act
        var result = _sut.GetNextWorkout();

        // Assert
        result.Match(
            Some: (s) => Assert.Equal(60, s.Exercises.Where(e => e.ExerciseType == ExerciseType.Squat).First().ExerciseSet.First().Weight.GetValue()),
            None: () => Assert.False(true, "Should have received new squat exercise of 60kg.")
        );
        result.Match(
            Some: (s) => Assert.Equal(45, s.Exercises.Where(e => e.ExerciseType == ExerciseType.BenchPress).First().ExerciseSet.First().Weight.GetValue()),
            None: () => Assert.False(true, "Should have received new bench press exercise of 45kg.")
        );
        result.Match(
            Some: (s) => Assert.Equal(35, s.Exercises.Where(e => e.ExerciseType == ExerciseType.BentOverRows).First().ExerciseSet.First().Weight.GetValue()),
            None: () => Assert.False(true, "Should have received new bent over rows exercise of 35kg.")
        );
    }

    [Fact]
    public void TestGenerateCorrectWorkoutB() {
        // Assemble
        _sut.SaveWorkout(workout1);
        _sut.SaveWorkout(workout2);
        _sut.SaveWorkout(workout3);
        _sut.SaveWorkout(workout4);
        var result = _sut.GetNextWorkout();
        result.Match(
            Some: (s) => SaveResult(s),
            None: () => Assert.True(false, "Should have received new workout of type B.")
        );

        // Act
        var workoutA = _sut.GetNextWorkout();

        // Assert
        workoutA.Match(
            Some: (s) => Assert.Equal(62.5, s.Exercises.Where(e => e.ExerciseType == ExerciseType.Squat).First().ExerciseSet.First().Weight.GetValue()),
            None: () => Assert.False(true, "Should have received new squat exercise of 62.5")
        );
        workoutA.Match(
            Some: (s) => Assert.Equal(30, s.Exercises.Where(e => e.ExerciseType == ExerciseType.OverheadPress).First().ExerciseSet.First().Weight.GetValue()),
            None: () => Assert.False(true, "Should have received new bench press exercise of 30kg.")
        );
        workoutA.Match(
            Some: (s) => Assert.Equal(70, s.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight.GetValue()),
            None: () => Assert.False(true, "Should have received new bent over rows exercise of 70kg.")
        );

        void SaveResult(Workout result) {
            result = result with { WorkoutTime = new DateTime(2022, 08, 04) };
            result = result with { 
                Exercises = result.Exercises.Select(
                    exercise => exercise with { 
                        ExerciseSet = exercise.ExerciseSet.Select(
                            es => es with { Outcome = Outcome.Success }
                        ).ToList() 
                    }).ToList()
                };
            _sut.SaveWorkout(result);
        }
    }
}
