namespace TP_lab2
{
    internal class GroupTrainingsReader
    {
        public Dictionary<string, List<string>> LoadGroupTrainingsTypesFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines(filePath);
            bool labels = true;
            Dictionary<string, List<string>> groupTrainingTypes = new Dictionary<string, List<string>> ();

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

            return groupTrainingTypes;
        }

        public Dictionary<string, List<string>> LoadTimeOfGroupTrainingsFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines(filePath);
            Dictionary<string, List<string>> timeOfGroupTrainings = new Dictionary<string, List<string>>();
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

            return timeOfGroupTrainings;
        }

        public Dictionary<string, int[]> LoadVacantPlacesOfSelectedTrainingFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines(filePath);
            Dictionary<string, int[]> vacantPlacesOfSelectedGroupTraining = new Dictionary<string, int[]>();
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

            return vacantPlacesOfSelectedGroupTraining;
        }
    }
}
