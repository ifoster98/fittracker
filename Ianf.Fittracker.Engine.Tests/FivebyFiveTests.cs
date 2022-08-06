using Ianf.Fittracker.Engine;
using static Ianf.Fittracker.Engine.FiveByFive;
using Ianf.Fittracker.Domain;
using Xunit;

namespace Ianf.Fittracker.Engine.Tests {
    public class FiveByFiveTests {
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
    }
}