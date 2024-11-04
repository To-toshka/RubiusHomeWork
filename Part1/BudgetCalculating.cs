namespace Lesson2
{
    internal class BudgetCalculating
    {
        string[] categoris = { "Продукты - код:1", "Коммунальные - код:2", "Транспорт - код:3", "Развлечения - код:4", "Прочие - код:5" };
        string category = "";
        Dictionary <String, List<decimal>> budgetForMonth = new Dictionary<string, List<decimal>>();


        //Функция выбора категории и запуска ввода расходов (В.Е. 04.11.2024)
        void ChoiceСategory()
        {
            Console.WriteLine("Выберете категорию расходов указав название или код категории");
            bool isWork = true;
            void GetCategoryFromUser()
            {                
                string? input = Console.ReadLine();
                switch (input != null ? input.ToLower() : input)
                {
                    case "продукты" or "1":
                        category = "Продукты";
                        break;
                    case "коммунальны" or "2":
                        category = "Коммунальны";
                        break;
                    case "транспорт" or "3":
                        category = "Транспорт";
                        break;
                    case "развлечения" or "4":
                        category = "Развлечения";
                        break;
                    case "Прочие" or "5":
                        category = "Прочие";
                        break;
                    case "стоп":
                        isWork = false;
                        Calculating();
                        break;
                    default:
                        Console.WriteLine("Категоряи не определена");
                        Console.WriteLine("Введите Название или код категории. Что бы остановить ввод данных введите 'стоп'");
                        GetCategoryFromUser();
                        break;
                }
            }
            if (isWork)
            {
                GetCategoryFromUser();
                GetBudgetFromCategory();
            }            
        }

        //Функция ввода расходов по категориям (В.Е. 04.11.2024)
        void GetBudgetFromCategory()
        {
            Console.WriteLine($"Введите расходы по категории {category} за месяц. Что бы остановить ввод данных  и подсчитать расходы введите 'стоп'");
            Console.WriteLine($"Что бы перейти в другую категорию, введите 'сменить'");
            bool isGet = true;
            void GetBudget()
            {
                string? inputCash = Console.ReadLine();
                if (inputCash == null || inputCash == "")
                {
                    Console.WriteLine("Ошибка: Данные не введены");
                    GetBudget();
                    return;
                }
                else if (inputCash.ToLower() == "стоп")
                {
                    isGet = false;
                    Calculating();
                    return;
                }
                else if (inputCash.ToLower() == "сменить")
                {
                    isGet = false;
                    ChoiceСategory();
                    return;
                }
                else if (decimal.TryParse(inputCash.Replace(".",","), out decimal result))
                {
                    if (!budgetForMonth.ContainsKey(category))
                    {
                        List<decimal> resultList = new List<decimal>
                        {
                            result
                        };
                        budgetForMonth.Add(category, resultList);
                    }
                    else
                    {
                        budgetForMonth[category].Add(result);
                    };
                    GetBudget();
                }
                else
                {
                    Console.WriteLine("Ошибка: Введено не число");
                    GetBudget();
                    return;
                }
            }
            if (isGet)
            {
                GetBudget();
            }
        }

        //Функци расчета бюджета (В.Е. 04.11.2024)
        void Calculating()
        {
            if (budgetForMonth != null)
            {
                foreach (var category in budgetForMonth)
                {                    
                    decimal categorySumm = 0.00m;
                    string categoryName = category.Key;
                    if (budgetForMonth.TryGetValue(categoryName, out List<decimal> result))
                    {
                        if (result != null && result.Count > 0) 
                        {
                            foreach (var item in result)
                            {
                                categorySumm = categorySumm + item;
                            }

                            Console.WriteLine($"Траты в категории {categoryName}: {categorySumm} руб.");
                        }                        
                    }                    
                }
            }
        }


        //Выполнение программы (В.Е. 04.11.2024)
        public void RunCalculating ()
        {
            Console.WriteLine("Вас приветствует сервис расчета бюджета");            
            Console.WriteLine("Доступные категории:");
            foreach (var category in categoris) { Console.WriteLine($"{category}"); };
            ChoiceСategory();
        }
    }
}
