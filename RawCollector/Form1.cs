using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using CollectorTools;

namespace RawCollector
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        Regex reg = new Regex(@"^[1-9]\d+$");
        List<ProcessInfo> _vList;
        System.Threading.Timer _timer;
        System.Threading.Timer _timerAuto;
        Collector _collector;
        Telerik.WinControls.UI.GridViewListSource _source;

        public Form1()
        {
            InitializeComponent();
            _vList = new List<ProcessInfo>();
            _timer = new System.Threading.Timer(new System.Threading.TimerCallback(RefreshRaw),
                null, 1000, 1000 * 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void RefreshRaw(object obj)
        {
            if (_collector == null)
                _collector = new Collector();
            new System.Threading.Tasks.TaskFactory().StartNew(()=> {
                RefreshProcess();
            });
            radStatusStrip1.Invoke(new Action(()=> {
                lblStatusInfo.Text = _collector.GetMemoryPercent()+" | 当前进程数: "+_vList.Count;
            }));
        }

        private void RefreshProcess()
        {
            bool flag = false;
            var lst = _collector.GetProcess();
            if (_vList.Count == 0)
                _vList.AddRange(lst);
            else
            {
                foreach (ProcessInfo item in lst)
                {
                    var p = _vList.Where(x => x.ID == item.ID).Select(x => x).FirstOrDefault();
                    if (p != null && p.ID > 0)
                        p.WorkingSet64 = item.WorkingSet64;
                    else
                    {
                        flag = true;
                        _vList.Add(item);
                    }
                }
                var ids = lst.Select(x => x.ID).ToArray();
                var ret = _vList.Where(x => !ids.Contains(x.ID)).Select(x => x).ToArray();
                for (int i = 0; i < ret.Length; i++)
                {
                    _vList.Remove(ret[i]);
                }
                if(ret.Length>0)
                    flag = true; 
            }
            var sortList = _vList.OrderByDescending(x=>x.WorkingSet64);

            gvProcess.Invoke(new Action(()=> {
                if (gvProcess.DataSource == null||flag)
                    gvProcess.DataSource = sortList;
                gvProcess.Columns["WorkingSet64"].SortOrder = RadSortOrder.Descending;
                gvProcess.Columns["WorkingSet64"].SortOrder = RadSortOrder.None;
            }));
        }

        private void gvProcess_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName == "WorkingSet64")
            {
                long value = (long)e.CellElement.Value;
                var ret = Math.Round((decimal)value , 2);
                if(ret>1024*1024*1024)
                    e.CellElement.Text = Math.Round((decimal)value / 1024 /1024/1024, 2) + " GB";
                else if (ret > 1024*1024 )
                    e.CellElement.Text = Math.Round((decimal)value / 1024 / 1024, 2) + " MB";
                else if (ret > 1024 )
                    e.CellElement.Text = Math.Round((decimal)value / 1024 , 2) + " KB";
            }
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (gvProcess.SelectedRows.Count == 0)
                return;
            var process = gvProcess.SelectedRows[0].DataBoundItem as ProcessInfo;
            CollectProcess(process);
        }

        private void CollectProcess(ProcessInfo process)
        {
            var ret = _collector.CollectProcess(process.ID);
            lsvLog.Invoke(new Action(()=> {
                lsvLog.Items.Add(new Telerik.WinControls.UI.ListViewDataItem("", 
                    new string[] { DateTime.Now.ToString(), process.ProcessName, ret ? "释放成功" : "释放失败" }));
            }));
        }

        private void CollectRaw(object obj)
        {
            int count = gvProcess.Rows.Count;
            if (count > 20)
                count = 20;
            for (int i = 0; i < count; i++)
            {
                var item = gvProcess.Rows[i].DataBoundItem as ProcessInfo;
                CollectProcess(item);
            }
        }

        private void btnCollectTop20_Click(object sender, EventArgs e)
        {
            CollectRaw(null);
        }

        private void chkAuto_CheckStateChanged(object sender, EventArgs e)
        {
            txtTimeSpan.Enabled = chkAuto.Checked;
            if (chkAuto.Checked)
            {
                _timerAuto = new System.Threading.Timer(new System.Threading.TimerCallback(CollectRaw), 
                    null, 1000, 1000 * 60 * int.Parse(txtTimeSpan.Text));
            }
            else
                _timer.Dispose();
        }

        private void txtTimeSpan_TextChanging(object sender, TextChangingEventArgs e)
        {
            var newValue = reg.Match(e.NewValue);
            if (newValue.Length!=e.NewValue.Length)
                e.Cancel=true;
        }
    }
}
