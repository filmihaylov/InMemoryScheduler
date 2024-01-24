using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryScheduler.Models
{
    public class Job
    {
        public delegate void JobToBeExecuted();



        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool SingleExecution { get; set; }
        public TimeSpan TimeIntervalOfExecution { get; set; }
        public bool Start {  get; set; }
        public bool Stop { get; set; }
        public JobToBeExecuted? ScheduledJob { get; set; }
    }
}
