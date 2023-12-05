using BusinessLogic;
using TP_lab2;
using Xunit;

namespace TestProject1
{
    public class GroupTrainingUserInteractionTest
    {

        [Fact]
        public void OutputTypeOfGroupTrainings_ConsoleOutputContainsTypes()
        {
            // Arrange
            var groupTrainingList = new List<GroupTraining>
            {
                new GroupTraining { Type = "аэробные" },
                new GroupTraining { Type = "силовые" },
                new GroupTraining { Type = "танцевальные" }
            };

            var userInteraction = new GroupTrainingsUserInteraction(groupTrainingList);

            // Act
            var consoleOutput = CaptureConsoleOutput(() => userInteraction.OutputTypeOfGroupTrainings());

            // Assert
            Assert.Contains("аэробные", consoleOutput);
            Assert.Contains("силовые", consoleOutput);
            Assert.Contains("танцевальные", consoleOutput);
        }

        // Захват консоли
        private string CaptureConsoleOutput(Action action)
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            action.Invoke();

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            return consoleOutput.ToString();
        }
    }
}