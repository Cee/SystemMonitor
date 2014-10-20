using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Threading;

namespace SystemMonitor
{
    public class SystemMonitor
    {

        #region Get CPU Usage
        #region Private Static Var
        private static Dictionary<int, PerformanceCounter> _counterPool;
        private static Dictionary<int, DateTime> _updateTimePool;
        private static Dictionary<int, int> _cpuUsagePool;
        #endregion

        #region Private Static Property
        private static Dictionary<int, PerformanceCounter> m_CounterPool
        {
            get
            {
                return _counterPool ?? (_counterPool = new Dictionary<int, PerformanceCounter>());
            }
        }

        private static Dictionary<int, DateTime> m_UpdateTimePool
        {
            get
            {
                return _updateTimePool ?? (_updateTimePool = new Dictionary<int, DateTime>());
            }
        }

        private static Dictionary<int, int> m_CpuUsagePool
        {
            get
            {
                return _cpuUsagePool ?? (_cpuUsagePool = new Dictionary<int, int>());
            }
        }
        #endregion

        
        private static string GetProcessInstanceName(int pid)
        {
            var category = new PerformanceCounterCategory("Process");
            var instances = category.GetInstanceNames();
            foreach (var instance in instances)
            {
                using (var counter = new PerformanceCounter(category.CategoryName, "ID Process", instance, true)){
                    int val = (int)counter.RawValue;
                    if (val == pid)
                    {
                        return instance;
                    }
                }
            }
            throw new ArgumentException("Invalid pid!");
        }

        private static int GetCpuUsage(int pid)
        {
            if (!m_CounterPool.ContainsKey(pid))
            {
                try
                {
                    m_CounterPool.Add(pid, new PerformanceCounter("Process", "% Processor Time", GetProcessInstanceName(pid)));
                }
                catch
                {
                    //Do nothing
                }
            }
            var lastUpdateTime = default(DateTime);
            m_UpdateTimePool.TryGetValue(pid, out lastUpdateTime);
            var interval = DateTime.Now - lastUpdateTime;
            if (interval.TotalSeconds > 1)
            {
                try
                {
                    m_CpuUsagePool[pid] = (int)(m_CounterPool[pid].NextValue() / Environment.ProcessorCount);
                }
                catch
                {
                    //Do nothing
                }
            }
            if (m_CounterPool != null)
            {
                return m_CpuUsagePool[pid];
            }
            else
            {
                return 0;
            }
            

        }
        #endregion


        private string GetProcessOwner(int pid)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + pid;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return user
                    return argList[0];
                }
            }

            return "SYSTEM";
        }

        public List<MyProcess> getProcess()
        {
            
            List<MyProcess> ret = new List<MyProcess>();
            Process[] processList = Process.GetProcesses(".");

            foreach (Process p in processList)
            {
                int pid = p.Id;
                string pName = p.ProcessName;
                string pOwner;
                try
                {
                    pOwner = GetProcessOwner(p.Id);
                }
                catch
                {
                    pOwner = "SYSTEM";
                }
                string pDescription;
                try
                {
                    pDescription = p.MainModule.FileVersionInfo.FileDescription;
                }
                catch
                {
                    pDescription = "";
                }
                float pMem = p.WorkingSet64 / 1024;
                int pCpu;
                try
                {
                    pCpu = GetCpuUsage(pid);
                }
                catch
                {
                    pCpu = 0;
                }
                
                //Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", pid, pName, pOwner, pDescription, pMem, pCpu);
                ret.Add(new MyProcess(pid, pName, pOwner, pDescription, pMem, pCpu));
            }
            return ret;
        }

        public List<MyProcess> sortByPid()
        {
            throw new NotImplementedException();
        }

        public List<MyProcess> sortByName()
        {
            throw new NotImplementedException();
        }

        public List<MyProcess> sortByOwner()
        {
            throw new NotImplementedException();
        }

        public List<MyProcess> sortByDes()
        {
            throw new NotImplementedException();
        }

        public List<MyProcess> sortByMem()
        {
            throw new NotImplementedException();
        }

        public List<MyProcess> sortByCpu()
        {
            throw new NotImplementedException();
        }

        public bool kill(int pid)
        {
            throw new NotImplementedException();
        }
    }
}
