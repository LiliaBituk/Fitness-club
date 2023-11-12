
namespace TP_lab2
{
    internal class SelectedGroupTrainingObject
    {
        private string subtype { get; set; } = "-";
        private string time { get; set; } = "-";

        public VacantPlacesInGroupTrainingsInformation vacantPlacesInGroupTrainingsInfo = new VacantPlacesInGroupTrainingsInformation();
        private VacantPlacesInGroupTrainingsReader vacantPlacesInGroupTrainingsReader;

        public SelectedGroupTrainingObject(string AvailablePlaceInGroupTrainingsFilePath)
        {
            vacantPlacesInGroupTrainingsReader = new VacantPlacesInGroupTrainingsReader(AvailablePlaceInGroupTrainingsFilePath);
            vacantPlacesInGroupTrainingsInfo = vacantPlacesInGroupTrainingsReader.VacantPlacesData.FirstOrDefault();
        }

        public string SubtypeOfSelectedGroupTraining { get { return subtype; } set { subtype = value; } }
        

        public string TimeOfSelectedGroupTraining { get { return time; } set { time = value; } }

    }
}
