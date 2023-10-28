namespace TP_lab2
{
    internal class SelectedGroupTrainingReader
    {
        public Dictionary<string, int[]> LoadVacantPlacesOfSelectedTrainingFromFile(string selectedGroupTrainingFilePath)
        {
            string[] allLines = File.ReadAllLines(selectedGroupTrainingFilePath);
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
