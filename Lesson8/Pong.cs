namespace Lesson8
{
    /// <summary>
    /// Класс описывающий Pong.
    /// </summary>
    public class Pong
    {
        /// <summary>
        /// Делегат класса Pong передающий сообщение своим подписчикам, для обработки события "Подача Ponga".
        /// </summary>
        /// <param name="message">Сообщение подписчикам содержащее имя класса.</param>
        public delegate void PongHandler(string message);
        /// <summary>
        /// Событие - "Подача Ponga" на основе делегата PongHandler.
        /// </summary>
        public event PongHandler PongEvent;
        /// <summary>
        /// Делегат класса Pong предназначенный для обработки события "Получение очка Pong".
        /// </summary>
        public delegate void PongGetPoinHandler();
        /// <summary>
        /// Событие "Получение очка Pong" на основе делегата PongGetPoinHandler.
        /// </summary>
        public event PongGetPoinHandler PongGetPoinEvent;
        /// <summary>
        /// Объект класса Random, для генерации случайного числа от 1 до 7 (так партии заканчиваются не очень быстро).
        /// </summary>
        Random random = new();
        /// <summary>
        /// Метод вызова подписчиков события "Подача Ponga".
        /// </summary>
        public void MakePass ()
        {
            Thread.Sleep(500);
            PongEvent?.Invoke("Pong");
        }
        /// <summary>
        /// Метод вызова подписчиков события "Получение очка Pong".
        /// </summary>
        protected void TakePoint()
        {
            Thread.Sleep(500);
            PongGetPoinEvent?.Invoke();
        }
        /// <summary>
        /// Функция - подписчик делегата класса Ping, для обработки события "Подача Pinga".
        /// </summary>
        /// <param name="message">Сообщение с именем класса Ping</param>
        public void PingListener (string message)
        {
            int randomNumber = random.Next(1, 8);
            if (randomNumber == 7)
            {
                Console.WriteLine($"{message} промахнулся! Очко заработал Pong");
                TakePoint();
            }
            else
            {
                Console.WriteLine($"Pong получил {message}");
                MakePass();
            }
        }
        /// <summary>
        /// Функция - подписчик делегата класса PingPong, для обработки события "Следующая поддача Pong".
        /// </summary>
        public void GameListener()
        {
            MakePass();
        }
    }
}
