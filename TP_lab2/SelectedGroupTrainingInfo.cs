namespace TP_lab2
{
    internal class SelectedGroupTrainingInfo
    {
        public Dictionary<string, int[]> vacantPlacesOfSelectedGroupTraining;

        public SelectedGroupTrainingInfo(string filePath) 
        {
            GroupTrainingsReader reader = new GroupTrainingsReader();
            vacantPlacesOfSelectedGroupTraining = reader.LoadVacantPlacesOfSelectedTrainingFromFile(filePath);
        }
    }
}
