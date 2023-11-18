
namespace TP_lab2
{
    public class GroupTraining
    {
        public string Type { get; set; }

        public List<string> Times { get; set; }

        public Dictionary<string, int[]> VacantPlaces { get; set; }

        //bool HasVacantPlaces(string subtype)
        //{
        //    return VacantPlaces.ContainsKey(subtype)
        //        && VacantPlaces[subtype][0] < VacantPlaces[subtype][1];
        //}

        //bool IsTimeAvailable(string time)
        //{
        //    return Times.Contains(time);
        //}

        //bool SelectedTypeExists(string selectedType)
        //{
        //    return Type == selectedType;
        //}

    }
}
