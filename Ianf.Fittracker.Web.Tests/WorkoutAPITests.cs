using Xunit;
using System.Net.Http;
using Ianf.Fittracker.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace Ianf.Fittracker.Web.Tests;

public class WorkoutServiceTests
{
    private Workout workout1 = new Workout
    {
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
    private Workout workout2 = new Workout
    {
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
    private Workout workout3 = new Workout
    {
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
    private Workout workout4 = new Workout
    {
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

    private HttpClient client = new HttpClient();

    [Fact]
    public async Task TestGenerateCorrectWorkoutA()
    {
        // Assemble
        var serviceUrl = "http://localhost:5165/Workout";
        var options = new JsonSerializerOptions { 
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        var body = JsonSerializer.Serialize<Workout>(workout1, options);
        await client.PostAsync(serviceUrl, new StringContent(body));
        body = JsonSerializer.Serialize<Workout>(workout2, options);
        await client.PostAsync(serviceUrl, new StringContent(body));
        body = JsonSerializer.Serialize<Workout>(workout3, options);
        await client.PostAsync(serviceUrl, new StringContent(body));
        body = JsonSerializer.Serialize<Workout>(workout4, options);
        await client.PostAsync(serviceUrl, new StringContent(body));

        // Act
        var result = await client.GetAsync(serviceUrl);
        var foo = await result.Content.ReadAsStringAsync();
        var nextExercise = JsonSerializer.Deserialize<Workout>(foo, options);

        // Assert
        Assert.Equal(50, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.Squat).First().ExerciseSet.First().Weight.GetValue());
        Assert.Equal(40, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.BenchPress).First().ExerciseSet.First().Weight.GetValue());
        Assert.Equal(30, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.BentOverRows).First().ExerciseSet.First().Weight.GetValue());
    }

    [Fact(Skip = "Incomplete")]
    public async void TestGenerateCorrectWorkoutB() {
        // Assemble
        var serviceUrl = "http://localhost:5165/Workout";
        var options = new JsonSerializerOptions { 
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        var body = JsonSerializer.Serialize<Workout>(workout1, options);
        await client.PostAsync(serviceUrl, new StringContent(body));
        body = JsonSerializer.Serialize<Workout>(workout2, options);
        await client.PostAsync(serviceUrl, new StringContent(body));
        body = JsonSerializer.Serialize<Workout>(workout3, options);
        await client.PostAsync(serviceUrl, new StringContent(body));
        body = JsonSerializer.Serialize<Workout>(workout4, options);
        await client.PostAsync(serviceUrl, new StringContent(body));

        // Act
        await client.GetAsync(serviceUrl);
        var result = await client.GetAsync(serviceUrl);
        var foo = await result.Content.ReadAsStringAsync();
        var nextExercise = JsonSerializer.Deserialize<Workout>(foo, options);

        // Assert
        Assert.Equal(50, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.Squat).First().ExerciseSet.First().Weight.GetValue());
        Assert.Equal(30, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.OverheadPress).First().ExerciseSet.First().Weight.GetValue());
        Assert.Equal(70, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.Deadlift).First().ExerciseSet.First().Weight.GetValue());
    }

    [Fact(Skip = "Incomplete")]
    public async void TestGetDefaultWorkout() {
        // Assemble
        var serviceUrl = "http://localhost:5165/Workout";
        var options = new JsonSerializerOptions { 
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        // Act
        var result = await client.GetAsync(serviceUrl);
        var foo = await result.Content.ReadAsStringAsync();
        var nextExercise = JsonSerializer.Deserialize<Workout>(foo, options);

        // Assert
        Assert.Equal(50.0, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.Squat).First().ExerciseSet.First().Weight.GetValue());
        Assert.Equal(40.0, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.BenchPress).First().ExerciseSet.First().Weight.GetValue());
        Assert.Equal(30.0, nextExercise.Exercises.Where(e => e.ExerciseType == ExerciseType.BentOverRows).First().ExerciseSet.First().Weight.GetValue());
    }
}
