using System.Text;

namespace Lesson7
{
    /// <summary>
    /// Класс описывающий асинхронный сервис для подсчета слов в файле.
    /// </summary>
    public class FileAsyncService
    {
        /// <summary>
        /// Функция запуска работы сервиса.
        /// </summary>
        public static async Task StartService()
        {
            try
            {
                Console.WriteLine("Вас приветствует сервис обработки файлов");
                bool isServiceWork = true;

                while (isServiceWork)
                {
                    Console.WriteLine("Пожалуйста, укажите путь к файлу или 'Стоп', чтобы завершить работу.");
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
                    await CountFileWords(inputFilePath);
                    await CountFileWordsFromLines(inputFilePath);
                    await CountFileWordsStream(inputFilePath);
                    await CountFileWordsStreamFull(inputFilePath);
                    Console.WriteLine("");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            } 

        }

        #region countFunctions
        /// <summary>
        /// Асинхронная функция подсчета слов путем чтения целого файла.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        private static async Task CountFileWords(string inputFilePath)
        {
            try
            {
                DateTime strart = DateTime.UtcNow;
                string textFile = await File.ReadAllTextAsync(inputFilePath);
                string[] words = textFile.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var wordsCount = words.Length;
                DateTime finish = DateTime.UtcNow;
                var timeStamp = finish - strart;

                Console.WriteLine($"Количество слов (чтение всего файла): {wordsCount}");
                Console.WriteLine($"Время затраченное на обработку: {timeStamp}");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
            
        }

        /// <summary>
        /// Асинхронная функция подсчета слов путем чтения целого файла в массив строк.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        private static async Task CountFileWordsFromLines(string inputFilePath)
        {
            try
            {
                DateTime strart = DateTime.UtcNow;
                string[] textFile = await File.ReadAllLinesAsync(inputFilePath);
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
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }            
        }

        /// <summary>
        /// Асинхронная функция подсчета слов путем потокового чтения файла частями.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        private static async Task CountFileWordsStream(string inputFilePath)
        {
            try
            {
                DateTime strart = DateTime.UtcNow;
                using (FileStream fstream = new FileStream(inputFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[64];
                    StringBuilder stringBuilder = new StringBuilder();
                    int bytesRead;

                    while ((bytesRead = await fstream.ReadAsync(buffer, 0, buffer.Length)) > 0)
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
                    Console.WriteLine("");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }            
        }

        /// <summary>
        /// Асинхронная функция подсчета слов путем потокового чтения файла целиком.
        /// </summary>
        /// <param name="inputFilePath">Местоположение файла с его названием и расштрением.</param>
        private static async Task CountFileWordsStreamFull(string inputFilePath)
        {
            try
            {
                DateTime strart = DateTime.UtcNow;
                using (FileStream fstream = new FileStream(inputFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[fstream.Length];
                    await fstream.ReadAsync(buffer, 0, buffer.Length);
                    string textFile = Encoding.Default.GetString(buffer);
                    string[] words = textFile.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    var wordsCount = words.Length;
                    DateTime finish = DateTime.UtcNow;
                    var timeStamp = finish - strart;

                    Console.WriteLine($"Количество слов (потоковая обработка всего файла): {wordsCount}");
                    Console.WriteLine($"Время затраченное на обработку: {timeStamp}");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }            
        }
        #endregion
    }
}