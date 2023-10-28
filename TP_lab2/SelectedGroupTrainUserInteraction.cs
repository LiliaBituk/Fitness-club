namespace TP_lab2
{
    internal class SelectedGroupTrainUserInteraction
    {
        GroupTrainingsInformation GroupTrainingInfo;
        BusinessLogic businessLogic = new BusinessLogic();

        public SelectedGroupTrainUserInteraction(string trainingFilePath, string timaFilePath)
        {
            GroupTrainingInfo = new GroupTrainingsInformation(trainingFilePath, timaFilePath);
        }

        private string GetInput()
        {
            while (true)
            {
                string enteredData = Console.ReadLine();
                if (enteredData != null && enteredData != "") { return enteredData; }
            }
        }

        public string GetSelectedSubtypeInput(string selectedGroupTraining)
        {
            string selectedSubtype;
            do
            {
                SelectedGroupTrainingInfo selectedGroupTrainingInfo = new SelectedGroupTrainingInfo(selectedGroupTraining + ".txt");
                Console.Write("Введите интересующий вид тренировок: ");
                selectedSubtype = GetInput();
                if (GroupTrainingInfo.groupTrainingTypes[selectedGroupTraining].Contains(selectedSubtype) &&
                    businessLogic.CheckVacantPlaceInGroupTraining(selectedGroupTrainingInfo.vacantPlacesOfSelectedGroupTraining, selectedSubtype))
                {
                    Console.WriteLine();
                    return selectedSubtype;
                }
                else
                {
                    Console.WriteLine("Выберите другой вид тренировки.");
                }
            }
            while (true);
        }

        public void OutputVacantPlacesOfSelectedTraining(string selectedGroupTraining)
        {
            SelectedGroupTrainingInfo selectedGroupTrainingInfo = new SelectedGroupTrainingInfo(selectedGroupTraining + ".txt");
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            foreach (string key in selectedGroupTrainingInfo.vacantPlacesOfSelectedGroupTraining.Keys)
            {
                Console.WriteLine($" - {key} {selectedGroupTrainingInfo.vacantPlacesOfSelectedGroupTraining[key][0]}/{selectedGroupTrainingInfo.vacantPlacesOfSelectedGroupTraining[key][1]}");
            }
        }
    }
}
