using LanguageExt;
using System;
using Ianf.Fittracker.Domain;

namespace Ianf.Fittracker.Interfaces
{
    public interface IWorkoutRepository
    {
        void AddWorkout(Workout workout);
        Option<Workout> GetNextWorkout();
    }
}