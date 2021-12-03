
using _1201StudentGradesApp;

var studentsConsole = new StudentsConsole();

while(true)
{
    Console.WriteLine("enter command (add,list,choose,update,delete)");
    string command = Console.ReadLine();
    switch (command)
    {
        case "add":
            studentsConsole.ExecuteAdd();
            break;
        case "list":
            studentsConsole.ExecuteList();
            break;
        case "choose":
            studentsConsole.ExecuteChoose();
            break;
        case "update":
            studentsConsole.ExecuteUpdate();
            break;
        case "delete":
            studentsConsole.ExecuteDelete();
            break;
        default:
            break;
    }
}