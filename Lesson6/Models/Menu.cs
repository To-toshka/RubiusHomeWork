namespace Lesson6.Models
{
    /// <summary>
    /// Класс для создания меню сервисов.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Поле содержащее пункты меню.
        /// </summary>
        public string[] Items { get; set; }

        /// <summary>
        /// Функция вызова меню в консоль.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("Выберите действие указав его номер:");

            for (var i = 0; i < Items.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i]}");
            }
        }
    }
}
