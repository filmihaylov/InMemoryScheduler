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

        public bool CheckIfJobIsReadyForExecution()
        {
            if (!this.checkIfJobShouldBeExecute())
            {
                return false;
            }
            else if (this.checkIfStartImedate())
            {
                this.job.executedTimes++;
                return true;
            }
            else if (this.checkIfTimeHasPassed())
            {
                this.job.executedTimes++;
                return true;
            }
            else { return false; }
        }


        private bool checkIfTimeHasPassed()
        {
            if ((DateTime.UtcNow - job.startTime) >= job.TimeIntervalOfExecution)
            {
                job.startTime = DateTime.UtcNow;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkIfStartImedate()
        {
            if (this.job.StartImediate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkIfJobShouldBeExecute()
        {
            if (this.job.Stop)
            {
                this.job.delete = true;
                return false;
            }
            else if (this.job.SingleExecution && this.job.executedTimes > 0)
            {
                this.job.delete = true;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}