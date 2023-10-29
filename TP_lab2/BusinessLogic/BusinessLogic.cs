namespace TP_lab2
{
    internal class BusinessLogic
    {
        //public ExtraServicesInformation info;
        //public BusinessLogic(string extraServicesFilePath) 
        //{
        //    info = new ExtraServicesInformation(extraServicesFilePath);
        //}
        public bool CheckVacantPlaceInGroupTraining(Dictionary<string, int[]> vacantPlacesOfSelectedGroupTraining, string selectedSubtype)
        {
            return vacantPlacesOfSelectedGroupTraining[selectedSubtype][0] < vacantPlacesOfSelectedGroupTraining[selectedSubtype][1];
        }

        public bool GroupTrainingsAreAvaliable(string selectedTariff, string extraServicesFilePath)
        {
            ExtraServicesInformation info = new ExtraServicesInformation(extraServicesFilePath);

            return info.ExtraServices[selectedTariff][0];

        }

        public bool MassageIsAvaliable(string selectedTariff, string extraServicesFilePath)
        {
 
            ExtraServicesInformation info = new ExtraServicesInformation(extraServicesFilePath);

            return info.ExtraServices[selectedTariff][1];

        }
    }
}
