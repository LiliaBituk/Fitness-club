namespace TP_lab2
{
    internal class BusinessLogic
    {
        public bool CheckVacantPlaceInGroupTraining(Dictionary<string, int[]> vacantPlacesOfSelectedGroupTraining, string selectedSubtype)
        {
            return vacantPlacesOfSelectedGroupTraining[selectedSubtype][0] < vacantPlacesOfSelectedGroupTraining[selectedSubtype][1];
        }
    }
}
