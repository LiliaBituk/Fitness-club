using Xunit;
using BusinessLogic;

namespace BusinessLogicTest
{
    public class GroupTrainingTest
    {
        [Fact]
        public void SelectedGroupTrainingIsAvailable_ReturnsTrue()
        {
            var groupTraining = new GroupTraining
            {
                VacantPlaces = new Dictionary<string, int[]>
                {
                    { "SubtypeWithAvailablePlaces", new int[] { 5, 10 } }
                }
            };

            var result = groupTraining.selectedGroupTrainingIsAvailable("SubtypeWithAvailablePlaces");

            Assert.True(result);
        }

        [Fact]
        public void SelectedGroupTrainingIsAvailable_ReturnsFalse()
        {
            var groupTraining = new GroupTraining
            {
                VacantPlaces = new Dictionary<string, int[]>
                {
                    { "SubtypeWithoutAvailablePlaces", new int[] { 10, 10 } }
                }
            };

            var result = groupTraining.selectedGroupTrainingIsAvailable("SubtypeWithoutAvailablePlaces");

            Assert.False(result);
        }

    }
}
