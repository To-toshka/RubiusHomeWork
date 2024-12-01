using System.Text;

namespace Lesson6
{
    /// <summary>
    /// Класс описывающий сервис для подсчета слов в файле.
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// Функция запуска работы сервиса.
        /// </summary>
        public void StartService()
        {
            try
            {
                Console.WriteLine("Вас приветствует сервис обработки файлов");
                bool isServiceWork = true;
                while (isServiceWork)
                {
                    Console.WriteLine("Пожалуйста, укажите путь к файлу или 'Стоп', чтобы завершить работу сервиса");
                    string? inputFilePath = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputFilePath))
                    {
                        Console.WriteLine("Ошибка: Вы не указали путь!");
                        Console.WriteLine("");
                        continue;
                    }
                    if (inputFilePath.ToLower() == "стоп")
                    {
                        Console.WriteLine("Спасибо, что воспользовались нашим сервисом.");
                        Console.WriteLine("Досвидания.");
                        Console.WriteLine("");
                        isServiceWork = false;
                        continue;
                    }
                    if (!File.Exists(inputFilePath))
                    {
                        Console.WriteLine("Ошибка: По указанному пути файл не найден!");
                        Console.WriteLine("");
                        continue;
                    }
                    CountFileWords(inputFilePath);
                    CountFileWordsFromLines(inputFilePath);
                    CountFileWordsStream(inputFilePath);
                    CountFileWordsStreamFull(inputFilePath);
                    Console.WriteLine("");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            } 

        }

        /// <summary>
        /// Функция подсчета слов путем чтения целого файла.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        static void  CountFileWords(string inputFilePath)
        {
            DateTime strart = DateTime.UtcNow;
            string textFile = File.ReadAllText(inputFilePath);
            string[] words = textFile.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsCount = words.Length;
            DateTime finish = DateTime.UtcNow;
            var timeStamp = finish - strart;

            Console.WriteLine($"Количество слов (чтение всего файла): {wordsCount}");
            Console.WriteLine($"Время затраченное на обработку: {timeStamp}");
        }

        /// <summary>
        /// Функция подсчета слов путем чтения целого файла в массив строк.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        static void CountFileWordsFromLines(string inputFilePath)
        {
            DateTime strart = DateTime.UtcNow;
            string[] textFile = File.ReadAllLines(inputFilePath);
            int wordsCount = 0;
            foreach (var line in textFile)
            {
                string[] words = line.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                wordsCount = wordsCount + words.Length;
            }
            DateTime finish = DateTime.UtcNow;
            var timeStamp = finish - strart;

            Console.WriteLine($"Количество слов (построковая обработка): {wordsCount}");
            Console.WriteLine($"Время затраченное на обработку: {timeStamp}");
        }

        /// <summary>
        /// Функция подсчета слов путем потокового чтения файла частями.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        static void CountFileWordsStream(string inputFilePath)
        {
            DateTime strart = DateTime.UtcNow;
            using (FileStream fstream = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[64];
                StringBuilder stringBuilder = new StringBuilder();
                int bytesRead;

                while ((bytesRead = fstream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string textFromBuffer = Encoding.Default.GetString(buffer, 0, bytesRead);
                    stringBuilder.Append(textFromBuffer);
                }
                string textFile = stringBuilder.ToString();
                string[] words = textFile.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var wordsCount = words.Length;
                DateTime finish = DateTime.UtcNow;
                var timeStamp = finish - strart;

                Console.WriteLine($"Количество слов (потоковая обработка частями): {wordsCount}");
                Console.WriteLine($"Время затраченное на обработку: {timeStamp}");

            }
        }

        /// <summary>
        /// Функция подсчета слов путем потокового чтения файла целиком.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        static void CountFileWordsStreamFull(string inputFilePath)
        {
            DateTime strart = DateTime.UtcNow;
            using (FileStream fstream = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFile = Encoding.Default.GetString(buffer);
                string[] words = textFile.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var wordsCount = words.Length;
                DateTime finish = DateTime.UtcNow;
                var timeStamp = finish - strart;

                Console.WriteLine($"Количество слов (потоковая обработка всего файла): {wordsCount}");
                Console.WriteLine($"Время затраченное на обработку: {timeStamp}");
            }
        }
    }
}

//B:\Обучение\CSharp\voyna-i-mir-tom-1.txt
