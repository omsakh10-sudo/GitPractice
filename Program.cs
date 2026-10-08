using System;
using System.Collections.Generic;
using System.Linq;
Console.Title = "ETMS";
List<TaskItem> tasks = new()
{
   new TaskItem(1, "Review API documentation", "Salah"),
   new TaskItem(2, "Test login functionality", "Ahmad"),
   new TaskItem(3, "Prepare Git repository", "Salah")
};
bool isRunning = true;
while (isRunning)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("         COMPANY TASK TRACKER");
    Console.WriteLine("========================================");
    Console.WriteLine();
    Console.WriteLine("1. View Tasks");
    Console.WriteLine("2. Add New Task");
    Console.WriteLine("3. Complete Task");
    Console.WriteLine("4. Delete Task");
    Console.WriteLine("5. Exit");
    Console.WriteLine();
    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            ShowTasks();
            break;
        case "2":
            AddTask();
            break;
        case "3":
            CompleteTask();
            break;
        case "4":
            DeleteTask();
            break;
        case "5":
            isRunning = false;
            Console.WriteLine("Application closed.");
            break;
        default:
            Console.WriteLine("Invalid option.");
            Pause();
            break;
    }
}
void ShowTasks()
{
    Console.Clear();
    Console.WriteLine("========== TASK LIST ==========");
    Console.WriteLine();
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        Pause();
        return;
    }
    foreach (TaskItem task in tasks)
    {
        string status = task.IsCompleted ? "Completed" : "Pending";
        Console.WriteLine($"ID: {task.Id}");
        Console.WriteLine($"Task: {task.Title}");
        Console.WriteLine($"Assigned To: {task.AssignedTo}");
        Console.WriteLine($"Status: {status}");
        Console.WriteLine($"Created: {task.CreatedAt:dd/MM/yyyy HH:mm}");
        Console.WriteLine("--------------------------------");
    }
    Pause();
}
void AddTask()
{
    Console.Clear();
    Console.WriteLine("========== ADD TASK ==========");
    Console.WriteLine();
    Console.Write("Task title: ");
    string? title = Console.ReadLine();
    Console.Write("Assigned to: ");
    string? assignedTo = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(title) ||
        string.IsNullOrWhiteSpace(assignedTo))
    {
        Console.WriteLine();
        Console.WriteLine("Title and employee name are required.");
        Pause();
        return;
    }
    int newId = tasks.Count == 0
        ? 1
        : tasks.Max(task => task.Id) + 1;
    TaskItem newTask = new(
        newId,
        title,
        assignedTo
    );
    tasks.Add(newTask);
    Console.WriteLine();
    Console.WriteLine("Task added successfully.");
    Pause();
}
void CompleteTask()
{
    Console.Clear();
    Console.WriteLine("========== COMPLETE TASK ==========");
    Console.WriteLine();
    foreach (TaskItem task in tasks)
    {
        string status = task.IsCompleted ? "Completed" : "Pending";
        Console.WriteLine(
            $"{task.Id} - {task.Title} [{status}]"
        );
    }
    Console.WriteLine();
    Console.Write("Enter task ID: ");
    bool validId = int.TryParse(
        Console.ReadLine(),
        out int taskId
    );
    if (!validId)
    {
        Console.WriteLine("Invalid task ID.");
        Pause();
        return;
    }
    TaskItem? selectedTask =
        tasks.FirstOrDefault(task => task.Id == taskId);
    if (selectedTask == null)
    {
        Console.WriteLine("Task not found.");
        Pause();
        return;
    }
    if (selectedTask.IsCompleted)
    {
        Console.WriteLine("Task is already completed.");
        Pause();
        return;
    }
    selectedTask.IsCompleted = true;
    Console.WriteLine();
    Console.WriteLine("Task completed successfully.");
    Pause();
}
void DeleteTask()
{
    Console.Clear();
    Console.WriteLine("========== DELETE TASK ==========");
    Console.WriteLine();
    foreach (TaskItem task in tasks)
    {
        Console.WriteLine($"{task.Id} - {task.Title}");
    }
    Console.WriteLine();
    Console.Write("Enter task ID to delete: ");
    bool validId = int.TryParse(
        Console.ReadLine(),
        out int taskId
    );
    if (!validId)
    {
        Console.WriteLine("Invalid task ID.");
        Pause();
        return;
    }
    TaskItem? selectedTask =
        tasks.FirstOrDefault(task => task.Id == taskId);
    if (selectedTask == null)
    {
        Console.WriteLine("Task not found.");
        Pause();
        return;
    }
    tasks.Remove(selectedTask);
    Console.WriteLine();
    Console.WriteLine("Task deleted successfully.");
    Pause();
}
void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string AssignedTo { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public TaskItem(
        int id,
        string title,
        string assignedTo)
    {
        Id = id;
        Title = title;
        AssignedTo = assignedTo;
        IsCompleted = false;
        CreatedAt = DateTime.Now;
    }
}

        