string viewTodos(string[] list)
{   string text = "Список дел: ";
    foreach (var task in list)
    {   
        if (Array.IndexOf(list,task) == 0 )
        {
            text = text + "" + task;
        }
        else
        {
            text = text + ", " + task;
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
        var reslut_cmd = command switch
        {
            "help" => "help - Вызвать список команд\nprofile - Получить данные профиля\nadd \"задача\" - Добавить задачу в список\nview - Вывести все задачи\nexit - Выйти из ежедневника",
            "profile" => $"{name}, {surname}, {age}",
            "view" => $"{viewTodos(todos)}",
            _ => "Команда не найдена"
            
        };
        if  (reslut_cmd == "Команда не найдена")
        {
            if (command.StartsWith("add"))
            {
                if (todos.Contains(command.Substring(4)))
                {
                    reslut_cmd = "Нельзя записывать одни и те же дела";
                }
                else if (todosFree < todos.Length)
                {
                    todos[todosFree] = command.Substring(4);
                    todosFree ++;
                    reslut_cmd = $"Добавлена задача: {command.Substring(4)}";
                }
                else
                {
                    string[] todos2 = new string[todos.Length*2];
                    int todos2Count = 0;
                    foreach (var copy_task in todos)
                    {
                        todos2[todos2Count] = copy_task;
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
                reslut_cmd = "Осуществлен выход из приложения";
                break;
            }
            
            
        }
        
        Console.WriteLine(reslut_cmd);



    }



