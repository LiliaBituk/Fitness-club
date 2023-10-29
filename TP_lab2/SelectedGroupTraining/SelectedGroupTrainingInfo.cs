namespace TP_lab2
{
    internal class SelectedGroupTrainingInfo
    {
        public Dictionary<string, int[]> vacantPlacesOfSelectedGroupTraining;

        public SelectedGroupTrainingInfo(string selectedGroupTrainingFilePath) 
        {
            SelectedGroupTrainingReader reader = new SelectedGroupTrainingReader();
            vacantPlacesOfSelectedGroupTraining = reader.LoadVacantPlacesOfSelectedTrainingFromFile(selectedGroupTrainingFilePath);
        }
    }
}
