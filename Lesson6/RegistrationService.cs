﻿using Lesson6.Models;
using System.Text.RegularExpressions;

namespace Lesson6
{
    /// <summary>
    /// Класс описывающий сервис регистрации граждан.
    /// </summary>
    internal class RegistrationService
    {
        private List<Citizen> Citizens = new List<Citizen> 
        { 
            new() {Surname = "ИВАНОВ", RegistrationDate = new DateOnly(2023,12,18) },
            new() {Surname = "ПЕТРОВ", RegistrationDate = new DateOnly(1998,01,05) },
            new() {Surname = "СИДОРОВ", RegistrationDate = new DateOnly(2001,05,21) },
            new() {Surname = "ПУГАЧЕВА", RegistrationDate = new DateOnly(1976,09,11) },
            new() {Surname = "КИРКОРОВ", RegistrationDate = new DateOnly(1988,09,03) },
        };
        private Menu registrationMenu = new Menu { Items = [ "Добавить запись", "Показать все записи", "Получить записи по дате", "Вернуться в главное Меню", "Выход" ] };

        /// <summary>
        /// Функция запуска сервиса.
        /// </summary>
        public bool StartService()
        {
            Console.WriteLine("Вас приветствует сервис регистрации граждан");
            bool isServiceWork = true;
            bool isMainMenuWork = true;
            try
            {                
                while (isServiceWork)
                {
                    registrationMenu.ShowMenu();
                    string? inputNumber = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputNumber))
                    {
                        Console.WriteLine("Ошибка: Вы не внесли данные!");
                        Console.WriteLine("");
                        continue;
                    }
                    if (inputNumber == "1")
                    {
                        Console.WriteLine("Ваш выбор: 1");
                        AddCitizen();
                        continue;
                    }
                    if (inputNumber == "2")
                    {
                        Console.WriteLine("Ваш выбор: 2");
                        ShowAllCitizens();
                        continue;
                    }
                    if (inputNumber == "3")
                    {
                        Console.WriteLine("Ваш выбор: 3");
                        GetCitizensFromDate();
                        continue;
                    }
                    if (inputNumber == "4")
                    {
                        Console.WriteLine("Ваш выбор: 4");
                        isServiceWork = false;
                        isMainMenuWork = true;
                        continue;
                    }
                    if (inputNumber == "5")
                    {
                        Console.WriteLine("Ваш выбор: 5");
                        Console.WriteLine("Спасибо, что воспользовались нашим сервисом.");
                        Console.WriteLine("Досвидания.");
                        isServiceWork = false;
                        isMainMenuWork = false;
                        continue;
                    }
                    Console.WriteLine("Команда не распознана!");
                    Console.WriteLine("");
                    continue;
                }
                return isMainMenuWork;
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return isMainMenuWork;
            }
            
        }

        #region functions
        /// <summary>
        /// Функция добавления новых зарегистрированных граждан в базу.
        /// </summary>
        private void AddCitizen()
        {
            Citizen newCitizen = new();            
            bool isSurnameCorrect = false;
            bool isDateCorrect = false;
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            while (!isSurnameCorrect)
            {
                Console.WriteLine("Введите фамилию или '@стоп', чтобы вернуться в Меню:");
                string? inputSurname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputSurname))
                {
                    Console.WriteLine("Ошибка: Вы не ввели фамилию!");
                    Console.WriteLine("");
                    continue;
                }
                if(inputSurname.ToLower() == "@стоп")
                {
                    isSurnameCorrect = true;
                    isDateCorrect = true;
                    continue;
                }
                if(Regex.IsMatch(inputSurname, @"\d"))
                {
                    Console.WriteLine("Ошибка: Фамилия не может содержать цифры!");
                    Console.WriteLine("");
                    continue;
                }
                if (Regex.IsMatch(inputSurname, @"[^\w\s]") ^ Regex.IsMatch(inputSurname, @"-"))
                {
                    Console.WriteLine("Ошибка: Фамилия не может содержать спецсимволы!");
                    Console.WriteLine("");
                    continue;
                }
                if (Regex.IsMatch(inputSurname, @"[\p{P}]") ^ Regex.IsMatch(inputSurname, @"-"))
                {
                    Console.WriteLine("Ошибка: Фамилия не может содержать знаки препинания!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputSurname[0] == '-' || inputSurname[^1] == '-')
                {
                    Console.WriteLine("Ошибка: Фамилия не может начинаться или заканчиваться '-'!");
                    Console.WriteLine("");
                    continue;
                }
                newCitizen.Surname = inputSurname.ToUpper();
                isSurnameCorrect = true;
            }
            while (!isDateCorrect)
            {
                Console.WriteLine("Введите дату регистрации в формате ГГГГ-ММ-ДД или 'стоп', чтобы вернуться в Меню:");
                string? inputDate = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputDate))
                {
                    Console.WriteLine("Ошибка: Вы не ввели дату!");
                    Console.WriteLine("");
                    continue;
                }
                if (inputDate.ToLower() == "стоп" )
                {
                    isDateCorrect = true;
                    continue;
                }
                if(!Regex.IsMatch(inputDate, pattern))
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
                        Console.WriteLine("Ошибка: Дата регистрации не может быть больше текущей даты!");
                        Console.WriteLine("");
                        continue;
                    }
                    newCitizen.RegistrationDate = date;
                    Citizens.Add(newCitizen);
                    Console.WriteLine($"Гражданин успешно зарегистрирован.");
                    Console.WriteLine("");
                    isDateCorrect = true;
                    continue;
                }                
                Console.WriteLine($"Ошибка: Не удалось обработать дату!");
            }
        }

        /// <summary>
        /// Функция вывода зарегистрированных граждан из базы в консоль.
        /// </summary>
        private void ShowAllCitizens()
        {
            var result = Citizens.OrderBy(x => x.RegistrationDate).ToList();
            Console.WriteLine("Все записи(отсортированы по дате):");
            foreach (var citizen in result)
            {
                Console.WriteLine($"{citizen.RegistrationDate}: {citizen.Surname}");                
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Функция поиска граждан по дате регистрации.
        /// </summary>
        private void GetCitizensFromDate()
        {
            bool isDateCorrect = false;
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            while (!isDateCorrect)
            {
                Console.WriteLine("Введите дату регистрации для поиска в формате ГГГГ-ММ-ДД или 'стоп', чтобы вернуться в Меню:");
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
                        Console.WriteLine("Ошибка: Дата больше текущей даты!");
                        Console.WriteLine("");
                        continue;
                    }
                    var result = Citizens.Where(x => x.RegistrationDate == date).OrderBy(x => x.Surname).ToList();
                    if (result == null || !(result.Count() > 0))
                    {
                        Console.WriteLine($"Не найдено ни одного гражданина с датой регистрации: {date}");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine($"Граждан зарегестрированных {date} - {result.Count}:");
                        for (var i = 0; i < result.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {result[i].Surname}");
                        }
                        Console.WriteLine("");
                    }
                    isDateCorrect = true;
                    continue;
                }
                Console.WriteLine($"Ошибка: Не удалось обработать дату!");
            }
        }
        #endregion
    }
}
