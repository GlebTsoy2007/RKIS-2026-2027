Console.WriteLine("Введите имя:");
var name = Console.ReadLine();
Console.Write("Введите фамилию: ");
var surname = Console.ReadLine();
Console.Write("Введите год рождения: ");
var age = 2026 - int.Parse(Console.ReadLine());

Console.Write($"Добавлен пользователь {name} {surname}, возраст: {age}");