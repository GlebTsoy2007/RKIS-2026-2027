string viewTodos(string[] list)
{   string text = "Список дел: ";
    foreach (var i in list)
    {   
        if (Array.IndexOf(list,i) == 0 )
        {
            text = text + "" + i;
        }
        else
        {
            text = text + ", " + i;
        }
        
    }
    return text;
    
}


Console.Write("Введите имя: ");
var name = Console.ReadLine();
Console.Write("Введите фамилию: ");
var surname = Console.ReadLine();
//цикл для правильного ввода числа
string age;
while (true) {
    Console.Write("Введите год рождения: ");
    age = Console.ReadLine();
    if (int.TryParse(age, out int nage)){ 
        Console.WriteLine($"Добавлен пользователь {name} {surname}, возраст: {2026-nage}");
        break;
    }
    else
    {   
        Console.WriteLine("Введитп  число в дату рождения!");
    }
}

string[] todos = new string[2];
int todosFree = 0;
while (true)
    {
        Console.Write("Введите команду: ");
        var command = Console.ReadLine();
        var res = command switch
        {
            "help" => "help - Вызвать список команд\nprofile - Получить данные профиля\nadd \"задача\" - Добавить задачу в список\nview - Вывести все задачи\nexit - Выйти из ежедневника",
            "profile" => $"{name}, {surname}, {age}",
            "view" => $"{viewTodos(todos)}",
            _ => "Команда не найдена"
            
        };
        if  (res == "Команда не найдена")
        {
            if (command.StartsWith("add"))
            {
                if (todos.Contains(command.Substring(4)))
                {
                    res = "Нельзя записывать одни и те же дела";
                }
                else if (todosFree < todos.Length)
                {
                    todos[todosFree] = command.Substring(4);
                    todosFree ++;
                    res = $"Добавлена задача: {command.Substring(4)}";
                }
                else
                {
                    string[] todos2 = new string[todos.Length*2];
                    int todos2Count = 0;
                    foreach (var i in todos)
                    {
                        todos2[todos2Count] = i;
                        todos2Count ++;
                    }
                    todos2Count = 0;
                    todos = todos2;
                    todos[todosFree] = command.Substring(4);
                    todosFree ++;
                }
            }
            else if (command == "exit")
            {
                res = "Осуществлен выход из приложения";
                break;
            }
            
            
        }
        
        Console.WriteLine(res);



    }


// хорошо было придумано писать условия оценивания Шестым пунктом в задание: 6. Делайте коммит после 
// каждого изменения, если задание будет отправлено одним коммитом — задание будет оцениваться в два раза меньше.

// я с 11 часов ночи сидел делал ;( и только в 1:50 прочитал 6 пункт

