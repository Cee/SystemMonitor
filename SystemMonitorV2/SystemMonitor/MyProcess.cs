using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor
{
    public class MyProcess
    {
        public string Process_Name { get; set; }
        public int PID { get; set; }
        public string Process_Owner { get; set; }
        public float Memory_Usage { get; set; }
        public int CPU_Usage { get; set; }
        public string Description { get; set; }

        public MyProcess(int pid, string pName, string owner, string des, float memory, int cpu)
        {
            this.PID = pid;
            this.Process_Name = pName;
            this.Process_Owner = owner;
            this.Description = des;
            this.Memory_Usage = memory;
            this.CPU_Usage = cpu;
        }
    }

    public class pidComparer : IComparer<MyProcess>
    {
        public int Compare(MyProcess x, MyProcess y)
        {
            return (x.PID.CompareTo(y.PID));
        }
    }

    public class nameComparer : IComparer<MyProcess>
    {
        public int Compare(MyProcess x, MyProcess y)
        {
            return (x.Process_Name.CompareTo(y.Process_Name));
        }
    }

    public class ownerComparer : IComparer<MyProcess>
    {
        public int Compare(MyProcess x, MyProcess y)
        {
            return (x.Process_Owner.CompareTo(y.Process_Owner));
        }
    }

    public class desComparer : IComparer<MyProcess>
    {
        public int Compare(MyProcess x, MyProcess y)
        {
            return (x.Description.CompareTo(y.Description));
        }
    }

    public class memComparer : IComparer<MyProcess>
    {
        public int Compare(MyProcess x, MyProcess y)
        {
            return (x.Memory_Usage.CompareTo(y.Memory_Usage));
        }
    }

    public class cpuComparer : IComparer<MyProcess>
    {
        public int Compare(MyProcess x, MyProcess y)
        {
            return (x.CPU_Usage.CompareTo(y.CPU_Usage));
        }
    }
}
