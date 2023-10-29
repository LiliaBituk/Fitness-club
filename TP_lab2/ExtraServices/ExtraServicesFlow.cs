namespace TP_lab2
{
    internal class ExtraServicesFlow
    {
        //public ExtraServicesInformation info;
        //public ExtraServicesFlow(string extraServicesFilePath)
        //{
        //    info = new ExtraServicesInformation(extraServicesFilePath);
        //}

        public List<string> ChoosingGroupTrainings(string groupTrainingFilePath, List<string> dataEnteredByUser)
        {
            GroupTrainingsUserInteraction userInteraction = new GroupTrainingsUserInteraction(groupTrainingFilePath);//, timeFilePath);

            while (true)
            {
                if (userInteraction.GetNeedForGroupTraining())
                {
                    //Вывод типов групповых тренировок
                    userInteraction.OutputTypeOfGroupTrainings();

                    //Получить от пользователя тип групповой тренировки
                    string selectedGroupTraining = userInteraction.GetSelectedGroupTrainingInput();

                    SelectedGroupTrainUserInteraction selectedGroupTrainInteraction = new SelectedGroupTrainUserInteraction(groupTrainingFilePath);//, timeFilePath);

                    //Вывод доступного времени для выбранного типа тренировки
                    userInteraction.OutputTimeOfGroupTrainings(selectedGroupTraining);

                    //Получить от пользователя времени тренирвки
                    string timeOfSelectedTraining = userInteraction.GetSelectedTimeInput(selectedGroupTraining);

                    //Вывод кол-во свободных мест для выбранной тренировки
                    selectedGroupTrainInteraction.OutputVacantPlacesOfSelectedTraining(selectedGroupTraining);

                    //Получить от пользователя подтип групповой тренировки
                    string selectedSubtype = selectedGroupTrainInteraction.GetSelectedSubtypeInput(selectedGroupTraining);

                    dataEnteredByUser.Add(selectedSubtype);
                    dataEnteredByUser.Add(timeOfSelectedTraining);

                    return dataEnteredByUser;
                }
                else
                {
                    dataEnteredByUser.Add("-");
                    dataEnteredByUser.Add("-");

                    return dataEnteredByUser;
                }
            }
        }

        public List<string> ChoosingMassage(string massageFilePath, List<string> dataEnteredByUser)
        {
            MassageUserInteraction userInteraction = new MassageUserInteraction(massageFilePath);

            if (userInteraction.GetNeedForMassage())
            {
                //Вывод видов массажа
                userInteraction.OutputTypesOfMassage();
                //Получить от пользователя выбранный вид массажа
                string selectedTypeOfMassage = userInteraction.GetSelectedMassageInput();
                dataEnteredByUser.Add(selectedTypeOfMassage);
            }
            else { dataEnteredByUser.Add("-"); }

            return dataEnteredByUser;
        }
    }
}
