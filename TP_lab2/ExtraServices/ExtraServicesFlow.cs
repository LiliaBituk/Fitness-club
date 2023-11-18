
namespace TP_lab2
{
    internal class ExtraServicesFlow
    {
        SelectedGroupTrainingObject selectedGroupTrainingObject;
        MassageObject massageObject;

        public ExtraServicesFlow(SelectedGroupTrainingObject selectedGroupTrainingObj, MassageObject massageObj)
        {
            selectedGroupTrainingObject = selectedGroupTrainingObj;
            massageObject = massageObj;
        }

        public void ChoosingGroupTrainings(string[] groupTrainingFilePaths)
        {

            GroupTrainingsUserInteraction groupTrainingUserInteraction = new GroupTrainingsUserInteraction(groupTrainingFilePaths);
            
            if (groupTrainingUserInteraction.GetNeedForGroupTraining())
            {
                //Вывод типов групповых тренировок
                groupTrainingUserInteraction.OutputTypeOfGroupTrainings();

                //Получить от пользователя тип групповой тренировки
                string selectedGroupTraining = groupTrainingUserInteraction.GetSelectedGroupTrainingInput();

                //Вывод доступного времени для выбранного типа тренировки
                groupTrainingUserInteraction.OutputTimeOfGroupTrainings(selectedGroupTraining);

                //Получить от пользователя времени тренирвки
                string timeOfSelectedTraining = groupTrainingUserInteraction.GetSelectedTimeInput(selectedGroupTraining);

                //Вывод кол-во свободных мест для выбранной тренировки
                groupTrainingUserInteraction.OutputVacantPlaces(selectedGroupTraining);

                //Получить от пользователя подтип групповой тренировки
                string selectedSubtype = groupTrainingUserInteraction.GetSelectedSubtypeInput(selectedGroupTraining);

                selectedGroupTrainingObject.subtype = selectedSubtype;
                selectedGroupTrainingObject.time = timeOfSelectedTraining;
            }
        }

        public void ChoosingMassage(string[] massageFilePath)
        {
            MassageUserInteraction userInteraction = new MassageUserInteraction(massageFilePath);

            if (userInteraction.GetNeedForMassage())
            {
                //Вывод видов массажа
                userInteraction.OutputTypesOfMassage();

                //Получить от пользователя выбранный вид массажа
                string selectedTypeOfMassage = userInteraction.GetSelectedMassageInput();
                massageObject.Type = selectedTypeOfMassage;

                //Вывод доступных массажистов
                userInteraction.OutputMastersOfMassage(selectedTypeOfMassage);

                //Получить от пользователя выбранного массажиста
                massageObject.Master = userInteraction.GetMasterOfMassage(selectedTypeOfMassage);

                //Вывод доступного времени
                userInteraction.OutputTimesOfMassage(selectedTypeOfMassage);

                //Получить от пользователя выбранное время
                massageObject.Time = userInteraction.GetTimeOfMassage(selectedTypeOfMassage);                
            }
        }
    }
}
