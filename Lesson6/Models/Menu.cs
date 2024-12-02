namespace Lesson6.Models
{
    public class Menu
    {
        public string[] Items { get; set; }

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
