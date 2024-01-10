using Lab2;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class TaskManagerTests
{
    [Test]
    public void AddTask_ShouldIncreaseTaskListCount()
    {
        var taskManager = new TaskManager();
        var task = new MyTask { Name = "Test Task", Priority = 1, Deadline = DateTime.Now };
        taskManager.AddTask(task);
        Assert.AreEqual(1, taskManager.taskList.Count);
    }

    [Test]
    public void RemoveTask_ShouldDecreaseTaskListCount()
    {
        var taskManager = new TaskManager();
        var task = new MyTask { Name = "Test Task", Priority = 1, Deadline = DateTime.Now };
        taskManager.AddTask(task);
        taskManager.RemoveTask(task);
        Assert.AreEqual(0, taskManager.taskList.Count);
    }

    [Test]
    public void GetTopPriorityTasks_ShouldReturnEmptyList_WhenTaskListIsEmpty()
    {
        var taskManager = new TaskManager();
        var result = taskManager.GetTopPriorityTasks();
        CollectionAssert.AreEqual(result, new List<MyTask>());
    }
    [Test]
    public void FindTasksByPriority_ShouldReturnMatchingTasks()
    {
        var taskManager = new TaskManager();
        var task1 = new MyTask { Name = "Task 1", Priority = 2, Deadline = DateTime.Now };
        var task2 = new MyTask { Name = "Task 2", Priority = 3, Deadline = DateTime.Now };
        taskManager.AddTask(task1);
        taskManager.AddTask(task2);
        var result = taskManager.FindTasksByPriority(3);
        CollectionAssert.AreEqual(result, new List<MyTask> { task2 });
    }

    [Test]
    public void GetTopPriorityTasks_ShouldReturnTaskWithHighestPriority()
    {
        var taskManager = new TaskManager();
        var task1 = new MyTask { Name = "Task 1", Priority = 2, Deadline = DateTime.Now };
        var task2 = new MyTask { Name = "Task 2", Priority = 3, Deadline = DateTime.Now };
        taskManager.AddTask(task1);
        taskManager.AddTask(task2);
        var result = taskManager.GetTopPriorityTasks();
        CollectionAssert.AreEqual(result, new List<MyTask> { task2 });
    }

    [Test]
    public void GetClosestDeadlineTasks_ShouldReturnEmptyList_WhenTaskListIsEmpty()
    {
        var taskManager = new TaskManager();
        var result = taskManager.GetClosestDeadlineTasks();
        CollectionAssert.IsEmpty(result);
    }

    [Test]
    public void GetClosestDeadlineTasks_ShouldReturnTaskWithClosestDeadline()
    {
        var taskManager = new TaskManager();
        var today = DateTime.Now;
        var task1 = new MyTask { Name = "Task 1", Priority = 2, Deadline = today.AddDays(3) };
        var task2 = new MyTask { Name = "Task 2", Priority = 3, Deadline = today.AddDays(1) };
        taskManager.AddTask(task1);
        taskManager.AddTask(task2);
        var result = taskManager.GetClosestDeadlineTasks();
        CollectionAssert.AreEqual(result, new List<MyTask> { task2 });
    }

    [Test]
    public void AllTasks_ShouldReturnAllTasks_WhenTaskListIsNotEmpty()
    {
        var taskManager = new TaskManager();
        var task1 = new MyTask { Name = "Task 1", Priority = 2, Deadline = DateTime.Now.AddDays(3) };
        var task2 = new MyTask { Name = "Task 2", Priority = 3, Deadline = DateTime.Now.AddDays(1) };
        taskManager.AddTask(task1);
        taskManager.AddTask(task2);
        var result = taskManager.AllTasks();
        CollectionAssert.AreEqual(result, new List<MyTask> { task1, task2 });
    }

    [Test]
    public void AllTasks_ShouldReturnEmptyList_WhenTaskListIsEmpty()
    {
        var taskManager = new TaskManager();
        var result = taskManager.AllTasks();
        CollectionAssert.IsEmpty(result);
    }
}