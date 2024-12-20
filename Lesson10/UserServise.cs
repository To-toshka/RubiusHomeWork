using Lesson10.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Lesson10
{
    /// <summary>
    /// Класс описывающий CRUD методы для класса User (Пользователь).
    /// </summary>
    /// <param name="context">Объект класса ApplicationContext, необходимый для работы с базой.</param>
    public class UserServise(ApplicationContext context)
    {
        /// <summary>
        /// Поле хранящее объект класса ApplicationContext, полученный из конструктора класса при создании.
        /// </summary>
        ApplicationContext _context = context;

        /// <summary>
        /// Метод добавления нового Пользователя (класс User) в базу данных.
        /// </summary>
        public void AddUser()
        {
            User user = new();
            bool isAddWork = true;
            bool isSurnameCorrect = false;
            bool isDateCorrect = false;
            bool isNameCorrect = false;
            bool isPatronymicCorrect = false;
            string pattern = @"^\d{4}-\d{2}-\d{2}$";

            //Добавление фамилии
            while (!isSurnameCorrect && isAddWork)
            {
                Console.WriteLine("Введите фамилию пользователя или '@стоп', чтобы вернуться в Меню:");
                string? inputSurname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputSurname))
                {
                    Console.WriteLine("Ошибка: Вы не ввели фамилию!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputSurname.ToLower() == "@стоп")
                {
                    Console.WriteLine("");
                    isSurnameCorrect = true;
                    isAddWork = false;
                    continue;
                }
                if (!InputStringChecker("Фамилия", inputSurname)) continue;
                user.Surname = inputSurname.ToUpper();
                Console.WriteLine("");
                isSurnameCorrect = true;
            }

            //Добавление имени
            while (!isNameCorrect && isAddWork)
            {
                Console.WriteLine("Введите имя пользователя или '@стоп', чтобы вернуться в Меню:");
                string? inputName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputName))
                {
                    Console.WriteLine("Ошибка: Вы не ввели имя!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputName.ToLower() == "@стоп")
                {
                    Console.WriteLine("");
                    isNameCorrect = true;
                    isAddWork = false;
                    continue;
                }
                if (!InputStringChecker("Имя", inputName)) continue;
                user.Name = inputName.ToUpper();
                Console.WriteLine("");
                isNameCorrect = true;
            }

            //Добавление отчества
            while (!isPatronymicCorrect && isAddWork)
            {
                Console.WriteLine("Введите отчество пользователя или '@стоп', чтобы вернуться в Меню.");
                Console.WriteLine("ВНИМАНИЕ: Если у пользователя НЕТ отчества оставте поле незаполненным.");
                string? inputPatronymic = Console.ReadLine();
                if (inputPatronymic == null)
                {
                    Console.WriteLine("");
                    isPatronymicCorrect = true;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(inputPatronymic))
                {
                    Console.WriteLine("Ошибка: Вы не ввели отчество!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputPatronymic.ToLower() == "@стоп")
                {
                    Console.WriteLine("");
                    isPatronymicCorrect = true;
                    isAddWork = false;
                    continue;
                }
                if (!InputStringChecker("Отчество", inputPatronymic)) continue;
                user.Patronymic = inputPatronymic.ToUpper();
                Console.WriteLine("");
                isPatronymicCorrect = true;
            }

            //Добавление даты рождения
            while (!isDateCorrect && isAddWork)
            {
                Console.WriteLine("Введите дату рождения пользователя в формате ГГГГ-ММ-ДД или 'стоп', чтобы вернуться в Меню:");
                string? inputDate = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputDate))
                {
                    Console.WriteLine("Ошибка: Вы не ввели дату!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputDate.ToLower() == "стоп")
                {
                    isDateCorrect = true;
                    isAddWork = false;
                    Console.WriteLine("");
                    continue;
                }
                if (!Regex.IsMatch(inputDate, pattern))
                {
                    Console.WriteLine("Ошибка: Неверный формат даты!");
                    Console.WriteLine("");
                    continue;
                }
                if (DateOnly.TryParse(inputDate, out DateOnly date))
                {
                    DateTime now = DateTime.Now;
                    DateOnly nowDate = new DateOnly(now.Year, now.Month, now.Day);
                    if (date > nowDate)
                    {
                        Console.WriteLine("Ошибка: Дата рождения не может быть больше текущей даты!");
                        Console.WriteLine("");
                        continue;
                    }
                    user.BirthDate = date;
                    Console.WriteLine("");
                    isDateCorrect = true;
                }
            }

            //Добавление нового пользователя в базу
            if (isAddWork)
            {
                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine($"Успешно добавлен новый пользователь: {user.Surname} {user.Name} {user.Patronymic} {user.BirthDate}");
                Console.WriteLine("");
            }            
        }

        /// <summary>
        /// Метод редактирования существующего Пользователя (класс User) в базе данных.
        /// </summary>
        public void UpdateUser()
        {
            bool isAddWork = true;
            bool isIdCorrect = false;
            bool isSurnameCorrect = false;
            bool isDateCorrect = false;
            bool isNameCorrect = false;
            bool isPatronymicCorrect = false;
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            DateOnly? newDate = null;
            string newName = "";
            string newSurname = "";
            string newPatronymic = "";
            User userForChanging = new();

            //Поиск пользователя по ID для изменения.
            while (!isIdCorrect)
            {
                Console.WriteLine("Укажите ID пользователя или 'стоп', чтобы вернуться в меню:");
                string? inputId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputId))
                {
                    Console.WriteLine("Ошибка: Вы не указали ID.");
                    Console.WriteLine("");
                    continue;
                }
                if (inputId.ToLower() == "стоп")
                {
                    Console.WriteLine("");
                    isIdCorrect = true;
                    isAddWork = false;
                    continue;
                }
                if (int.TryParse(inputId, out int id))
                {
                    var user = _context.Users
                        .Where(u => u.Id == id).FirstOrDefault();
                    if (user == null)
                    {
                        Console.WriteLine("Пользователь с указанным id не найден.");
                        Console.WriteLine("");
                        continue;
                    }
                    userForChanging = user;
                    isIdCorrect = true;
                    Console.WriteLine($"Выбран пользователь: {userForChanging.Surname} {userForChanging.Name} {userForChanging.Patronymic} {userForChanging.BirthDate}");
                    continue;
                }
                Console.WriteLine("Ошибка: Введено не число.");
                Console.WriteLine("");
            }

            //Редактирование Фамилии
            while (!isSurnameCorrect && isAddWork)
            {
                Console.WriteLine("Введите фамилию пользователя или '@стоп', чтобы вернуться в Меню.");
                Console.WriteLine("Чтобы пропустить редактирование поля, введите пустую строку.");
                string? inputSurname = Console.ReadLine();
                if (inputSurname == null || inputSurname == "")
                {
                    Console.WriteLine("");
                    isSurnameCorrect = true;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(inputSurname))
                {
                    Console.WriteLine("Ошибка: Вы не ввели фамилию!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputSurname.ToLower() == "@стоп")
                {
                    Console.WriteLine("");
                    isSurnameCorrect = true;
                    isAddWork = false;
                    continue;
                }
                if (!InputStringChecker("Фамилия", inputSurname)) continue;
                newSurname = inputSurname.ToUpper();
                Console.WriteLine("");
                isSurnameCorrect = true;
            }

            //Редактирование Имени
            while (!isNameCorrect && isAddWork)
            {
                Console.WriteLine("Введите имя пользователя или '@стоп', чтобы вернуться в Меню.");
                Console.WriteLine("Чтобы пропустить редактирование поля, введите пустую строку.");
                string? inputName = Console.ReadLine();
                if (inputName == null || inputName == "")
                {
                    Console.WriteLine("");
                    isNameCorrect = true;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(inputName))
                {
                    Console.WriteLine("Ошибка: Вы не ввели имя!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputName.ToLower() == "@стоп")
                {
                    Console.WriteLine("");
                    isNameCorrect = true;
                    isAddWork = false;
                    continue;
                }
                if (!InputStringChecker("Имя", inputName)) continue;
                newName = inputName.ToUpper();
                Console.WriteLine("");
                isNameCorrect = true;
            }

            //Редактирование Отчества
            while (!isPatronymicCorrect && isAddWork)
            {
                Console.WriteLine("Введите отчество пользователя или '@стоп', чтобы вернуться в Меню.");
                Console.WriteLine("Чтобы пропустить редактирование поля, введите пустую строку.");
                string? inputPatronymic = Console.ReadLine();
                if (inputPatronymic == null || inputPatronymic == "")
                {
                    Console.WriteLine("");
                    isPatronymicCorrect = true;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(inputPatronymic))
                {
                    Console.WriteLine("Ошибка: Вы не ввели отчество!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputPatronymic.ToLower() == "@стоп")
                {
                    Console.WriteLine("");
                    isPatronymicCorrect = true;
                    isAddWork = false;
                    continue;
                }
                if (!InputStringChecker("Отчество", inputPatronymic)) continue;
                newPatronymic = inputPatronymic.ToUpper();
                Console.WriteLine("");
                isPatronymicCorrect = true;
            }

            //Редактирование Даты рождения
            while (!isDateCorrect && isAddWork)
            {
                Console.WriteLine("Введите дату рождения пользователя в формате ГГГГ-ММ-ДД или 'стоп', чтобы вернуться в Меню.");
                Console.WriteLine("Чтобы пропустить редактирование поля, введите пустую строку.");
                string? inputDate = Console.ReadLine();
                if (inputDate == null || inputDate == "")
                {
                    Console.WriteLine("");
                    isDateCorrect = true;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(inputDate))
                {
                    Console.WriteLine("Ошибка: Вы не ввели дату!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputDate.ToLower() == "стоп")
                {
                    isDateCorrect = true;
                    isAddWork = false;
                    Console.WriteLine("");
                    continue;
                }
                if (!Regex.IsMatch(inputDate, pattern))
                {
                    Console.WriteLine("Ошибка: Неверный формат даты!");
                    Console.WriteLine("");
                    continue;
                }
                if (DateOnly.TryParse(inputDate, out DateOnly date))
                {
                    DateTime now = DateTime.Now;
                    DateOnly nowDate = new DateOnly(now.Year, now.Month, now.Day);
                    if (date > nowDate)
                    {
                        Console.WriteLine("Ошибка: Дата рождения не может быть больше текущей даты!");
                        Console.WriteLine("");
                        continue;
                    }
                    newDate = date;
                    Console.WriteLine("");
                    isDateCorrect = true;
                }
            }

            //Добавление изменений
            if (isAddWork && userForChanging != null)
            {
                userForChanging.Surname = !string.IsNullOrWhiteSpace(newSurname) ? newSurname : userForChanging.Surname;
                userForChanging.Name = !string.IsNullOrWhiteSpace(newName) ? newName : userForChanging.Name;
                userForChanging.Patronymic = !string.IsNullOrWhiteSpace(newPatronymic) ? newPatronymic : userForChanging.Patronymic;
                userForChanging.BirthDate = newDate != null ? newDate : userForChanging.BirthDate;

                context.SaveChanges();
                Console.WriteLine("Пользователь успешно обновлен.");
                Console.WriteLine("");

            }
        }

        /// <summary>
        /// Метод удаления существующего Пользователя (класс User) из базы данных по ID.
        /// </summary>
        public void DeleteUser()
        {
            bool isIdCorrect = false;
            while (!isIdCorrect)
            {
                Console.WriteLine("Укажите ID пользователя или 'стоп', чтобы вернуться в меню:");
                string? inputId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputId))
                {
                    Console.WriteLine("Ошибка: Вы не указали ID.");
                    Console.WriteLine("");
                    continue;
                }
                if (inputId.ToLower() == "стоп")
                {
                    Console.WriteLine("");
                    isIdCorrect = true;
                    continue;
                }
                if (int.TryParse(inputId, out int id))
                {
                    var user = _context.Users
                        .Where(u => u.Id == id).FirstOrDefault();
                    if (user == null)
                    {
                        Console.WriteLine("Пользователь с указанным id не найден.");
                        Console.WriteLine("");
                        continue;
                    }
                    _context.Users.Where(x => x.Id == id).ExecuteDelete();
                    _context.SaveChanges();
                    Console.WriteLine("Пользователь успешно удален.");
                    Console.WriteLine("");
                    isIdCorrect = true;
                    continue;
                }
                Console.WriteLine("Ошибка: Введено не число.");
                Console.WriteLine("");
            }

        }

        /// <summary>
        /// Метод вывода существующего Пользователя (класс User) из базы данных по ID.
        /// </summary>
        public void FindUser()
        {
            bool isIdCorrect = false;
            while (!isIdCorrect)
            {
                Console.WriteLine("Укажите ID пользователя или 'стоп', чтобы вернуться в меню:");
                string? inputId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputId))
                {
                    Console.WriteLine("Ошибка: Вы не указали ID.");
                    Console.WriteLine("");
                    continue;
                }
                if (inputId.ToLower() == "стоп")
                {
                    Console.WriteLine("");
                    isIdCorrect = true;
                    continue;
                }
                if (int.TryParse(inputId, out int id))
                {
                    var user = _context.Users
                        .Where(u => u.Id == id).FirstOrDefault();
                    if (user == null)
                    {
                        Console.WriteLine("Пользователь с указанным id не найден.");
                        Console.WriteLine("");
                        continue;
                    }
                    Console.WriteLine($"{user.Id}. {user.Surname} {user.Name} {user.Patronymic} {user.BirthDate}");
                    Console.WriteLine("");
                    continue;
                }
                Console.WriteLine("Ошибка: Введено не число.");
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Метод вывода в консоль списка всех Пользователей (класс User), хранящихся в базе данных.
        /// </summary>
        public void ShowUsers()
        {
            var users = _context.Users.OrderBy(x => x.Id).ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}. {user.Surname} {user.Name} {user.Patronymic} {user.BirthDate}");
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Метод проверки введенной строки на корректность.
        /// </summary>
        /// <param name="nameString">Название проверяемого параметра Пользователя (класс User).</param>
        /// <param name="inputString">Значение проверяемого параметра Пользователя (класс User).</param>
        /// <returns></returns>
        private bool InputStringChecker(string nameString, string inputString)
        {
            if (Regex.IsMatch(inputString, @"\d"))
            {
                Console.WriteLine($"Ошибка: {nameString} не может содержать цифры!");
                Console.WriteLine("");
                return false;
            }
            if (Regex.IsMatch(inputString, @"[^\w\s]") ^ Regex.IsMatch(inputString, @"-"))
            {
                Console.WriteLine($"Ошибка: {nameString} не может содержать спецсимволы!");
                Console.WriteLine("");
                return false;
            }
            if (Regex.IsMatch(inputString, @"[\p{P}]") ^ Regex.IsMatch(inputString, @"-"))
            {
                Console.WriteLine($"Ошибка: {nameString} не может содержать знаки препинания!");
                Console.WriteLine("");
                return false;
            }
            if (inputString[0] == '-' || inputString[^1] == '-')
            {
                Console.WriteLine($"Ошибка: {nameString} не может начинаться или заканчиваться '-'!");
                Console.WriteLine("");
                return false;
            }
            return true;

        }
    }
}
