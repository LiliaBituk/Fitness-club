
namespace TP_lab2
{
    internal class GroupTrainingsUserInteraction
    {
        public GroupTrainingsInformation info;

        public GroupTrainingsUserInteraction(string groupTrainingFilePath)
        {
            info = new GroupTrainingsInformation(groupTrainingFilePath);
        }

        private string GetInput()
        {
            while (true)
            {
                string enteredData = Console.ReadLine();
                if (enteredData != null && enteredData != "") { return enteredData; }
            }
        }

        public bool GetNeedForGroupTraining()
        {
            string groupTrainingChoice;
            do
            {
                
                Console.Write("Желаете записаться на групповое занятие? (да/нет): ");
                groupTrainingChoice = GetInput();
                Console.WriteLine();
                if (groupTrainingChoice == "да") return true;
                if (groupTrainingChoice == "нет") return false;
            }
            while (true);
        }

        public string GetSelectedGroupTrainingInput()
        {
            string selectedGroupTraining;
            do
            {
                Console.Write("Введите инересующий вид тренировки: ");
                selectedGroupTraining = GetInput();
                Console.WriteLine();
            }
            while (!info.typeOfGroupTrainings.ContainsKey(selectedGroupTraining));

            return selectedGroupTraining;
        }

        public string GetSelectedTimeInput(string selectedGroupTraining)
        {
            string timeOfSelectedTraining;
            do
            {
                Console.Write("Выберите удобное время: ");
                timeOfSelectedTraining = GetInput();
                Console.WriteLine();
            }
            while (!info.timeOfGroupTrainings[selectedGroupTraining].Contains(timeOfSelectedTraining));

            return timeOfSelectedTraining;
        }

        public void OutputTypeOfGroupTrainings()
        {
            Console.WriteLine("У нас представлены следующие виды тренировок:");
            foreach (string key in info.typeOfGroupTrainings.Keys)
            {
                Console.WriteLine($" - {key}");
            }
        }

        public void OutputTimeOfGroupTrainings(string selectedGroupTraining)
        {
            Console.WriteLine("Доступное время:");
            foreach (string time in info.timeOfGroupTrainings[selectedGroupTraining])
            {
                Console.WriteLine($" - {time}");
            }
            Console.WriteLine();
        }
    }
}
