namespace TP_lab2
{
    internal class GroupTrainingsReader
    {
        public Dictionary<string, List<string>> LoadGroupTrainingsTypesFromFile(string groupTrainingsFilePath)
        {
            string[] allLines = File.ReadAllLines(groupTrainingsFilePath);
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

        public Dictionary<string, List<string>> LoadTimeOfGroupTrainingsFromFile(string groupTrainingsTimeFilePath)
        {
            string[] allLines = File.ReadAllLines(groupTrainingsTimeFilePath);
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
    }
}
