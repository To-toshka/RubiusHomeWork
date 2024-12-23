using Lesson11;

try
{
    using var dbContext = new ApplicationContext();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
