Console.Write("Введите имя: ");
var name = Console.ReadLine();
Console.Write("Введите фамилию: ");
var surname = Console.ReadLine();
//цикл для правильного ввода числа
while (true) {
    Console.Write("Введите год рождения: ");
    var age = Console.ReadLine();
    if (int.TryParse(age, out int nage)){ 
        Console.WriteLine($"Добавлен пользователь {name} {surname}, возраст: {2026-nage}");
        break;
    }
    else
    {   
        Console.WriteLine("Введитп  число в дату рождения!");
    }
}
