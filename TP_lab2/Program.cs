using TP_lab2;
using BusinessLogic;
using DataAccess;

internal class Program
{
    /// <summary>
    /// Flow-класс для для user-interaction-методов, используемых для привестсвия пользователя и подбора тарифа
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        string[] groupTrainingFilePaths = new string[] { args[3], args[4], args[5], args[6], args[7] };
        string[] massageFilePaths = new string[] { args[8], args[9], args[10] };

        FitnessClub fitnessClub = new FitnessClub();

        TariffsReader readerTariffs = new TariffsReader(args[0]);
        readerTariffs.ReadTariffs(fitnessClub);

        ExtraServicesReader readerExtraServices = new ExtraServicesReader(args[1]);
        readerExtraServices.ReadExtraServices(fitnessClub);

        GroupTrainingReader groupTrainingReader = new GroupTrainingReader();
        groupTrainingReader.ReadGroupTrainings(groupTrainingFilePaths, fitnessClub);

        MassageReader massageReader = new MassageReader();
        massageReader.ReadMassage(massageFilePaths, fitnessClub);

        TariffsUserInteraction tariffUserInteraction = new TariffsUserInteraction(fitnessClub.tariffs, fitnessClub.months);
        TariffSelectedByUser tariffObject = new TariffSelectedByUser();

        tariffUserInteraction.OutputTarifs();

        string selectedTariff = tariffUserInteraction.GetSelectedTraifInput();
        tariffObject.typeOfTariff = selectedTariff;

        tariffUserInteraction.OutputMonthsAndPrices(selectedTariff);

        string selectedDurationOfTariff = tariffUserInteraction.GetSelectedMonthInput();
        tariffObject.durationOfTariff = selectedDurationOfTariff;

        string priceOfSelectedDuration = tariffUserInteraction.GetPriceOfSelectedMonth(selectedTariff, selectedDurationOfTariff).ToString();
        tariffObject.priseOfTariff = priceOfSelectedDuration;

        GroupTrainingSelectedByUser selectedGroupTrainingObject = new GroupTrainingSelectedByUser();
        MassageSelectedByUser massageObject = new MassageSelectedByUser();
        ExtraServicesFlow extraServices = new ExtraServicesFlow(selectedGroupTrainingObject, massageObject);

        if (fitnessClub.GroupTrainingsAreAvaliable(selectedTariff))
        {
            extraServices.ChoosingGroupTrainings(fitnessClub.groupTrainingList);
        }

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