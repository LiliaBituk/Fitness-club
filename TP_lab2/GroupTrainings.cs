namespace TP_lab2
{
    internal class GroupTrainings
    {
        private Dictionary<string, List<string>> groupTrainingTypes = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> timeOfGroupTrainings = new Dictionary<string, List<string>>();
        private Dictionary<string, int[]> vacantPlacesOfSelectedGroupTraining = new Dictionary<string, int[]>(); 

        public void LoadGroupTrainingsTypesFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines($"{filePath}.txt");

            bool labels = true;

            foreach (string i in allLines)
            {
                if (labels) { labels = false; }
                else
                {
                    string[] line = i.Split(",");

                    if (!groupTrainingTypes.ContainsKey(line[0]))
                    {
                        groupTrainingTypes[line[0]] = new List<string>();
                    }

                    for (int j = 1; j < line.Length; j++)
                    {
                        groupTrainingTypes[line[0]].Add(line[j]);
                    }
                }
            }
        }

        public void LoadTimeOfGroupTrainingsFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines($"{filePath}.txt");

            bool labels = true;

            foreach (string i in allLines)
            {
                if (labels) { labels = false; }
                else
                {
                    string[] line = i.Split(",");

                    if (!timeOfGroupTrainings.ContainsKey(line[0]))
                    {
                        timeOfGroupTrainings[line[0]] = new List<string>();
                    }

                    for (int j = 1; j < line.Length; j++)
                    {
                        timeOfGroupTrainings[line[0]].Add(line[j]);

                    }
                }
            }
        }

        public void LoadVacantPlacesOfSelectedTrainingFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines($"{filePath}.txt");

            bool labels = true;

            foreach (string i in allLines)
            {
                if (labels) { labels = false; }
                else
                {
                    string[] line = i.Split(",");

                    if (!vacantPlacesOfSelectedGroupTraining.ContainsKey(line[0]))
                    {
                        vacantPlacesOfSelectedGroupTraining[line[0]] = new int[2];
                    }

                    vacantPlacesOfSelectedGroupTraining[line[0]][0] = Convert.ToInt32(line[1]);
                    vacantPlacesOfSelectedGroupTraining[line[0]][1] = Convert.ToInt32(line[2]);
                }
            }
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
            while (!groupTrainingTypes.ContainsKey(selectedGroupTraining));

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
            while (!timeOfGroupTrainings[selectedGroupTraining].Contains(timeOfSelectedTraining));

            return timeOfSelectedTraining;
        }

        private bool CheckVacantPlace(string selectedSubtype)
        {
            return vacantPlacesOfSelectedGroupTraining[selectedSubtype][0] < vacantPlacesOfSelectedGroupTraining[selectedSubtype][1];
        }

        public string GetSelectedSubtypeInput(string selectedGroupTraining)
        {
            string selectedSubtype;
            do
            {
                Console.Write("Введите интересующий вид тренировок: ");
                selectedSubtype = GetInput();
                if (groupTrainingTypes[selectedGroupTraining].Contains(selectedSubtype) && CheckVacantPlace(selectedSubtype))
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

        public void OutputTypeOfGroupTrainings()
        {
            Console.WriteLine("У нас представлены следующие виды тренировок:");
            foreach (string key in groupTrainingTypes.Keys)
            {
                Console.WriteLine($" - {key}");
            }
        }

        public void OutputTimeOfGroupTrainings(string selectedGroupTraining)
        {
            Console.WriteLine("Доступное время:");
            foreach (string time in timeOfGroupTrainings[selectedGroupTraining])
            {
                Console.WriteLine($" - {time}");
            }
            Console.WriteLine();
        }

        public void OutputVacantPlacesOfSelectedTraining(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            foreach (string key in vacantPlacesOfSelectedGroupTraining.Keys)
            {
                Console.WriteLine($" - {key} {vacantPlacesOfSelectedGroupTraining[key][0]}/{vacantPlacesOfSelectedGroupTraining[key][1]}");
            }
        }
    }
}
