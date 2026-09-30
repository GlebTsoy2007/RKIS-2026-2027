var mainList = new TodoList();
var us = new User(Register());
var comd = new InputCommand(us,mainList);
comd.InputLoop();

















//Функция регистрации данных пользователя
string[] Register()
{   
    string name = "";
    string surname = "";
    string bithday;

    // Проверяем имя на пустой ввод
    while (string.IsNullOrWhiteSpace(name)){
        Console.Write("Введите имя: ");
        name = Console.ReadLine().Trim();
    }

    // Поверям фамилию на пустой ввод
    while (string.IsNullOrWhiteSpace(surname)){
        Console.Write("Введите фамилию: ");
        surname = Console.ReadLine().Trim();
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


// Класс списка дел
public class TodoList
{
    private string[] taskList = new string[2];
    private bool[] statusList = new bool[2];
    private DateTime[] dateList = new DateTime[2];
    private int taskCount = 0;

    public TodoList()
    {

    }
    // Функция проверки наличия новой задачи
    public void CheckItemToList(string command)
    {
        if (taskList.Contains(command.Substring(4)))
        {
            Console.WriteLine("Нельзя записывать одни и те же дела");
        }
        else
        {
            this.Append(command.Substring(4));
            Console.WriteLine($"Добавлена задача: {command.Substring(4)}");
        }
    }
    public void DoneTask(string commandIndexDone)
    {
        string indexString = commandIndexDone.Substring(5);
        if (int.TryParse(indexString, out int index)){ 
            statusList[index] = true;
            dateList[index] = DateTime.Now;
            Console.WriteLine($"У задачи \"{taskList[index]}\" статус изменен на {statusList[index]} и время на {dateList[index]}");
        }
        else
        {   
            Console.WriteLine("Необходимо записывать число в поле индекса!");
        }
    }

    //Функция добавления новой задачи
    public void Append(string task)
    {
        if (taskCount+1 > taskList.Length)
        {
            string[] copyTaskList = new string[taskList.Length + 2];
            bool[] copyStatusList = new bool[statusList.Length + 2];
            DateTime[] copyDateList = new DateTime[dateList.Length + 2];
            int countIndexForeach = 0;
            foreach (string copyTask in taskList)
            {
                copyTaskList[countIndexForeach] = copyTask;
                countIndexForeach ++;
            } 
            countIndexForeach = 0;
            foreach (bool copyStatus in statusList)
            {
                copyStatusList[countIndexForeach] = copyStatus;
                countIndexForeach ++;
            }
            countIndexForeach = 0;
            foreach (DateTime copyData in dateList)
            {
                copyDateList[countIndexForeach] = copyData;
                countIndexForeach ++;
            } 
            taskList = copyTaskList;
            statusList = copyStatusList;
            dateList = copyDateList;
        }
        taskList[taskCount] = task;
        statusList[taskCount] = false;
        dateList[taskCount] = DateTime.Now; 
        taskCount ++;
    }
    // Функция вывода списка задач
    public void ListPrint()
    {
        string text = "---СПИСОК ДЕЛ--- ";
        foreach (var task in taskList)
        {   
            int taskIndex = Array.IndexOf(taskList,task);
            text = text + "\n" + $"{Array.IndexOf(taskList,task)}. {task} {statusList[taskIndex]} {dateList[taskIndex]}";


        }
        Console.WriteLine(text);
    }

}
// Класс для обработки команд
public class InputCommand
{
    public string cmd;
    private User _user;
    private TodoList _list;

    public InputCommand(User us,TodoList list)
    {
        string cmd;
        _user = us;
        _list = list;
    }
    // Цикл обрабатывающий команды
    public void InputLoop()
    {
        while (true)
        {
            Console.Write("Введите команду: ");
            cmd = Console.ReadLine();
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
                View();
            }
            else if (cmd.StartsWith("add"))
            {
                AddList(cmd);
            }
            else if (cmd.StartsWith("done"))
            {
                DoneList(cmd);
            }
            else if (cmd == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Данной команды не существует, help - справочник.");
            }
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

    private void View()
    {
        _list.ListPrint();
    }

    private void AddList(string text)
    {
        _list.CheckItemToList(text);
    }
    private void DoneList(string text)
    {
        _list.DoneTask(text);
    }

}