using Microsoft.AspNetCore.Mvc;
using Ianf.Fittracker.Domain;
using Ianf.Fittracker.Interfaces;

namespace Ianf.Fittracker.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;
    private readonly ILogger<WorkoutController> _logger;

    public WorkoutController(IWorkoutService workoutService, ILogger<WorkoutController> logger)
    {
        _workoutService = workoutService;
        _logger = logger;
    }

    [HttpGet]
    public Workout GetNextWorkout() => _workoutService.GetNextWorkout();

    [HttpPost]
    public void SaveWorkout(Workout workout) => _workoutService.SaveWorkout(workout);
}
