using Lesson3.Models;

namespace Lesson3
{
    public class WarehouseService
    {

        private Dictionary<string, ProductParameters> productOnWarehouse = new() {
            {"КАРТОФЕЛЬ", new ProductParameters { Quantity  = 250, Price = 30.00m, TotalPrice = 7500.00m } },
            {"ЛУК", new ProductParameters { Quantity  = 100, Price = 20.00m, TotalPrice = 2000.00m } },
            {"МОРКОВЬ", new ProductParameters { Quantity  = 125, Price = 25.00m, TotalPrice = 3125.00m } }
        };

        string[] menu = new[] { "МЕНЮ", "1. Просмотреть все товары", "2. Добавить товар", "3. Потребить товар", "4. Найти товар", "5. Удалить товар из списка" , "6. Выйти" };

        public void StartService()
        {
            Console.WriteLine("Добро пожаловать в сервис складского Учета");
            ShowMenu();
            Console.WriteLine("Спасибо, что воспользовались нашим сервисом");
        }

        #region functions

        /// <summary>
        /// Функция вызова меню.
        /// </summary>
        private void ShowMenu ()
        {
            Console.WriteLine("");
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Введите номер действия");
            GetMenuItem();

        }

        /// <summary>
        /// Функция получения желаемого действия от пользователя и запуска дальнейшей логики
        /// </summary>
        private void GetMenuItem ()
        {
            string? input = Console.ReadLine();
            switch (input) 
            {
                case "1":
                    ShowProduct();
                    break;
                case "2":
                    AddProduct();
                    break;
                case "3":
                    ConsumeProduct();
                    break;
                case "4":
                    FindProduct();
                    break;
                case "5":
                    DeletProduct();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Действие не определено");
                    Console.WriteLine("Введите номер действия");
                    GetMenuItem();
                    break;
            }
        }

        /// <summary>
        /// Функция вывода хранящихся на складе продуктов в консоль
        /// </summary>
        private void ShowProduct()
        {
            if (productOnWarehouse != null)
            {
                if (productOnWarehouse.Count > 0)
                {
                    foreach (var product in productOnWarehouse)
                    {
                        Console.WriteLine($"{product.Key}: Количество - {product.Value.Quantity} кг, Цена - {product.Value.Price:F2} руб., Общая стоимость - {product.Value.TotalPrice:F2} руб.");
                    }
                    Thread.Sleep(5000);
                }
                else
                {
                    Console.WriteLine("Склад пуст. Добавьте продукты");
                    Thread.Sleep(3000);
                }
            }
            else
            {
                Console.WriteLine("Данные о запасах недоступны. Обратитесь в службу поддержки.");
                Thread.Sleep(3000);                
            }
            ShowMenu();
        }

        /// <summary>
        /// Функция добавления продуктов на склад
        /// </summary>
        private void AddProduct() 
        {
            bool correctQuantity = false;
            bool correctKey = false;
            bool isServiceStop = false;

            var productName = "";
            var productQuantity = 0;            
            do
            {
                Console.WriteLine("Введите название Продукта, который хотите добавить или 'стоп', чтобы вернуться в Меню");
                string? inputKey = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputKey))
                {
                    Console.WriteLine("Ошибка: Не указано название продукта.");
                    continue;
                }

                if (inputKey.ToLower() == "стоп")
                {
                    correctKey = true;
                    isServiceStop = true;
                    continue;
                }

                productName = inputKey.ToUpper();
                correctKey = true;
            } while (!correctKey);

            while (!correctQuantity && !isServiceStop)
            {
                Console.WriteLine("Введите количество продукта, которое хотите добавить или 'стоп', чтобы вернуться в Меню");
                string? inputQuantity = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputQuantity))
                {
                    Console.WriteLine("Ошибка: Не указано количество продукта.");
                    continue;
                }

                if (inputQuantity.ToLower() == "стоп")
                {
                    correctQuantity = true;
                    isServiceStop = true;
                    continue;
                }

                if (int.TryParse(inputQuantity, out int inputQuantityInt))
                {
                    if (inputQuantityInt < 0)
                    {
                        Console.WriteLine("Ошибка: Вы ввели отрицательное число");
                        continue;
                    }
                    productQuantity = inputQuantityInt;
                    correctQuantity = true;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введено не число");
                    continue;
                }
            }
            
            //Обновление данных о продукте, если он уже заведен на складе
            if (!string.IsNullOrWhiteSpace(productName) && productOnWarehouse.ContainsKey(productName) && !isServiceStop)
            {
                if (productOnWarehouse.TryGetValue(productName, out ProductParameters productParameters))
                {
                    productParameters.Quantity = productParameters.Quantity + productQuantity;
                    productParameters.TotalPrice = productParameters.Price * (decimal)productParameters.Quantity;
                    Console.WriteLine($"Данные по продукту {productName} успешно обновлены");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"Ошибка: Не удалось получить значение по ключу {productName}");
                    Thread.Sleep(3000);
                    isServiceStop = true;
                }
            }
            //---------------------------------------------------------------------------------------------------------------
            //Создание нового Продукта с указанием его стоимости
            else if (!string.IsNullOrWhiteSpace(productName) && !productOnWarehouse.ContainsKey(productName) && !isServiceStop)
            {
                bool correctPrice = false;
                decimal price = 0.00m;
                decimal totalPrice = 0.00m;

                do
                {
                    Console.WriteLine("Введите стоимость кг продукта, который хотите добавить или 'стоп' чтобы вернуться в Меню");
                    string? inputPrice = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputPrice))
                    {
                        Console.WriteLine("Ошибка: Стоимость не указана");
                        continue;
                    }
                    if (inputPrice.ToLower() == "стоп")
                    {
                        isServiceStop = true;
                        correctPrice = true;
                        continue;
                    }
                    if (decimal.TryParse(inputPrice, out decimal inputPriceDecimal))
                    {
                        if (inputPriceDecimal < 0.00m)
                        {
                            Console.WriteLine("Ошибка: Стоимость не может быть отрицательной");
                            continue;
                        }
                        price = inputPriceDecimal;
                        correctPrice = true;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Введено не число");
                        continue;
                    }


                } while (!correctPrice);

                if (!isServiceStop)
                {
                    totalPrice = price * (decimal) productQuantity;

                    productOnWarehouse.Add(productName, new ProductParameters
                    {
                        Quantity = productQuantity,
                        Price = price,
                        TotalPrice = totalPrice

                    }); ;
                    Console.WriteLine($"Данные по продукту {productName} успешно добавлены");
                    Thread.Sleep(3000);
                }
            }
            //___________________________________________________________________________________________
            else if (!isServiceStop)
            {
                Console.WriteLine($"Ошибка: Не удалось добавить данные по продукту {productName}");
                Thread.Sleep(3000);                
            }
            ShowMenu();
        }

        /// <summary>
        /// Функция потребления пролукта на складе
        /// </summary>
        private void ConsumeProduct() 
        {
            bool correctQuantity = false;
            bool correctKey = false;
            bool isServiceStop = false;

            var productName = "";

            do
            {
                Console.WriteLine("Введите название Продукта, который хотите потребить или 'стоп', чтобы вернуться в Меню");
                string? inputKey = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputKey))
                {
                    Console.WriteLine("Ошибка: Не указано название продукта.");
                    continue;
                }
                if (inputKey.ToLower() == "стоп")
                {
                    correctKey = true;
                    isServiceStop = true;
                    continue;
                }
                productName = inputKey.ToUpper();

                if (!productOnWarehouse.ContainsKey(productName))
                {
                    Console.WriteLine($"Ошибка: Продукт {productName} не найден на складе.");
                    Thread.Sleep(3000);
                    continue;
                }
                correctKey = true;
            } while (!correctKey);

            while (!correctQuantity && !isServiceStop)
            {
                Console.WriteLine("Введите количество продукта, которое хотите убрать со склада");
                string? inputQuantity = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputQuantity))
                {
                    Console.WriteLine("Ошибка: Не указано количество продукта.");
                    continue;
                }

                if(inputQuantity.ToLower() == "стоп")
                {
                    correctQuantity = true;
                    continue;
                }

                if (int.TryParse(inputQuantity, out int inputQuantityInt))
                {
                    if (inputQuantityInt < 0)
                    {
                        Console.WriteLine("Ошибка: Вы ввели отрицательное число");
                        continue;
                    }

                    if (productOnWarehouse.TryGetValue(productName, out ProductParameters productParameters))
                    {
                        if (productParameters.Quantity < inputQuantityInt)
                        {
                            Console.WriteLine("Ошибка: Вы не можете удалить больше единиц продукта, чем есть на складе");
                            Console.WriteLine($"Сейчас на складе {productParameters.Quantity} кг продукта {productName}");
                            continue;
                        }

                        productParameters.Quantity = productParameters.Quantity - inputQuantityInt;
                        productParameters.TotalPrice = productParameters.Price * (decimal)productParameters.Quantity;
                        Console.WriteLine($"Данные по продукту {productName} успешно обновлены");
                        correctQuantity = true;
                        Thread.Sleep(3000);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: Не удалось получить значение по ключу {productName}");
                        correctQuantity = true;
                        Thread.Sleep(3000);                        
                        continue;

                    }                    
                }
                else
                {
                    Console.WriteLine("Ошибка: Введено не число");
                    continue;
                }
            }
            ShowMenu();
        }

        /// <summary>
        /// Функция поиска продуктов на складе
        /// </summary>
        private void FindProduct() 
        {
            bool correctKey = false;

            do
            {
                Console.WriteLine("Введите название продукта для поиска или 'стоп', чтобы вернуться в Меню ");
                string? inputKey = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputKey))
                {
                    Console.WriteLine("Ошибка: Вы ничего не ввели");
                    continue;
                }
                if (inputKey.ToLower() == "стоп")
                {
                    correctKey = true;
                    continue;
                }

                Dictionary<string, ProductParameters> result = new ();
                foreach (var product in productOnWarehouse)
                {
                    if(product.Key.IndexOf(inputKey.ToUpper()) >= 0)
                    {
                        result.Add(product.Key,product.Value);
                    }
                }
                if (result.Count == 0)
                {
                    Console.WriteLine("По вашему запросу ничего не найдено");
                    continue;
                }

                Console.WriteLine($"Количество продуктов найденныйх по запросу - {result.Count}:");
                Thread.Sleep(1500);
                foreach (var product in result)
                {
                    Console.WriteLine($"{product.Key}: Количество - {product.Value.Quantity} кг, Цена - {product.Value.Price:F2} руб., Общая стоимость - {product.Value.TotalPrice:F2} руб.");
                }
                Thread.Sleep(5000);                
                correctKey = true;

            } while (!correctKey);
            ShowMenu();
        }

        /// <summary>
        /// Функция удаления продука из списка, если он полностью потреблен
        /// </summary>
        private void DeletProduct() 
        {
            bool correctKey = false;

            do
            {
                Console.WriteLine("Введите название продукта который хотите удалить или 'стоп', чтобы вернуться в Меню ");
                string? inputKey = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputKey))
                {
                    Console.WriteLine("Ошибка: Вы ничего не ввели");
                    continue;
                }
                if (inputKey.ToLower() == "стоп")
                {
                    correctKey = true;
                    continue;
                }
                string upperInputKey = inputKey.ToUpper();
                if (!productOnWarehouse.ContainsKey(inputKey.ToUpper()))
                {
                    Console.WriteLine($"Ошибка: Продукт с именем {upperInputKey} не найден");
                    continue;
                }
                if (productOnWarehouse.TryGetValue(upperInputKey, out ProductParameters productParameters))
                {
                    if (productParameters.Quantity > 0)
                    {
                        Console.WriteLine("Ошибка: Вы не можете удалить продукт, пока полностью не Потребите его");
                        Console.WriteLine($"Текущее количество {upperInputKey} на складе {productParameters.Quantity} кг");
                        continue;
                    }
                    productOnWarehouse.Remove(upperInputKey);
                    Console.WriteLine($"Продукт {upperInputKey} успешно удален");
                    correctKey = true;
                    continue;

                }
                else
                {
                    Console.WriteLine($"Ошибка: Не удалось получить значение по ключу {upperInputKey}");
                    correctKey = true;
                    Thread.Sleep(3000);                    
                    continue;
                }
                
            } while (!correctKey);
            ShowMenu();
        }
    #endregion
}
}
