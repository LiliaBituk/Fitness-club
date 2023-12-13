
namespace BusinessLogic
{
    public class FitnessClub
    {
        public Dictionary<string, List<int>> tariffs;
        public List<string> months;

        public Dictionary<string, List<bool>> ExtraServices;

        public List<GroupTraining> groupTrainingList = new List<GroupTraining>();

        public List<Massage> massageList = new List<Massage>(); 

        public bool GroupTrainingsAreAvaliable(string selectedTariff)
        {
            return ExtraServices[selectedTariff][0];
        }

        public bool MassageIsAvaliable(string selectedTariff)
        {
            return ExtraServices[selectedTariff][1];
        }        
    }
}
