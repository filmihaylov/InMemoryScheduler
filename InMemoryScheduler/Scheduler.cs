using InMemoryScheduler.Models;

namespace InMemoryScheduler
{
    public static class Scheduler
    {
        public static Job BuildJob(string name, bool singleExecution, TimeSpan timeSpan , Action jobToBeExecuted)
        {
            var job = new Job();
            job.Id = new Guid();
            job.SingleExecution = singleExecution;
            job.Stop = false;
            job.Start = false;
            job.Name = name;
            job.TimeIntervalOfExecution = timeSpan;
            job.ScheduledJob = new Job.JobToBeExecuted(jobToBeExecuted);

            return job;
        }

        public static void AddJob(Job job)
        {

        }

        public static void RemoveJob(int id)
        {

        }

    }
}
