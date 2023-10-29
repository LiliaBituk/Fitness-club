
namespace TP_lab2
{
    internal class GroupTrainingsInformation
    {
        public Dictionary<string, List<string>> typeOfGroupTrainings { get; set; }
        public Dictionary<string, List<string>> timeOfGroupTrainings { get; set; }
        
        public GroupTrainingsInformation(string groupTrainingFilePath) 
        {
            GroupTrainingsReader reader = new GroupTrainingsReader(groupTrainingFilePath);

            if (reader.GroupTrainingInfo.Count > 0)
            {
                var groupTraining = reader.GroupTrainingInfo[0];

                typeOfGroupTrainings = groupTraining.typeOfGroupTrainings;
                timeOfGroupTrainings = groupTraining.timeOfGroupTrainings;
            }
        }
    } 
}

        //public Dictionary<string, List<string>> typeOfGroupTrainings;
        //public Dictionary<string, List<string>> timeOfGroupTrainings;

        //public GroupTrainingsInformation(string trainingFilePath, string timeFilePath)
        //{
        //    GroupTrainingsReader reader = new GroupTrainingsReader();

        //    groupTrainingTypes = reader.LoadGroupTrainingsTypesFromFile(trainingFilePath);
        //    timeOfGroupTrainings = reader.LoadTimeOfGroupTrainingsFromFile(timeFilePath);
        //}


