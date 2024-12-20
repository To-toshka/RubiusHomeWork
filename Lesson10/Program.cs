using Lesson10;
using Microsoft.Extensions.Configuration;

try
{
    IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();
    var connectionString = configuration.GetSection("ConnectionString").GetSection("Default").Value;
    if (connectionString == null) throw new Exception("Не удалось получить строку подключения к базе данных.");
    using var dbContext = new ApplicationContext(connectionString);
    var userServise = new UserServise(dbContext);
    var menu = new Menu(userServise);
    menu.ShowMenu();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


