using InMemoryScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace InMemoryScheduler
{
    internal class Executor
    {
        private Queue<Job> jobsQue;
        private Task runnerTask;
        public ILogger? logger { get; set; }

        public Executor()
        {
            this.jobsQue = new Queue<Job>();
            this.runnerTask = this.runner();
            runnerTask.Start();
        }

        public void AddJob(Job job)
        {
            jobsQue.Enqueue(job);
        }

        private Task runner()
        {
            var runnerTask = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (jobsQue.Count == 0)
                    {
                        continue;
                    }
                    var job = jobsQue.Dequeue();
                    if (job.delete)
                    {
                        continue;
                    }
                    jobsQue.Enqueue(job);
                    var jobManager = new JobsManager(job);
                    if (jobManager.CheckIfJobIsReadyForExecution())
                    {
                        Task.Run(() =>
                        {
                            try
                            {
                                if (job.ScheduledJob != null)
                                    job.ScheduledJob();
                            }
                            catch (Exception ex)
                            {
                                if (logger != null)
                                {
                                    logger.LogError($"Job Name : {job.Name} , Job Id : {job.Id} Exception Message: " + ex.ToString());
                                }
                            }

                        });
                    }
                }
            });

            return runnerTask;
        }


    }
}
