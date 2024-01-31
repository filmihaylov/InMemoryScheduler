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
        private IList<Job> jobs;
        private Queue<Job> jobsQue;

        public Executor()
        {
            this.jobs = new List<Job>();
            this.jobsQue = new Queue<Job>();
            this.runner().Start();
        }

        public void AddJob(Job job)
        {
            jobs.Add(job);
            jobsQue.Enqueue(job);
        }

        public void RemoveJob(Job job)
        {
            jobs.Remove(job);
        }

        private Task runner()
        {
            var runnerTask = new Task(() => { 
            while (true)
                {
                    foreach (var job in jobsQue) {

                        if (jobs.Contains(job))
                        {
                            var jobManager = new JobsManager(job);
                            if (jobManager.checkIfJobIsReadyForExecution())
                            {
                                Task.Run(() => {

                                    if (job.ScheduledJob != null)
                                        job.ScheduledJob();
                                   
                                    });
                            }
                            
                        }
                        
                    }

                }
            
            
            
            });

            return runnerTask;
        }


    }
}
