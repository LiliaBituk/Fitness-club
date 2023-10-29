using System.Text;
using TP_lab2;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        TariffsUserInteraction tariffs = new TariffsUserInteraction(args[0]);

        // Список для сбора пользовательской информации
        List<string> dataEnteredByUser = new List<string> { };

        // Вывод приветствие и тарифы
        tariffs.OutputTarifs();

        // Получение выбранного тарифа от пользователя
        string selectedTariff = tariffs.GetSelectedTraifInput();
        dataEnteredByUser.Add(selectedTariff);

        // Вывод месяцев и цен для выбранного тарифа
        tariffs.OutputMonthsAndPrices(selectedTariff);

        // Получение выбранного месяца от пользователя
        string selectedMonth = tariffs.GetSelectedMonthInput();
        dataEnteredByUser.Add(selectedMonth);

        // Получение цены для выбранного тарифа и месяца
        string priceOfSelectedMonth = tariffs.GetPriceOfSelectedMonth(selectedTariff, selectedMonth).ToString();
        dataEnteredByUser.Add(priceOfSelectedMonth);

        BusinessLogic bl = new BusinessLogic();
        ExtraServicesFlow extraServices = new ExtraServicesFlow();

        // Выбор групповых тренировок, если они доступны
        if (bl.GroupTrainingsAreAvaliable(selectedTariff, args[1]))
        {
            dataEnteredByUser = extraServices.ChoosingGroupTrainings(args[3], dataEnteredByUser);
        }

        // Выбор массажей, если они доступны
        if (bl.MassageIsAvaliable(selectedTariff, args[1]))
        {
            dataEnteredByUser = extraServices.ChoosingMassage(args[2], dataEnteredByUser);
        }

        // Генерация билета из собранных данных
        Ticket ticket = new Ticket();
        string[] data = ticket.GetArrayOfDefinedLength(dataEnteredByUser, 6);
        ticket.TypeTicketToFile(data);
        //}
        //catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}"); }
    }
}