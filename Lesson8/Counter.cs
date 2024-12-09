namespace Lesson8
{/// <summary>
/// Класс описывающий счетчик до ста.
/// </summary>
    public class Counter
    {
        /// <summary>
        /// Делегат класса Counter
        /// </summary>
        /// <param name="counter"> Значение счетчика.</param>
        protected delegate void CounterHandler(int counter);
        /// <summary>
        /// Событие на основе делегата CounterHandler.
        /// </summary>
        protected event CounterHandler Handler;
        /// <summary>
        /// Переменная хранящая начальное значение счетчика.
        /// </summary>
        private int _counter = 0;
        /// <summary>
        /// Метод передачи данных подписчикам делегата Handler.
        /// </summary>
        /// <param name="counter"> Значение счетчика.</param>
        protected virtual void CallHendler (int counter)
        {
            Handler?.Invoke(counter);
        }
        Handler1 handler1 = new();
        Handler2 handler2 = new();

        /// <summary>
        /// Функйия запуска отсчета.
        /// </summary>
        public void StartCount()
        {
            Handler += handler1.CounterHandler1;
            Handler += handler2.CounterHandler2;

            while (_counter <= 100) 
            {
                Console.WriteLine(_counter);
                Thread.Sleep(100);                
                if (_counter == 33)
                {
                    CallHendler(_counter);
                }
                _counter++;
            }
        }

    }
}
