namespace Lesson10
{
    /// <summary>
    /// Класс описывающий главное меню сервиса.
    /// </summary>
    /// <param name="userServise">Объект класса UserServise.</param>
    public class Menu(UserServise userServise)
    {
        /// <summary>
        /// Объект класса UserServise полученый из конструктора класса.
        /// </summary>
        UserServise _userServise = userServise;
        /// <summary>
        /// Элементы Меню.
        /// </summary>
        string[] MenuItems = ["1. Показать всех пользователей", "2. Поиск пользователя по id", "3. Добавить пользователя", 
            "4. Редактировать пользователя", "5. Удалить пользователя", "6. Выход"];

        /// <summary>
        /// Метод запуска Главного меню и логики сервиса.
        /// </summary>
        public void ShowMenu()
        {
            try
            {
                bool isProgrameWork = true;
                Console.WriteLine("Вас приветствует сервис базы данных пользователей.");                
                while (isProgrameWork)
                {
                    ShowMenuItems(); 
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
                        _userServise.ShowUsers();
                        continue;
                    }
                    if (inputNumber == "2")
                    {
                        Console.WriteLine("");
                        _userServise.FindUser();
                        continue;
                    }
                    if (inputNumber == "3")
                    {
                        Console.WriteLine("");
                        _userServise.AddUser();
                        continue;
                    }
                    if (inputNumber == "4")
                    {
                        Console.WriteLine("");
                        _userServise.UpdateUser();
                        continue;
                    }
                    if (inputNumber == "5")
                    {
                        Console.WriteLine("");
                        _userServise.DeleteUser();
                        continue;
                    }
                    if (inputNumber == "6")
                    {
                        Console.WriteLine("Спасибо, что воспользовались нашим сервисом!");
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

        /// <summary>
        /// Метод вывода элементов Главного меню в консоль.
        /// </summary>
        private void ShowMenuItems()
        {
            Console.WriteLine("Выберите действие указав его номер:");
            foreach (var item in MenuItems)
            {                
                Console.WriteLine(item);
            }
        }
    }
}
