
namespace TP_lab2
{
    internal class BusinessLogic
    {
        private VacantPlacesInGroupTrainingsInformation vacantPlacesInGroupTrainingsInfo = new VacantPlacesInGroupTrainingsInformation();
        private VacantPlacesInGroupTrainingsReader vacantPlacesInGroupTrainingsReader;

        public BusinessLogic(string AvailablePlaceInGroupTrainingsFilePath)
        {
            vacantPlacesInGroupTrainingsReader = new VacantPlacesInGroupTrainingsReader(AvailablePlaceInGroupTrainingsFilePath);
            vacantPlacesInGroupTrainingsInfo = vacantPlacesInGroupTrainingsReader.VacantPlacesData.FirstOrDefault();
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

        public bool CheckStrengthIsAvailable(string selectedSubtype)
        {
            return vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Strength.ContainsKey(selectedSubtype)
                && vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Strength[selectedSubtype][0] < vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Strength[selectedSubtype][1];
        }

        public bool CheckAerobicIsAvailable(string selectedSubtype)
        {
            return vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Aerobics.ContainsKey(selectedSubtype)
                && vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Aerobics[selectedSubtype][0] < vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Aerobics[selectedSubtype][1];
        }

        public bool CheckDanceIsAvailable(string selectedSubtype)
        {
            return vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Dance.ContainsKey(selectedSubtype)
                && vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Dance[selectedSubtype][0] < vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Dance[selectedSubtype][1];
        }

        public bool CheckLowIntensityIsAvailable(string selectedSubtype)
        {
            return vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.LowIntensity.ContainsKey(selectedSubtype)
                && vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.LowIntensity[selectedSubtype][0] < vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.LowIntensity[selectedSubtype][1];
        }

        public bool CheckMixedIsAvailable(string selectedSubtype)
        {
            return vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Mixed.ContainsKey(selectedSubtype)
                && vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Mixed[selectedSubtype][0] < vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Mixed[selectedSubtype][1];
        }
    }
}
