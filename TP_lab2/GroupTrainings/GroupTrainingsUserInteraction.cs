
namespace TP_lab2
{
    internal class GroupTrainingsUserInteraction
    {
        private GroupTrainingsInformation groupTrainingInfo;

        private string selectedTypeOfTraining;


        public GroupTrainingsUserInteraction(string[] groupTrainingFilePaths)
        {
            groupTrainingInfo = new GroupTrainingsInformation(groupTrainingFilePaths);
            
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
            do
            {
                Console.Write("Введите инересующий вид тренировки: ");
                selectedTypeOfTraining = GetInput();
                Console.WriteLine();
            }
            while (!groupTrainingInfo.groupTrainingList.Any(training => training.Type.Equals(selectedTypeOfTraining, StringComparison.OrdinalIgnoreCase)));

            return selectedTypeOfTraining;
        }

        public string GetSelectedTimeInput(string selectedGroupTraining)
        {
            string timeOfSelectedTraining;
            GroupTraining groupTraining = groupTrainingInfo.groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));

            do
            {
                Console.Write("Выберите удобное время: ");
                timeOfSelectedTraining = GetInput();
                Console.WriteLine();
            }
            while(!groupTraining.Times.Contains(timeOfSelectedTraining));

            return timeOfSelectedTraining;
        }

        public string GetSelectedSubtypeInput(string selectedGroupTraining)
        {
            string selectedSubtype;
            GroupTraining groupTraining = groupTrainingInfo.groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));

            do
            {
                Console.Write("Введите интересующий тип тренировки: ");
                selectedSubtype = GetInput();
                Console.WriteLine();
            }
            while (!(groupTraining.VacantPlaces[selectedSubtype][0] < groupTraining.VacantPlaces[selectedSubtype][1]));

            return selectedSubtype;
        }

        public void OutputTypeOfGroupTrainings()
        {
            Console.WriteLine("У нас представлены следующие виды тренировок:");
            foreach (var training in groupTrainingInfo.groupTrainingList)
            {
                Console.WriteLine($" - {training.Type}");
            }
        }

        public void OutputTimeOfGroupTrainings(string selectedGroupTraining)
        {
            Console.WriteLine($"Доступное время для тренировки типа '{selectedGroupTraining}':");

            GroupTraining groupTraining = groupTrainingInfo.groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));

            foreach (string time in groupTraining.Times)
            {
                Console.WriteLine($" - {time}");
            }
            Console.WriteLine();
        }

        public void OutputVacantPlaces(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            GroupTraining groupTraining = groupTrainingInfo.groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));


            foreach (var entry in groupTraining.VacantPlaces)
            {
                string trainingName = entry.Key;
                int[] vacantCurrentMax = entry.Value;
                Console.WriteLine($" - {trainingName} {vacantCurrentMax[0]}/{vacantCurrentMax[1]}");
            }
        }
    }
}
