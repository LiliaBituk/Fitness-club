
namespace TP_lab2
{
    internal class GroupTrainingsInformation
    {
        public Dictionary<string, List<string>> TypeOfGroupTrainings { get; set; }
        public Dictionary<string, List<string>> TimeOfGroupTrainings { get; set; }

        public GroupTrainingsInformation(string groupTrainingFilePath)
        {
            GroupTrainingsReader reader = new GroupTrainingsReader(groupTrainingFilePath);

            if (reader.GroupTrainingInfo.Count > 0)
            {
                var groupTraining = reader.GroupTrainingInfo[0];

                TypeOfGroupTrainings = groupTraining.TypeOfGroupTrainings;
                TimeOfGroupTrainings = groupTraining.TimeOfGroupTrainings;
            }


        }
    }
}
