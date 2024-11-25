using Lesson5.Models;

Circle kryg = new Circle(20);
kryg.PrintSquare();
kryg.PrintPerimeter();
kryg.PrintType();
try 
{
    Circle kryg2 = new Circle(-20);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine(kryg.TrySetRadius(-10));



Rectangle praymoygolmnik = new Rectangle(20, 50);
praymoygolmnik.PrintSquare();
praymoygolmnik.PrintPerimeter();
praymoygolmnik.PrintType();
try
{
    praymoygolmnik.TrySetLength(10);
    praymoygolmnik.TrySetLength(0);
    praymoygolmnik.Width = 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
praymoygolmnik.PrintPerimeter();


Triangle treygolnik = new Triangle(10, 5, 10);
treygolnik.PrintType();
treygolnik.PrintSquare();
treygolnik.PrintPerimeter();
var try1 = treygolnik.TrySetBasis(0);
var try2 = treygolnik.TrySetLeftEdg(-10);
var try3 = treygolnik.TrySetRightEdge(20);
var try4 = treygolnik.TrySetBasis(10);
Console.WriteLine($"Результат 1: {try1}; Результат 2: {try2}; Результат 3: {try3}; Результат 4: {try4};");
treygolnik.PrintPerimeter();
try
{
    Triangle treygolnik2 = new Triangle(10, 25, 10);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}