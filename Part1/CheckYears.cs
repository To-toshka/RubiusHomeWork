namespace Lesson2
{
    internal class CheckYears
    {
        int? year = null;
        bool isWork = true;

        //Функция получения года от пользователя и проверки на соответствие условиям (В.Е. 04.11.2024)
        void GetYearFromUser()
        {
            Console.WriteLine("Введите год (от 0 до 30000) или 'стоп', чтобы остановить сервис");
            string? input = Console.ReadLine();
            if (input == null || input == "")
            {
                Console.WriteLine("Ошибка: Данные не введены");
                GetYearFromUser();
                return;
            }
            else if (input.ToLower() == "стоп")
            {
                Console.WriteLine("Работа сервиса остановлена");
                isWork = false;
                return;
            }
            else if (int.TryParse(input, out int result))
            {
                if (result < 0 || result > 30000)
                {
                    Console.WriteLine("Ошибка: Число выходит за допустимый диапазон");
                    GetYearFromUser();
                    return;
                }
                year = result;
            }
            else
            {
                Console.WriteLine("Ошибка: Введено не число");
                GetYearFromUser();
                return;
            }
        }

        //Функция проверка года на високосность (В.Е. 04.11.2024)
        void CheckYear()
        {
            GetYearFromUser();

            if (year.HasValue)
            {

                if ((year % 400 == 0) || ((year % 4 == 0) ^ (year % 100 == 0)))
                {
                    Console.WriteLine($"Год {year} является високосным");
                }
                else Console.WriteLine($"Год {year} не является високосным");

                year = null;
            }
            if (isWork) CheckYear();

        }

        //Выполнение программы
        public void CheckRun()
        {
            Console.WriteLine("Вас приветствует Сервис проверки года на високосность");
            CheckYear();
        } 
    }
}
