A simple in memory scheduler that can be used to schedule jobs.

To create a Job you need to use Scheduler.BuildJob

then add the job to the scheduler
Scheduler.AddJob(job)

you can also stop a job with:
        public static void RemoveJob(Job job)

and you can set a logger with:
Scheduler.SetLogger(logger);


Eample ussage:

using InMemoryScheduler;
using InMemoryScheduler.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


Console.WriteLine("Hello, World!");

Job job = Scheduler.BuildJob("JobTest", false, TimeSpan.FromSeconds(5) , () => Console.WriteLine("sssss"));
Job job1 = Scheduler.BuildJob("JobTest", false, TimeSpan.FromSeconds(5), () => Console.WriteLine("test2"));
Job job2 = Scheduler.BuildJob("JobTest", false, TimeSpan.FromSeconds(5), () => Console.WriteLine("test3"));
Job job3 = Scheduler.BuildJob("JobTest", false, TimeSpan.FromSeconds(5), () => Console.WriteLine("test4"));


using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = loggerFactory.CreateLogger<Program>();

Scheduler.SetLogger(logger);

Scheduler.AddJob(job);
Scheduler.AddJob(job1);
Scheduler.AddJob(job2);
Scheduler.AddJob(job3);

Console.ReadLine();
