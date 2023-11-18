using TP_lab2;

internal class Program
{
    public static void Main(string[] args)
    {
        TariffsUserInteraction tariffUserInteraction = new TariffsUserInteraction(args[0]);
        TariffObject tariffObject = new TariffObject();
        MassageObject massageObject = new MassageObject();

        // Вывод приветствия и тарифов
        tariffUserInteraction.OutputTarifs();

        // Получение выбранного тарифа от пользователя
        string selectedTariff = tariffUserInteraction.GetSelectedTraifInput();
        tariffObject.typeOfTariff = selectedTariff;

        // Вывод месяцев и цен для выбранного тарифа
        tariffUserInteraction.OutputMonthsAndPrices(selectedTariff);

        // Получение выбранной длительности (мес) от пользователя
        string selectedDurationOfTariff = tariffUserInteraction.GetSelectedMonthInput();
        tariffObject.durationOfTariff = selectedDurationOfTariff;

        // Получение цены для выбранного тарифа в зависимости от длительнсти
        string priceOfSelectedDuration = tariffUserInteraction.GetPriceOfSelectedMonth(selectedTariff, selectedDurationOfTariff).ToString();
        tariffObject.priseOfTariff = priceOfSelectedDuration;

        SelectedGroupTrainingObject selectedGroupTrainingObject = new SelectedGroupTrainingObject();// args[4]);
        BusinessLogic bl = new BusinessLogic();// selectedTariff, args[4]);
        ExtraServicesFlow extraServices = new ExtraServicesFlow(selectedGroupTrainingObject, massageObject);

        // Выбор групповых тренировок, если они доступны
        if (bl.GroupTrainingsAreAvaliable(selectedTariff, args[1]))
        {
            string[] groupTrainingFilePaths = new string[] { args[3], args[4], args[5], args[6], args[7] };
            extraServices.ChoosingGroupTrainings(groupTrainingFilePaths);
        }

        // Выбор массажей, если они доступны
        if (bl.MassageIsAvaliable(selectedTariff, args[1]))
        {
            string[] massageFilePaths = new string[] { args[8], args[9], args[10] };
            extraServices.ChoosingMassage(massageFilePaths);
        }

        // Генерация билета из собранных данных
        Ticket ticket = new Ticket();
        GroupTraining groupTrain = new GroupTraining();// "strength.json");
        ticket.TypeTicketToFile(tariffObject, selectedGroupTrainingObject, massageObject);
    }
}