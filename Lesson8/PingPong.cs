using System.Drawing;

namespace Lesson8
{
    /// <summary>
    /// Класс описывающий Ping.
    /// </summary>
    internal class PingPong
    {
        /// <summary>
        /// Поле хранящее в себе номер Раунда.
        /// </summary>
        int Round { get; set; } = 1;
        /// <summary>
        /// Поле хранящее в себе очки Pinga.
        /// </summary>
        int PointPing { get; set; } = 0;
        /// <summary>
        /// Поле хранящее в себе очки Ponga.
        /// </summary>
        int PointPong { get; set; } = 0;
        /// <summary>
        /// Делегат класса PingPong предназначенный для обработки события "Следующая подача Pinga".
        /// </summary>
        public delegate void PingNextTern();
        /// <summary>
        /// Событие "Следующая подача Pinga" на основе делегата PingNextTern.
        /// </summary>
        public event PingNextTern OnPingNextTern;
        /// <summary>
        /// Делегат класса PingPong предназначенный для обработки события "Следующая подача Ponga".
        /// </summary>
        public delegate void PongNextTern();
        /// <summary>
        /// Событие "Следующая подача Ponga" на основе делегата PongNextTern.
        /// </summary>
        public event PongNextTern OnPongNextTern;
        /// <summary>
        /// Функция старта партии в PingPong.
        /// </summary>
        public void StartGame()
        {
            try
            {
                //Объект класса Random для определения начинающей стороны.
                Random coinFlip = new();
                Ping ping = new Ping();
                Pong pong = new Pong();
                ping.PingEvent += pong.PingListener;
                pong.PongEvent += ping.PongListener;
                pong.PongGetPoinEvent += PongPointListener;
                ping.PingGetPoinEvent += PingPointListener;
                OnPingNextTern += ping.GameListener;
                OnPongNextTern += pong.GameListener;
                int coinSide = coinFlip.Next(1, 3);
                Console.WriteLine("Игра началась!");
                switch (coinSide)
                {
                    case 1:
                        Thread.Sleep(1000);
                        Console.WriteLine("Выпал 'Орел'. Начинает Ping.");
                        ping.MakePass();
                        break;
                    case 2:
                        Thread.Sleep(1000);
                        Console.WriteLine("Выпала 'Решки'. Начинает Pong.");
                        pong.MakePass(); 
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }           

        }
        /// <summary>
        /// Функция вывода результата рауна в консоль.
        /// </summary>
        void ShowResult ()
        {
            Console.WriteLine($"Счет после {Round} раунда:");
            Console.WriteLine($"Ping {PointPing}:{PointPong} Pong");
            Console.WriteLine("");
            Round++;
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Функция - подписчик делегата класса Pong, для обработки события "Получение очка Pong".
        /// </summary>
        void PongPointListener ()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"В {Round} раунде победил Pong");
            PointPong++;
            ShowResult();
            if (PointPong < 6) OnPongNextTern?.Invoke();
            else
            {
                Console.WriteLine("Победил Pong");
                Refresh();
            }
        }
        /// <summary>
        /// Функция - подписчик делегата класса Ping, для обработки события "Получение очка Ping".
        /// </summary>
        void PingPointListener()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"В {Round} раунде победил Ping");
            PointPing++;            
            ShowResult();
            if (PointPing < 6) OnPingNextTern?.Invoke();
            else
            {
                Console.WriteLine("Победил Ping");
                Refresh();
            }
        }
        /// <summary>
        /// Функуия сброса значений полей для следующей игры.
        /// </summary>
        private void Refresh()
        {
            Round = 1;
            PointPing = 0;
            PointPong = 0;
        }

    }
}
