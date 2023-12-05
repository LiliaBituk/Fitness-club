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
                new GroupTraining { Type = "��������" },
                new GroupTraining { Type = "�������" },
                new GroupTraining { Type = "������������" }
            };

            var userInteraction = new GroupTrainingsUserInteraction(groupTrainingList);

            // Act
            var consoleOutput = CaptureConsoleOutput(() => userInteraction.OutputTypeOfGroupTrainings());

            // Assert
            Assert.Contains("��������", consoleOutput);
            Assert.Contains("�������", consoleOutput);
            Assert.Contains("������������", consoleOutput);
        }

        // ������ �������
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