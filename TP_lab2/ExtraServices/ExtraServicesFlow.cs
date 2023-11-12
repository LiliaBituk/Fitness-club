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

        public void ChoosingGroupTrainings(string groupTrainingFilePath, string vacantPlacesOfGroupTrainingFilePath)
        {
            //GroupTrainingsUserInteraction userInteraction = new GroupTrainingsUserInteraction(groupTrainingFilePath);
            //GroupTraining gt = new GroupTraining();
            GroupTrainingsUserInteraction groupTrainingUserInteraction = new GroupTrainingsUserInteraction(groupTrainingFilePath);//, vacantPlacesOfGroupTrainingFilePath, gt);
            VacantPlacesGroupTrainingUserInteraction vacantPlacesUserInteraction = new VacantPlacesGroupTrainingUserInteraction(vacantPlacesOfGroupTrainingFilePath);
            if (groupTrainingUserInteraction.GetNeedForGroupTraining())
            {
                //Вывод типов групповых тренировок
                groupTrainingUserInteraction.OutputTypeOfGroupTrainings();

                //Получить от пользователя тип групповой тренировки
                string selectedGroupTraining = groupTrainingUserInteraction.GetSelectedGroupTrainingInput();

                //SelectedGroupTrainUserInteraction selectedGroupTrainInteraction = new SelectedGroupTrainUserInteraction(groupTrainingFilePath);//, timeFilePath);

                //Вывод доступного времени для выбранного типа тренировки
                groupTrainingUserInteraction.OutputTimeOfGroupTrainings(selectedGroupTraining);

                //Получить от пользователя времени тренирвки
                string timeOfSelectedTraining = groupTrainingUserInteraction.GetSelectedTimeInput(selectedGroupTraining);

                //Вывод кол-во свободных мест для выбранной тренировки
                //userInteraction.OutputVacantPlacesOfSelectedTraining(selectedGroupTraining);//, selectedSubtype);
                vacantPlacesUserInteraction.OutputVacantPlacesOfSelectedTraining(selectedGroupTraining);

                //Получить от пользователя подтип групповой тренировки
                string selectedSubtype = vacantPlacesUserInteraction.GetSelectedSubtypeInput();

                selectedGroupTrainingObject.SubtypeOfSelectedGroupTraining = selectedSubtype;
                selectedGroupTrainingObject.TimeOfSelectedGroupTraining = timeOfSelectedTraining;
            }
        }

        public void ChoosingMassage(string massageFilePath)
        {
            MassageUserInteraction userInteraction = new MassageUserInteraction(massageFilePath);

            if (userInteraction.GetNeedForMassage())
            {
                //Вывод видов массажа
                userInteraction.OutputTypesOfMassage();
                //Получить от пользователя выбранный вид массажа
                string selectedTypeOfMassage = userInteraction.GetSelectedMassageInput();
                massageObject.typeOfMassage = selectedTypeOfMassage;
            }
        }
    }
}
