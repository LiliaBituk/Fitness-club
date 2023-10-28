namespace TP_lab2
{
    internal class GroupTrainingsInformation
    {
        public Dictionary<string, List<string>> groupTrainingTypes;
        public Dictionary<string, List<string>> timeOfGroupTrainings; 


        public GroupTrainingsInformation(string trainingFilePath, string timeFilePath)
        {
            GroupTrainingsReader reader = new GroupTrainingsReader();

            groupTrainingTypes = reader.LoadGroupTrainingsTypesFromFile(trainingFilePath);
            timeOfGroupTrainings = reader.LoadTimeOfGroupTrainingsFromFile(timeFilePath);
        }
       
    }
}
