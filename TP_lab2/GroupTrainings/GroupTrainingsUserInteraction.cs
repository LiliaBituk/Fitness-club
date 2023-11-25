
namespace TP_lab2
{
    internal class GroupTrainingsUserInteraction
    {
        List<GroupTraining> groupTrainingList;

        private string selectedTypeOfTraining;


        public GroupTrainingsUserInteraction(List<GroupTraining> groupTrainingList)
        {
            this.groupTrainingList = groupTrainingList;
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
            while (!groupTrainingList.Any(training => training.Type.Equals(selectedTypeOfTraining, StringComparison.OrdinalIgnoreCase)));

            return selectedTypeOfTraining;
        }

        public string GetSelectedTimeInput(string selectedGroupTraining)
        {
            string timeOfSelectedTraining;
            GroupTraining groupTraining = groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));

            do
            {
                Console.Write("Выберите удобное время: ");
                timeOfSelectedTraining = GetInput();
                Console.WriteLine();
            }
            while (!groupTraining.Times.Contains(timeOfSelectedTraining));

            return timeOfSelectedTraining;
        }

        private bool SelectedSubtypeIsExist(string selectedSubtype, GroupTraining groupTraining)
        {
            if (groupTraining.VacantPlaces.ContainsKey(selectedSubtype))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Выбранная тренировка не содержит подтипа {selectedSubtype}.");
                return false;
            }
        }

        private bool SelectedSubtypeHasAvailablePlaces(string selectedSubtype, GroupTraining groupTraining)
        {
            if (groupTraining.VacantPlaces[selectedSubtype][0] < groupTraining.VacantPlaces[selectedSubtype][1])
            {
                return true;
            }
            else 
            {
                Console.WriteLine($"Недостаточно свободных мест для подтипа {selectedSubtype}.");
                return false; 
            }
        }

        public string GetSelectedSubtypeInput(string selectedGroupTraining)
        {
            string selectedSubtype;
            GroupTraining groupTraining = groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));

            do
            {
                do
                {
                    Console.Write("Введите интересующий тип тренировки: ");
                    selectedSubtype = GetInput();
                    Console.WriteLine();
                }
                while (!SelectedSubtypeIsExist(selectedSubtype, groupTraining));
            }
            while (!SelectedSubtypeHasAvailablePlaces(selectedSubtype, groupTraining));

            return selectedSubtype;
        }

        public void OutputTypeOfGroupTrainings()
        {
            Console.WriteLine("У нас представлены следующие виды тренировок:");
            foreach (var training in groupTrainingList)
            {
                Console.WriteLine($" - {training.Type}");
            }
        }

        public void OutputTimeOfGroupTrainings(string selectedGroupTraining)
        {
            Console.WriteLine($"Доступное время для тренировки типа '{selectedGroupTraining}':");

            GroupTraining groupTraining = groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));

            foreach (string time in groupTraining.Times)
            {
                Console.WriteLine($" - {time}");
            }
            Console.WriteLine();
        }

        public void OutputVacantPlaces(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            GroupTraining groupTraining = groupTrainingList.FirstOrDefault(training => training.Type.Equals(selectedGroupTraining));


            foreach (var entry in groupTraining.VacantPlaces)
            {
                string trainingName = entry.Key;
                int[] vacantCurrentMax = entry.Value;
                Console.WriteLine($" - {trainingName} {vacantCurrentMax[0]}/{vacantCurrentMax[1]}");
            }
        }
    }
}
