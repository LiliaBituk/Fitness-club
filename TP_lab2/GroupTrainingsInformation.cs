namespace TP_lab2
{
    internal class GroupTrainingsInformation
    {
        public Dictionary<string, List<string>> groupTrainingTypes;
        public Dictionary<string, List<string>> timeOfGroupTrainings; 


        public GroupTrainingsInformation()
        {
            GroupTrainingsReader reader = new GroupTrainingsReader();

            groupTrainingTypes = reader.LoadGroupTrainingsTypesFromFile("type_of_group_trainings.txt");
            timeOfGroupTrainings = reader.LoadTimeOfGroupTrainingsFromFile("available_time.txt");
        }
       
    }
}
