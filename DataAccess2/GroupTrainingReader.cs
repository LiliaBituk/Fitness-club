using Newtonsoft.Json;
using BusinessLogic;

namespace DataAccess
{
    public class GroupTrainingReader
    {
        public GroupTraining Read(string groupTrainingFilePath)
        {
            if (File.Exists(groupTrainingFilePath))
            {
                var json = File.ReadAllText(groupTrainingFilePath);
                GroupTraining gtJson = JsonConvert.DeserializeObject<GroupTraining>(json);

                return gtJson;
            }

            return new GroupTraining();
        }

        public void ReadGroupTrainings(string[] groupTrainingFilePaths, FitnessClub fitnessClub)
        {
            foreach (string file in groupTrainingFilePaths)
            {
                //GroupTrainingReader reader = new GroupTrainingReader();
                GroupTraining groupTrainig = Read(file);
                fitnessClub.groupTrainingList.Add(groupTrainig);
            }
        }
    }
}
