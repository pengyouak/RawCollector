using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace CollectorTools
{
    ///  
    /// 系统信息类 - 获取CPU、内存、磁盘、进程信息 
    ///  
    public class SystemInfo 
    { 
        private int m_ProcessorCount = 0;   //CPU个数 
        private PerformanceCounter pcCpuLoad;   //CPU计数器 
        private long m_PhysicalMemory = 0;   //物理内存 

        private const int GW_HWNDFIRST = 0; 
        private const int GW_HWNDNEXT = 2; 
        private const int GWL_STYLE = (-16); 
        private const int WS_VISIBLE = 268435456; 
        private const int WS_BORDER = 8388608; 

        #region AIP声明 
        [DllImport("IpHlpApi.dll")] 
        extern static public uint GetIfTable(byte[] pIfTable, ref uint pdwSize, bool bOrder); 

        [DllImport("User32")] 
        private extern static int GetWindow(int hWnd, int wCmd); 
         
        [DllImport("User32")] 
        private extern static int GetWindowLongA(int hWnd, int wIndx); 

        [DllImport("user32.dll")] 
        private static extern bool GetWindowText(int hWnd, StringBuilder title, int maxBufSize); 

        [DllImport("user32", CharSet = CharSet.Auto)] 
        private extern static int GetWindowTextLength(IntPtr hWnd); 
        #endregion 

        #region 构造函数 
        ///  
        /// 构造函数，初始化计数器等 
        ///  
        public SystemInfo() 
        { 
            //初始化CPU计数器 
            pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total"); 
            pcCpuLoad.MachineName = "."; 
            pcCpuLoad.NextValue(); 

            //CPU个数 
            m_ProcessorCount = Environment.ProcessorCount; 

            //获得物理内存 
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem"); 
            ManagementObjectCollection moc = mc.GetInstances(); 
            foreach (ManagementObject mo in moc) 
            { 
                if (mo["TotalPhysicalMemory"] != null) 
                { 
                    m_PhysicalMemory = long.Parse(mo["TotalPhysicalMemory"].ToString()); 
                } 
            }             
        }  
        #endregion 

        #region CPU个数 
        ///  
        /// 获取CPU个数 
        ///  
        public int ProcessorCount 
        { 
            get 
            { 
                return m_ProcessorCount; 
            } 
        } 
        #endregion 

        #region CPU占用率 
        ///  
        /// 获取CPU占用率 
        ///  
        public float CpuLoad 
        { 
            get 
            { 
                return pcCpuLoad.NextValue(); 
            } 
        } 
        #endregion 

        #region 可用内存 
        ///  
        /// 获取可用内存 
        ///  
        public long MemoryAvailable 
        { 
            get 
            { 
                long availablebytes = 0; 
                //ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PerfRawData_PerfOS_Memory"); 
                //foreach (ManagementObject mo in mos.Get()) 
                //{ 
                //    availablebytes = long.Parse(mo["Availablebytes"].ToString()); 
                //} 
                ManagementClass mos = new ManagementClass("Win32_OperatingSystem"); 
                foreach (ManagementObject mo in mos.GetInstances()) 
                { 
                    if (mo["FreePhysicalMemory"] != null) 
                    { 
                        availablebytes = 1024 * long.Parse(mo["FreePhysicalMemory"].ToString()); 
                    } 
                } 
                return availablebytes; 
            } 
        } 
        #endregion 

        #region 物理内存 
        ///  
        /// 获取物理内存 
        ///  
        public long PhysicalMemory 
        { 
            get 
            { 
                return m_PhysicalMemory; 
            } 
        }
        #endregion

        #region 获得分区信息 
        ///  
        /// 获取分区信息 
        ///  
        public List<DiskInfo> GetLogicalDrives() 
        {
            List<DiskInfo> drives = new List<DiskInfo>(); 
            ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk"); 
            ManagementObjectCollection disks = diskClass.GetInstances(); 
            foreach (ManagementObject disk in disks) 
            { 
                // DriveType.Fixed 为固定磁盘(硬盘) 
                if (int.Parse(disk["DriveType"].ToString()) == (int)DriveType.Fixed) 
                { 
                    drives.Add(new DiskInfo(disk["Name"].ToString(), long.Parse(disk["Size"].ToString()), long.Parse(disk["FreeSpace"].ToString()))); 
                } 
            } 
            return drives; 
        } 
        ///  
        /// 获取特定分区信息 
        ///  
        /// 盘符 
        public List<DiskInfo> GetLogicalDrives(char DriverID) 
        {
            List<DiskInfo> drives = new List<DiskInfo>(); 
            WqlObjectQuery wmiquery = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE DeviceID = ’" + DriverID + ":’"); 
            ManagementObjectSearcher wmifind = new ManagementObjectSearcher(wmiquery); 
            foreach (ManagementObject disk in wmifind.Get()) 
            { 
                if (int.Parse(disk["DriveType"].ToString()) == (int)DriveType.Fixed) 
                { 
                    drives.Add(new DiskInfo(disk["Name"].ToString(), long.Parse(disk["Size"].ToString()), long.Parse(disk["FreeSpace"].ToString()))); 
                } 
            } 
            return drives; 
        }
        #endregion

        #region 获得进程列表 
        ///  
        /// 获得进程列表 
        ///  
        public List<ProcessInfo> GetProcessInfo() 
        {
            List<ProcessInfo> pInfo = new List<ProcessInfo>(); 
            Process[] processes = Process.GetProcesses(); 
            foreach (Process instance in processes) 
            {
                if (instance.ProcessName.ToLower() == "system" 
                    || instance.ProcessName.ToLower() == "system idle process"
                    )
                    continue;
                try 
                { 
                    pInfo.Add(new ProcessInfo(instance.Id, 
                        instance.ProcessName, 
                        instance.TotalProcessorTime.TotalMilliseconds, 
                        instance.WorkingSet64, 
                        instance.MainModule.FileName,
                        instance.MainModule.ModuleName,
                        instance.MainWindowTitle
                        )); 
                } 
                catch { } 
            } 
            return pInfo; 
        } 
        ///  
        /// 获得特定进程信息 
        ///  
        /// 进程名称 
        public List<ProcessInfo> GetProcessInfo(string ProcessName) 
        {
            List<ProcessInfo> pInfo = new List<ProcessInfo>(); 
            Process[] processes = Process.GetProcessesByName(ProcessName); 
            foreach (Process instance in processes)
            {
                if (instance.ProcessName.ToLower() == "system"
                     || instance.ProcessName.ToLower() == "system idle process"
                     )
                    continue;
                try 
                { 
                    pInfo.Add(new ProcessInfo(instance.Id, 
                        instance.ProcessName, 
                        instance.TotalProcessorTime.TotalMilliseconds, 
                        instance.WorkingSet64, 
                        instance.MainModule.FileName,
                        instance.MainModule.ModuleName,
                        instance.MainWindowTitle)); 
                } 
                catch { } 
            } 
            return pInfo; 
        } 
        #endregion 

        #region 结束指定进程 
        ///  
        /// 结束指定进程 
        ///  
        /// 进程的 Process ID 
        public static void EndProcess(int pid) 
        { 
            try 
            { 
                Process process = Process.GetProcessById(pid); 
                process.Kill(); 
            } 
            catch { } 
        } 
        #endregion 
      

        #region 查找所有应用程序标题 
        ///  
        /// 查找所有应用程序标题 
        ///  
        /// 应用程序标题范型 
        public static List<string> FindAllApps(int Handle) 
        {
            List<string> Apps = new List<string>(); 

            int hwCurr; 
            hwCurr = GetWindow(Handle, GW_HWNDFIRST); 

            while (hwCurr > 0) 
            { 
                int IsTask = (WS_VISIBLE | WS_BORDER); 
                int lngStyle = GetWindowLongA(hwCurr, GWL_STYLE); 
                bool TaskWindow = ((lngStyle & IsTask) == IsTask); 
                if (TaskWindow) 
                { 
                    int length = GetWindowTextLength(new IntPtr(hwCurr)); 
                    StringBuilder sb = new StringBuilder(2 * length + 1); 
                    GetWindowText(hwCurr, sb, sb.Capacity); 
                    string strTitle = sb.ToString(); 
                    if (!string.IsNullOrEmpty(strTitle)) 
                    { 
                        Apps.Add(strTitle); 
                    } 
                } 
                hwCurr = GetWindow(hwCurr, GW_HWNDNEXT); 
            } 

            return Apps; 
        } 
        #endregion      
    }

    public class ProcessInfo
    {
        private int id;
        private string processName;
        private double totalMilliseconds;
        private long workingSet64;
        private string fileName;
        private string moduleName;
        private string processTitle;

        public int ID { get { return id; } }
        public string ProcessName { get { return processName; } }
        public double TotalMilliseconds { get { return totalMilliseconds; } }
        public long WorkingSet64 { get { return workingSet64; } set { workingSet64 = value; } }
        public string FileName { get { return fileName; } }
        public string ModuleName { get { return moduleName; } }
        public string ProcessTitle { get { return processTitle; } }

        public ProcessInfo(int id, string processName, double totalMilliseconds, long workingSet64, string fileName, string moduleName, string processTitle)
        {
            this.id = id;
            this.processName = processName;
            this.totalMilliseconds = totalMilliseconds;
            this.workingSet64 = workingSet64;
            this.fileName = fileName;
            this.moduleName = moduleName;
            this.processTitle = processTitle;
        }
    }

    public class DiskInfo
    {
        private string v1;
        private long v2;
        private long v3;

        public DiskInfo(string v1, long v2, long v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
}
