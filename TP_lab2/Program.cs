using TP_lab2;

internal class Program
{
    public static void Main(string[] args)
    {
        string[] groupTrainingFilePaths = new string[] { args[3], args[4], args[5], args[6], args[7] };
        string[] massageFilePaths = new string[] { args[8], args[9], args[10] };

        FitnessClub fitnessClub = new FitnessClub();

        // read info about tariffs
        TariffsReader readerTariffs = new TariffsReader(args[0]);

        if (readerTariffs.TariffsInfo.Count > 0)
        {
            var info = readerTariffs.TariffsInfo[0];
            fitnessClub.tariffs = info.tariffs;
            fitnessClub.months = info.months;
        }

        // read info about extra services
        ExtraServicesReader readerExtraServices = new ExtraServicesReader(args[1]);
        if (readerExtraServices.ExtraServicesInfo.Count > 0)
        {
            var info = readerExtraServices.ExtraServicesInfo[0];
            fitnessClub.ExtraServices = info.ExtraServices;
        }

        // read info about group trainings
        foreach (string file in groupTrainingFilePaths)
        {
            GroupTrainingReader reader = new GroupTrainingReader();
            GroupTraining groupTrainig = reader.Read(file);
            fitnessClub.groupTrainingList.Add(groupTrainig);
        }

        // read info about massages
        foreach (string file in massageFilePaths)
        {
            MassageReader readerMassage = new MassageReader();
            Massage massage = readerMassage.Read(file);
            fitnessClub.massageList.Add(massage);
        }

        TariffsUserInteraction tariffUserInteraction = new TariffsUserInteraction(fitnessClub.tariffs, fitnessClub.months);
        TariffSelectedByUser tariffObject = new TariffSelectedByUser();

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

        GroupTrainingSelectedByUser selectedGroupTrainingObject = new GroupTrainingSelectedByUser();
        MassageSelectedByUser massageObject = new MassageSelectedByUser();
        ExtraServicesFlow extraServices = new ExtraServicesFlow(selectedGroupTrainingObject, massageObject);

        // Выбор групповых тренировок, если они доступны
        if (fitnessClub.GroupTrainingsAreAvaliable(selectedTariff))
        {
            extraServices.ChoosingGroupTrainings(fitnessClub.groupTrainingList);
        }

        // Выбор массажей, если они доступны
        if (fitnessClub.MassageIsAvaliable(selectedTariff))
        {
            extraServices.ChoosingMassage(fitnessClub.massageList);
        }

        // Генерация билета из собранных данных
        TicketGenerator ticket = new TicketGenerator();
        ticket.TypeTicketToFile(tariffObject, selectedGroupTrainingObject, massageObject);
        Console.WriteLine("Спасибо за покупку! Чек отправлен на почту.");
    }
}