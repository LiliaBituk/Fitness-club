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
            GroupTrainings groupTrainings = new GroupTrainings();
            groupTrainings.LoadGroupTrainingsTypesFromFile("type_of_group_trainings");
            groupTrainings.LoadTimeOfGroupTrainingsFromFile("available_time");

            while (true)
            {
                if (groupTrainings.GetNeedForGroupTraining())
                {
                    //Вывод типов групповых тренировок
                    groupTrainings.OutputTypeOfGroupTrainings();

                    //Получить от пользователя тип групповой тренировки
                    string selectedGroupTraining = groupTrainings.GetSelectedGroupTrainingInput();

                    //Вывод доступного времени для выбранного типа тренировки
                    groupTrainings.OutputTimeOfGroupTrainings(selectedGroupTraining);

                    //Получить от пользователя времени тренирвки
                    string timeOfSelectedTraining = groupTrainings.GetSelectedTimeInput(selectedGroupTraining);

                    //Чтение из файла кол-во свободных мест для выбранной тренировки
                    groupTrainings.LoadVacantPlacesOfSelectedTrainingFromFile(selectedGroupTraining);

                    //Вывод кол-во свободных мест для выбранной тренировки
                    groupTrainings.OutputVacantPlacesOfSelectedTraining(selectedGroupTraining);

                    //Получить от пользователя подтип групповой тренировки
                    string selectedSubtype = groupTrainings.GetSelectedSubtypeInput(selectedGroupTraining);

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
            Massage massage = new Massage();

            if (massage.GetNeedForMassage())
            {
                //Чтение из файла видов массажа
                massage.LoadMassageTypesFromFile("massage");
                //Вывод видов массажа
                massage.OutputTypesOfMassage();
                //Получить от пользователя выбранный вид массажа
                string selectedTypeOfMassage = massage.GetSelectedMassageInput();
                dataEnteredByUser.Add(selectedTypeOfMassage);
            }
            else { dataEnteredByUser.Add("-"); }

            return dataEnteredByUser;
        }
    }
}
