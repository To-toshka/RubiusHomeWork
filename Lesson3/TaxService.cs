namespace Lesson3
{
    public class TaxService
    {
        private bool firstStart = true;
        public void TaxCalculation ()
        {
            if (firstStart)
            {
                Console.WriteLine("Добро пожаловать в сервис расчета НДФЛ");
            }

            Console.WriteLine("Введите совокупный доход за год или 'стоп', чтобы остановить работу сервиса");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: Данные не введены");
                firstStart = false;
                TaxCalculation();
                return;
            }

            if (input.ToLower() == "стоп")
            {
                Console.WriteLine("Работа сервиса остановлена");
                return;
            }

            if (decimal.TryParse(input.Replace(".", ","), out decimal inputDecimal))
            {
                if (inputDecimal < 0)
                {
                    Console.WriteLine("Ошибка: Вы ввели отрицательное число");
                    firstStart = false;
                    TaxCalculation();
                    return;
                }

                if (inputDecimal >= 5000_000.00m) 
                {
                    decimal tax = (5000_000.00m * 0.13m) + ((inputDecimal - 5000_000.00m) * 0.15m);
                    decimal result = Math.Round(tax, 2);
                    Console.WriteLine($"Сумма налога к уплате: {result}");
                    firstStart = false;
                    TaxCalculation();
                    return;
                }
                else
                {
                    decimal tax = inputDecimal * 0.13m;
                    decimal result = Math.Round(tax, 2);
                    Console.WriteLine($"Сумма налога к уплате: {result}");
                    firstStart = false;
                    TaxCalculation();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Введено не число");
                firstStart = false;
                TaxCalculation();
                return;
            }
        }
    }
}
