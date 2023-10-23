namespace TP_lab2
{
    internal class ExtraServices
    {
        private Dictionary<string, List<bool>> extraServicesDictionary = new Dictionary<string, List<bool>>();

        public void LoadExtraServicesFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines($"{filePath}.txt");

            bool labels = true;

            foreach (string i in allLines)
            {
                if (labels) { labels = false; }
                else
                {
                    string[] line = i.Split(",");

                    if (!extraServicesDictionary.ContainsKey(line[0]))
                    {
                        extraServicesDictionary[line[0]] = new List<bool>();
                    }

                    for (int j = 1; j < line.Length; j++)
                    {
                        extraServicesDictionary[line[0]].Add(Convert.ToBoolean(line[j]));
                    }
                }
            }
        }

        public bool GroupTrainingsAreAvaliable(string selectedTariff)
        {
            return extraServicesDictionary[selectedTariff][0];
        }

        public bool MassageIsAvaliable(string selectedTariff)
        {
            return extraServicesDictionary[selectedTariff][1];
        }

        public List<string> ChoosingGroupTrainings(List<string> dataEnteredByUser)
        {
            GroupTrainingsInformation info = new GroupTrainingsInformation();
            GroupTrainingsUserInteraction userInteraction = new GroupTrainingsUserInteraction();

            while (true)
            {
                if (userInteraction.GetNeedForGroupTraining())
                {
                    //Вывод типов групповых тренировок
                    userInteraction.OutputTypeOfGroupTrainings();

                    //Получить от пользователя тип групповой тренировки
                    string selectedGroupTraining = userInteraction.GetSelectedGroupTrainingInput();

                    //SelectedGroupTrainingInfo selectedGroupTrainingInfo = new SelectedGroupTrainingInfo($"{selectedGroupTraining}.txt");

                    SelectedGroupTrainUserInteraction selectedGroupTrainInteraction = new SelectedGroupTrainUserInteraction();

                    //Вывод доступного времени для выбранного типа тренировки
                    userInteraction.OutputTimeOfGroupTrainings(selectedGroupTraining);

                    //Получить от пользователя времени тренирвки
                    string timeOfSelectedTraining = userInteraction.GetSelectedTimeInput(selectedGroupTraining);

                    ////Чтение из файла кол-во свободных мест для выбранной тренировки
                    //selectedGroupTrainingInfo.LoadVacantPlacesOfSelectedTrainingFromFile(selectedGroupTraining);

                    //Вывод кол-во свободных мест для выбранной тренировки
                    selectedGroupTrainInteraction.OutputVacantPlacesOfSelectedTraining(selectedGroupTraining);

                    //Получить от пользователя подтип групповой тренировки
                    string selectedSubtype = selectedGroupTrainInteraction.GetSelectedSubtypeInput(selectedGroupTraining);

                    dataEnteredByUser.Add(selectedSubtype);
                    dataEnteredByUser.Add(timeOfSelectedTraining);

                    return dataEnteredByUser;
                }
                else
                {
                    dataEnteredByUser.Add("-");
                    dataEnteredByUser.Add("-");

                    return dataEnteredByUser;
                }
            }
        }

        public List<string> ChoosingMassage(List<string> dataEnteredByUser)
        {
            MassageReader reader = new MassageReader();
            MassageUserInteraction userInteraction = new MassageUserInteraction();

            if (userInteraction.GetNeedForMassage())
            {
                //Чтение из файла видов массажа
                reader.LoadMassageTypesFromFile("massage.txt");
                //Вывод видов массажа
                userInteraction.OutputTypesOfMassage();
                //Получить от пользователя выбранный вид массажа
                string selectedTypeOfMassage = userInteraction.GetSelectedMassageInput();
                dataEnteredByUser.Add(selectedTypeOfMassage);
            }
            else { dataEnteredByUser.Add("-"); }

            return dataEnteredByUser;
        }
    }
}
