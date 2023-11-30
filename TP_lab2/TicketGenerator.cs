
namespace TP_lab2
{
    internal class TicketGenerator
    {
        public void TypeTicketToFile(TariffSelectedByUser tariff,
                                    GroupTrainingSelectedByUser selectedGroupTrainingObject,
                                    MassageSelectedByUser massage)
        {
            using (StreamWriter sw = new StreamWriter("ticket.txt", false))
            {
                sw.Write($"Тариф: {tariff.typeOfTariff}\n" +
                        $"Абонемент на {tariff.durationOfTariff} мес\n" +
                        $"Стоимость: {tariff.priseOfTariff} руб\n" +
                        $"Тип тренировки: {selectedGroupTrainingObject.subtype}\n" +
                        $"Время тренировки: {selectedGroupTrainingObject.time}\n" +
                        $"Массаж: {massage.Type}\n" +
                        $"Массажист: {massage.Master}\n" +
                        $"Время массажа: {massage.Time}");
            }
        }
    }
}
