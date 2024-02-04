using InMemoryScheduler.Models;

namespace InMemoryScheduler
{
    public static class Scheduler
    {
        private static Executor executor = new Executor();

        public static Job BuildJob(string name, bool singleExecution, TimeSpan timeSpan, Action jobToBeExecuted)
        {
            var job = new Job
            {
                Id = new Guid(),
                SingleExecution = singleExecution,
                Stop = false,
                StartImediate = false,
                Name = name,
                TimeIntervalOfExecution = timeSpan,
                ScheduledJob = new Job.JobToBeExecuted(jobToBeExecuted)
            };

            return job;
        }

        public static void AddJob(Job job)
        {
            executor.AddJob(job);
        }

        public static void RemoveJob(Job job)
        {
            job.Stop = true;
        }

    }
}
