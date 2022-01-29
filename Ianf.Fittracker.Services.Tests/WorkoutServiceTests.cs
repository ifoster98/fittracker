using Ianf.Fittracker.Services.Interfaces;
using System;
using Xunit;
using Moq;

namespace Ianf.Fittracker.Services.Tests
{
    public class WorkoutServiceTests
    {
        [Fact]
        public void TestHealthCheck()
        {
            // Assemble
            var _sut = new WorkoutService(new FakeRepository());

            // Act
            var result = _sut.IsAlive();

            // Assert

            Assert.Equal("Is Alive", result);
        }

        private class FakeRepository: IWorkoutRepository 
        {

        }
    }
}
