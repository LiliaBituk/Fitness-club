
using BusinessLogic;
using Xunit;

namespace TestProject1
{
    public class GroupTrainingTests
    {
        [Fact]
        public void GroupTraining_Type_IsNotNullOrEmpty()
        {
            // Arrange
            var groupTraining = new GroupTraining();

            // Act
            groupTraining.Type = "танцевальные";
            string selectedType = "танцевальные";
            // Assert
            Assert.Equal(groupTraining.Type, selectedType);
        }
    }
}
