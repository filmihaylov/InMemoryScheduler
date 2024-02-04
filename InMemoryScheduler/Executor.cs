using InMemoryScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryScheduler
{
    internal class Executor
    {
        private Queue<Job> jobsQue;
        private Task runnerTask;

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
                {       if(jobsQue.Count == 0)
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

                                if (job.ScheduledJob != null)
                                    job.ScheduledJob();

                            });
                        }
                }
            });

            return runnerTask;
        }


    }
}
