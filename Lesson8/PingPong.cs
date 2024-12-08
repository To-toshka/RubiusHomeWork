using System.Text;

namespace Lesson8
{
    internal class PingPong
    {
        int Round { get; set; } = 1;
        int PointPing { get; set; } = 0;
        int PointPong { get; set; } = 0;
        public delegate void PingNextTern();
        public event PingNextTern OnPingNextTern;
        public delegate void PongNextTern();
        public event PongNextTern OnPongNextTern;
        public void StartGame()
        {
            try
            {
                Random random = new();
                Ping ping = new Ping();
                Pong pong = new Pong();
                ping.PingEvent += pong.PingListener;
                pong.PongEvent += ping.PongListener;
                pong.PongGetPoinEvent += PongPointListener;
                ping.PingGetPoinEvent += PingPointListener;
                OnPingNextTern += ping.GameListener;
                OnPongNextTern += pong.GameListener;
                int randomNumber = random.Next(1, 3);
                Console.WriteLine("Игра началась!");
                switch (randomNumber)
                {
                    case 1:
                        ping.MakePass(); break;
                    case 2:
                        pong.MakePass(); break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }           

        }
        void ShowResult ()
        {
            Console.WriteLine($"Счет после {Round} раунда:");
            Console.WriteLine($"Ping {PointPing}:{PointPong} Pong");
            Console.WriteLine("");
            Round++;
            Thread.Sleep(2000);
        }
        void PongPointListener ()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"В {Round} раунде победил Pong");
            PointPong++;
            ShowResult();            
            if (PointPong < 6) OnPongNextTern?.Invoke();
            else Console.WriteLine("Победил Pong");
        }
        void PingPointListener()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"В {Round} раунде победил Ping");
            PointPing++;            
            ShowResult();
            if (PointPing < 6) OnPingNextTern?.Invoke();
            else Console.WriteLine("Победил Ping");
        }

    }
}
