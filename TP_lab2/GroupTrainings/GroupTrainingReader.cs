using Newtonsoft.Json;

namespace TP_lab2
{
    internal class GroupTrainingReader
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
    }
}
