using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace CollectorTools
{
    public class Collector
    {
        private SystemInfo _sysInfo;

        // 声明
        [DllImport("psapi.dll")]
        private static extern bool EmptyWorkingSet(IntPtr hProcess);

        public Collector()
        {
            _sysInfo = new SystemInfo();
        }

        public string GetMemoryPercent()
        {
            var a = (decimal)_sysInfo.PhysicalMemory;
            var b = (decimal)_sysInfo.MemoryAvailable;

            return $@"当前内存使用率: {Math.Round(((a - b)/a)*100,2)}%";
        }

        public List<ProcessInfo> GetProcess()
        {
            return _sysInfo.GetProcessInfo();
        }

        public bool CollectProcess(int processPID)
        {
            return EmptyWorkingSet(Process.GetProcessById(processPID).Handle);
        }
    }
}
