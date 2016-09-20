using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAA.Suppliers.Ali
{
    public class JobEventArgs : EventArgs
    {
        public Job Job { get; protected set; }

        public JobEventArgs(Job job)
        {
            Job = job;
        }
    }
}
