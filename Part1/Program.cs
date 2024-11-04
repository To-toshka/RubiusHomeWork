using Lesson2;

Console.WriteLine("Вас приветствует личный помошник");
Console.WriteLine("Чтобы запустить сервис 'Проверка года на високосность' введите '1'");
Console.WriteLine("Чтобы запустить сервис 'Подсчета бюджета' введите '2'");
Console.WriteLine("Чтобы завершить работу приложения введите '3'");
string serviceCod = "";
void ChoiceService ()
{
    string? input = Console.ReadLine();
    if (input == null || input == "")
    {
        Console.WriteLine("Ошибка: Данные не введены");
        ChoiceService();
        return;
    }
    else if (input == "1")
    {
        var yearChecker = new CheckYears();
        yearChecker.CheckRun();
        return;
    }
    else if (input == "2")
    {
        var budgetCalculating = new BudgetCalculating();
        budgetCalculating.RunCalculating();
    }
    else if (input == "3")
    {
        Console.WriteLine("Пока, до новых встречь");
    }
    else
    {
        Console.WriteLine("Ошибка: Введено не число");
        ChoiceService();
        return;
    }
}
ChoiceService();
