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
Console.WriteLine("");


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
Console.WriteLine("");


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
Console.WriteLine("");


Trapeze trapeci = new Trapeze(10, 5, 4, 4);
trapeci.PrintType();
trapeci.PrintSquare();
trapeci.PrintPerimeter();
var try5 = trapeci.TrySetBasis(0);
var try6 = trapeci.TrySetLeftEdg(-10);
var try7 = trapeci.TrySetRightEdge(20);
var try8 = trapeci.TrySetTopEdg(10);
var try9 = trapeci.TrySetTopEdg(12);
Console.WriteLine($"Результат 1: {try5}; Результат 2: {try6}; Результат 3: {try7}; Результат 4: {try8}; Результат 5: {try9};");
trapeci.PrintSquare();
trapeci.PrintPerimeter();
try
{
    Trapeze trapeci2 = new Trapeze(25, 10, 2, 2);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    Trapeze trapeci2 = new Trapeze(0, 10, 2, 2);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}