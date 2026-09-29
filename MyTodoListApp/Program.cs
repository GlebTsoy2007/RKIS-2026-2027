var us = new User(Register());
var comd = new InputCommand(us);
comd.Input("profile");


















//Функция регистрации данных пользователя
string[] Register()
{   
    string name;
    string surname;
    string bithday;

    // Проверяем имя на пустой ввод
    while (true){
        Console.Write("Введите имя: ");
        name = Console.ReadLine();
        if (name == "")
        {   
            Console.WriteLine("Нельзя оставлять поле имени пустым");
        }
        else
        {
            break;
        }
    }

    // Поверям фамилию на пустой ввод
    while (true){
        Console.Write("Введите фамилию: ");
        surname = Console.ReadLine();
        if (surname == "")
        {   
            Console.WriteLine("Нельзя оставлять поле фамилии пустым");
        }
        else
        {
            break;
        }
    }

    // Проверяем год рождения на ввод чисел
    while (true) {
        Console.Write("Введите год рождения: ");
        bithday = Console.ReadLine();
        if (int.TryParse(bithday, out int age)){ 
            Console.WriteLine($"Добавлен пользователь {name} {surname}, возраст: {2026-age}");
            break;
        }
        else
        {   
            Console.WriteLine("Введите число в дату рождения!");
        }
    }

    // Выводим данные о пользователе из функции
    string[] userInfoList = {name,surname,bithday};
    return userInfoList;
};


// Класс пользователя
public class User
{
    private string name;
    private string surname;
    private string bithday;

    public User(string[] list)
    {
        name = list[0];
        surname = list[1];
        bithday = list[2];
    }

    public void GetInfoString()
    {
        Console.WriteLine($"{name}, {surname}, {bithday}");
    }
}



public class TodoList
{
    public string[] taskList = new string[2];

    public TodoList()
    {
        
    }

}

public class InputCommand
{
    public string cmd;
    private User _user;

    public InputCommand(User us)
    {
        string cmd;
        _user = us;
    }
    
    public void Input(string cmmd)
    {
        cmd = cmmd;
        if (cmd == "help")
        {
            Help();
        }
        else if (cmd == "profile")
        {
            Profile();
        }
        else if (cmd == "view")
        {
            
        }
        else if (cmd.StartsWith("add"))
        {
            
        }
        else if (cmd == "exit")
        {
            
        }
    }

    private void Help()
    {
        Console.WriteLine("help - Вызвать список команд\n" +
        "profile - Получить данные профиля\n" +
        "add \"задача\" - Добавить задачу в список\n" +
        "view - Вывести все задачи\n" +
        "exit - Выйти из ежедневника");
    }
    
    private void Profile()
    {
        _user.GetInfoString();
    }

}