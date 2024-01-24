// See https://aka.ms/new-console-template for more information
using InMemoryScheduler;
using InMemoryScheduler.Models;

Console.WriteLine("Hello, World!");

Job job = Scheduler.BuildJob("JobTest", true, TimeSpan.FromSeconds(60) , () => Console.WriteLine("test"));
