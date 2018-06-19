using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using CollectorTools;

namespace RawCollectorService
{
    partial class RawCollectorService : ServiceBase
    {
        System.Threading.Timer _timer;
        Collector _collector;

        public RawCollectorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            _collector = new Collector();
            _timer = new System.Threading.Timer(new System.Threading.TimerCallback(Collect), null,10*1000, 1000*60);
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            _timer.Dispose();
            _timer = null;
            _collector = null;
        }

        private void Collect(object obj)
        {
            var proc = _collector.GetProcess().OrderByDescending(x => x.WorkingSet64);
            var newList = proc.Take(30).ToList();
            for (int i = 0; i < newList.Count; i++)
            {
                _collector.CollectProcess(newList[i].ID);
            }
        }
    }
}
