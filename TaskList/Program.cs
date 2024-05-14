using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    internal class Program
    {
        static List<Task> taskList = new List<Task>();
        static void Main(string[] args)
        {

            bool exit = false;
            Console.WriteLine("----Welcome to the Task List Application-----");
            Console.WriteLine();

            while (!exit)
            {
                Console.WriteLine("What would you want to do ?");
                Console.WriteLine("Enter 1 to add a task.");
                Console.WriteLine("Enter 2 to read a task.");
                Console.WriteLine("Enter 3 to update the task.");
                Console.WriteLine("Enter 4 to delete task.");
                Console.WriteLine("Enter 5 to exit the program.");
                Console.WriteLine();

            int option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    ReadTask();
                    break;
                case 3:
                    UpdateTask();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine();
                        break;
            }
            }

            Console.WriteLine();
        }
    static void CreateTask()
    {
        Console.WriteLine("Enter task title : ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the task description : ");
        string description = Console.ReadLine();
        taskList.Add(new Task(title, description));
            Console.WriteLine();
        Console.WriteLine("Task created !");
        Console.WriteLine("------------------------------------------");
            Console.WriteLine();

        }

    static void ReadTask()
        {
            if (taskList.Count == 0)
            {
                Console.WriteLine("No task created.");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
            }
            else{
                Console.WriteLine("Tasks :");
                foreach (Task task in taskList)
                {
                    Console.WriteLine($"Title : {task.Title}, Description : {task.Description}");
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
            }
        }


    static void UpdateTask()
        {
            Console.WriteLine("Enter task title to update :");
            string titleToUpdate = Console.ReadLine();
            Task taskToUpdate = taskList.Find(t => t.Title == titleToUpdate);

            if(taskToUpdate != null)
            {
                Console.WriteLine("Enter new title : ");
                string newTitle = Console.ReadLine();
                Console.WriteLine("Enter new description: ");
                string newDescription = Console.ReadLine();

                taskToUpdate.Title = newTitle;
                taskToUpdate.Description = newDescription;
                Console.WriteLine();
                Console.WriteLine("Task updated successfully!");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Task not available.");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
            }
        }

        static void DeleteTask()
        {
            Console.WriteLine("Enter the task title you want to delete: ");
            string titleToDelete = Console.ReadLine();
            Task taskToDelete = taskList.Find(t => t.Title == titleToDelete);

            if(taskToDelete != null)
            {
                taskList.Remove(taskToDelete);
                Console.WriteLine();
                Console.WriteLine("Task deleted successfully!");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Task not found.");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
            }
        }

    }

}

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Task(string title, string description)
    {
        Title = title;
        Description = description;
    }
}