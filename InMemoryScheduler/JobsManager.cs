using InMemoryScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryScheduler
{
    internal class JobsManager
    {
        private Job job;

        public JobsManager(Job job) 
        { 
            this.job = job;
        }

        public bool checkIfJobIsReadyForExecution()
        {
            if (this.job.SingleExecution)
            {
                return true;
            }
            else { return false; }
        }
    }
}
