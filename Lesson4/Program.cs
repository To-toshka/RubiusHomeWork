using Lesson4;
using Lesson4.Models;

//***************** Первая часть ДЗ **************************
/*
NaturalFraction naturalFraction1 = new NaturalFraction(8,4);
NaturalFraction naturalFraction2 = new NaturalFraction(100,1000);
NaturalFraction naturalFraction3 = new NaturalFraction(-5,5,10);

Console.WriteLine(naturalFraction3.ToString());
Console.WriteLine(naturalFraction3);
Console.WriteLine((double)naturalFraction3);
Console.WriteLine(naturalFraction1.ToString());
var result1 = naturalFraction1 + naturalFraction2;
Console.WriteLine(result1.ToString());
var result2 = naturalFraction1 * naturalFraction2;
Console.WriteLine(result2.ToString());
var result3 = naturalFraction1 - naturalFraction2;
Console.WriteLine(result3.ToString());
var result4 = naturalFraction1 / naturalFraction2;
Console.WriteLine(result4.ToString());
var result5 = naturalFraction3 + naturalFraction1;
Console.WriteLine(result5.ToString());
*/
//************************************************************


//***************** Вторая часть ДЗ **************************
AviaTransport airplane = new AviaTransport("Воздушный","Самолет");
AviaTransport helicopter = new AviaTransport("Воздушный", "Вертолет");
AviaTransport airship = new AviaTransport("Воздушный", "Дерижабль");
AviaTransport jetpack = new AviaTransport("Воздушный", "Ракетный ранец");
LandTransport car = new LandTransport("Наземный", "Машина");
LandTransport motorcycle = new LandTransport("Наземный", "Мотоцикл");
LandTransport bicycle = new LandTransport("Наземный", "Велосипед");
LandTransport tank = new LandTransport("Наземный", "Танк");
WaterTransport boat = new WaterTransport("Водный", "Катер");
WaterTransport ship = new WaterTransport("Водный", "Корабль");
WaterTransport yacht = new WaterTransport("Водный", "Яхта");

List<Transport> waterTransportList = new List<Transport> { boat, ship, yacht };
List<Transport> aviaTransportList = new List<Transport> { airplane, helicopter, airship, jetpack };
List<Transport> landTransportList = new List<Transport> { car, motorcycle, bicycle, tank };

Dictionary<string, List<Transport>> transportList = new Dictionary<string, List<Transport>>();

List<string> transportTypes = new List<string> { airplane.TransportType, car.TransportType, ship.TransportType };

transportList.Add(airplane.TransportType, aviaTransportList);
transportList.Add(car.TransportType, landTransportList);
transportList.Add(ship.TransportType, waterTransportList);

Console.WriteLine("Выберите тип транспорта указав его номер:");
foreach (var types in transportTypes)
{
    Console.WriteLine($"{transportTypes.IndexOf(types) + 1}. {types}");
}

ChoiceType();




#region function
/// <summary>
/// Функция выбора типа.
/// </summary>
void ChoiceType()
{
    string? input = Console.ReadLine();
    if (input == null || input == "")
    {
        Console.WriteLine("Ошибка: Данные не введены");
        ChoiceType();
        return;
    }
    if (int.TryParse(input, out int result) && transportTypes != null && result >= 1 && result <= transportTypes.Count())
    {
        Console.WriteLine("Выберете транспортное средство указав его номер:");
        ShowValue(result);
    }
    else
    {
        Console.WriteLine("Ошибка: Номер тип не опознан");
        ChoiceType();
        return;
    }
}

/// <summary>
/// Функция отображения транспортных средства и запуска выбора.
/// </summary>
void ShowValue (int index)
{
    var key = transportTypes[index - 1];
    foreach (var value in transportList[key])
    {
        Console.WriteLine($"{transportList[key].IndexOf(value) + 1}. {value.TransportName}");
    }
    ChoiceValue(key);
}

/// <summary>
/// Функция выбора транспортного средства.
/// </summary>
void ChoiceValue(string key)
{
    string? input = Console.ReadLine();
    if (input == null || input == "")
    {
        Console.WriteLine("Ошибка: Данные не введены");
        ChoiceValue(key);
        return;
    }
    if (int.TryParse(input, out int intResult) && transportList != null && intResult >= 1 && intResult <= transportList[key].Count())
    {
        var transportResult = transportList[key][intResult - 1];
        transportResult.TransportStringOutput();
    }
    else
    {
        Console.WriteLine("Ошибка: Номер транспортного средства не опознан");
        ChoiceValue(key);
        return;
    }
}
#endregion


