using Lesson11;
using Microsoft.Extensions.Configuration;

try
{
    /*IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();
    var connectionString = configuration.GetSection("ConnectionString").GetSection("Default").Value;
    if (connectionString == null) throw new Exception("Не удалось получить строку подключения к базе данных.");*/
    using var dbContext = new ApplicationContext();//connectionString);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
