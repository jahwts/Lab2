﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class MyTaskApp
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();

            do
            {
                Console.WriteLine("1. Добавить новую задачу");
                Console.WriteLine("2. Показать все задачи");
                Console.WriteLine("3. Найти задачу по приоритету");
                Console.WriteLine("4. Показать самую приоритетную задачу");
                Console.WriteLine("5. Показать задачу, которая ближе всех к дедлайну");
                Console.WriteLine("6. Удалить задачу");
                Console.WriteLine("q. Выйти");

                var key = Console.ReadKey();

                Console.WriteLine();

                switch (key.KeyChar)
                {
                    case '1':
                        {
                            var task = CreateTask();
                            taskManager.AddTask(task);
                            break;
                        }
                    case '2':
                        {
                            foreach (var task in taskManager.ShowAllTasks())
                            {
                                DisplayTask(task);
                            }
                            break;
                        }
                    case '3':
                        {
                            Console.Write("Введите приоритет для поиска: ");
                            int searchPriority = int.Parse(Console.ReadLine());
                            var foundTasks = taskManager.FindTasksByPriority(searchPriority);

                            if (foundTasks.Any())
                            {
                                Console.WriteLine($"Найдены задачи с приоритетом {searchPriority}:");

                                foreach (var task in foundTasks)
                                {
                                    Console.WriteLine($"{task.Name} - {task.Deadline}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Задачи с приоритетом {searchPriority} не найдены.");
                            }
                            break;
                        }
                    case '4':
                        {
                            var topPriorityTasks = taskManager.GetTopPriorityTasks();

                            if (topPriorityTasks.Any())
                            {
                                Console.WriteLine("Задачи с наивысшим приоритетом:");
                                foreach (var task in topPriorityTasks)
                                {
                                    DisplayTask(task);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нет задач с наивысшим приоритетом.");
                            }
                            break;
                        }
                    case '5':
                        {
                            var closestDeadlineTasks = taskManager.GetClosestDeadlineTasks();

                            if (closestDeadlineTasks.Any())
                            {
                                Console.WriteLine("Задачи с ближайшим дедлайном:");
                                foreach (var task in closestDeadlineTasks)
                                {
                                    DisplayTask(task);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нет задач с ближайшим дедлайном.");
                            }
                            break;
                        }
                    case '6':
                        {
                            Console.Write("Введите название задачи для удаления: ");
                            string taskNameToRemove = Console.ReadLine();
                            var taskToRemove = taskManager.AllTasks().FirstOrDefault(task => task.Name == taskNameToRemove);

                            if (taskToRemove != null)
                            {
                                taskManager.RemoveTask(taskToRemove);
                            }
                            else
                            {
                                Console.WriteLine("Задача не найдена.");
                            }
                            break;
                        }
                }
            }
            while (Console.ReadKey().KeyChar != 'q');
        }

        static void DisplayTask(MyTask task)
        {
            Console.WriteLine($"{task.Name} - {task.Deadline}");
        }

        static MyTask CreateTask()
        {
            Console.Write("Введите название задачи: ");
            string taskName = Console.ReadLine();
            Console.Write("Введите приоритет: ");
            int priority = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите дедлайн (гггг-мм-дд): ");
            DateTime deadline = DateTime.Parse(Console.ReadLine());
            return new MyTask
            {
                Deadline = deadline,
                IsDone = false,
                Priority = priority,
                Name = taskName
            };
        }
    }
}