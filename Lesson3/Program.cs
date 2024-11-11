using Lesson3;

Console.WriteLine("Вас приветствует личный помошник");
Console.WriteLine("Чтобы запустить сервис 'Расчет НДФЛ' введите '1'");
Console.WriteLine("Чтобы запустить сервис 'Складской учет' введите '2'");
Console.WriteLine("Чтобы завершить работу приложения введите '3'");
void ChoiceService()
{
    string? input = Console.ReadLine();
    switch (input)
    {
        case "1":
            var taxervice = new TaxService();
            taxervice.TaxCalculation();
            break;
        case "2":
            var warehouseService = new WarehouseService();
            warehouseService.StartService();
            break;
        case "3":
            Console.WriteLine("Пока, до новых встречь");
            break;
        default:
            Console.WriteLine("Код команды не определен");
            ChoiceService();
            break;
    }
}
ChoiceService();