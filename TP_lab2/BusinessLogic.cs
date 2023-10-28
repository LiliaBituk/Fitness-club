namespace TP_lab2
{
    internal class BusinessLogic
    {
        public bool CheckVacantPlaceInGroupTraining(Dictionary<string, int[]> vacantPlacesOfSelectedGroupTraining, string selectedSubtype)
        {
            return vacantPlacesOfSelectedGroupTraining[selectedSubtype][0] < vacantPlacesOfSelectedGroupTraining[selectedSubtype][1];
        }

        public bool GroupTrainingsAreAvaliable(string selectedTariff, string filePath)
        {
            ExtraServicesInformation info = new ExtraServicesInformation(filePath);
            return info.extraServicesDictionary[selectedTariff][0];
        }

        public bool MassageIsAvaliable(string selectedTariff, string filePath)
        {
            ExtraServicesInformation info = new ExtraServicesInformation(filePath);
            return info.extraServicesDictionary[selectedTariff][1];
        }
    }
}
