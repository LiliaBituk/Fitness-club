
namespace TP_lab2
{
    internal class GroupTrainingsInformation
    {
        public List<GroupTraining> groupTrainingList = new List<GroupTraining>();

        public GroupTrainingsInformation(string[] groupTrainingFilePaths)
        {
            foreach (string file in groupTrainingFilePaths)
            {
                GroupTrainingReader reader = new GroupTrainingReader();
                GroupTraining groupTrainig = reader.Read(file);
                groupTrainingList.Add(groupTrainig);
            }
        }
    }
}
