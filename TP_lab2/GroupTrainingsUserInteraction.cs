namespace TP_lab2
{
    internal class GroupTrainingsUserInteraction
    {
        GroupTrainingsInformation info = new GroupTrainingsInformation();

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
            while (!info.groupTrainingTypes.ContainsKey(selectedGroupTraining));

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

        //public string GetSelectedSubtypeInput(string selectedGroupTraining)
        //{
        //    string selectedSubtype;
        //    do
        //    {
        //        SelectedGroupTrainingInfo selectedGroupTrainingInfo = new SelectedGroupTrainingInfo();
        //        Console.Write("Введите интересующий вид тренировок: ");
        //        selectedSubtype = GetInput();
        //        if (info.groupTrainingTypes[selectedGroupTraining].Contains(selectedSubtype) && 
        //            businessLogic.CheckVacantPlaceInGroupTraining(info.vacantPlacesOfSelectedGroupTraining, selectedSubtype))
        //        {
        //            Console.WriteLine();
        //            return selectedSubtype;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Выберите другой вид тренировки.");
        //        }
        //    }
        //    while (true);
        //}

        public void OutputTypeOfGroupTrainings()
        {
            Console.WriteLine("У нас представлены следующие виды тренировок:");
            foreach (string key in info.groupTrainingTypes.Keys)
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

        //public void OutputVacantPlacesOfSelectedTraining(string selectedGroupTraining)
        //{
        //    Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

        //    foreach (string key in info.vacantPlacesOfSelectedGroupTraining.Keys)
        //    {
        //        Console.WriteLine($" - {key} {info.vacantPlacesOfSelectedGroupTraining[key][0]}/{info.vacantPlacesOfSelectedGroupTraining[key][1]}");
        //    }
        //}
    }
}
