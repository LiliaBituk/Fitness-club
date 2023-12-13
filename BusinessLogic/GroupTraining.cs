
namespace BusinessLogic
{
    public class GroupTraining
    {
        public string Type { get; set; }

        public List<string> Times { get; set; }

        public Dictionary<string, int[]> VacantPlaces { get; set; }

        public bool selectedGroupTrainingIsAvailable(string selectedSubtype)
        {
            return VacantPlaces[selectedSubtype][0] < VacantPlaces[selectedSubtype][1];
        }
    }
}
