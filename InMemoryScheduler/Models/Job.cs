using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryScheduler.Models
{
    public class Job : IEqualityComparer<Job>
    {
        public delegate void JobToBeExecuted();

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool SingleExecution { get; set; }
        public TimeSpan TimeIntervalOfExecution { get; set; }
        public bool Start {  get; set; }
        public bool Stop { get; set; }
        public JobToBeExecuted? ScheduledJob { get; set; }

        public bool Equals(Job? x, Job? y)
        {
            if(x != null && y != null)
            {
                return x.Id == y.Id;

            }
            else return false;
        }

        public int GetHashCode([DisallowNull] Job obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
