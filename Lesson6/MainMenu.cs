using Lesson6.Models;

namespace Lesson6
{
    /// <summary>
    /// Класс описывающий сервис Главного меню программы.
    /// </summary>
    public class MainMenu
    {     
        /// <summary>
        /// Функция запуска программы и Главного меню.
        /// </summary>
        public static void Start ()
        {
            try
            {
                bool isProgrameWork = true;
                Menu mainMenu = new() { Items = ["Запустить сервис обработки файлов", "Запустить сервис регистрации граждан", "Выход"] };
                Console.WriteLine("Добро пожаловать в главное меню");
                while (isProgrameWork)
                {
                    mainMenu.ShowMenu();
                    string? inputNumber = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputNumber))
                    {
                        Console.WriteLine("Ошибка: Вы не внесли номер действия!");
                        Console.WriteLine("");
                        continue;
                    }
                    if (inputNumber == "1")
                    {
                        Console.WriteLine("");
                        FileService fileServise = new();
                        isProgrameWork = fileServise.StartService();
                        continue;
                    }
                    if (inputNumber == "2")
                    {
                        Console.WriteLine("");
                        RegistrationService regService = new();
                        isProgrameWork = regService.StartService();
                        continue;
                    }
                    if (inputNumber == "3")
                    {
                        Console.WriteLine("Спасибо, что воспользовались нашими сервисами!");
                        Console.WriteLine("До новых встреч!");
                        isProgrameWork = false;
                        continue;
                    }
                    Console.WriteLine("Команда не распознана!");
                    Console.WriteLine("");
                    continue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
