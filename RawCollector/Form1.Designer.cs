namespace RawCollector
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "时间");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "进程名");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "消息");
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lsvLog = new Telerik.WinControls.UI.RadListView();
            this.btnCollect = new Telerik.WinControls.UI.RadButton();
            this.txtTimeSpan = new Telerik.WinControls.UI.RadTextBox();
            this.radClock1 = new Telerik.WinControls.UI.RadClock();
            this.chkAuto = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.lblStatusInfo = new Telerik.WinControls.UI.RadLabelElement();
            this.gvProcess = new Telerik.WinControls.UI.RadGridView();
            this.btnCollectTop20 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lsvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radClock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollectTop20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvLog
            // 
            this.lsvLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listViewDetailColumn1.HeaderText = "时间";
            listViewDetailColumn1.Width = 120F;
            listViewDetailColumn2.HeaderText = "进程名";
            listViewDetailColumn2.Width = 250F;
            listViewDetailColumn3.HeaderText = "消息";
            listViewDetailColumn3.Width = 180F;
            this.lsvLog.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3});
            this.lsvLog.ItemSpacing = -1;
            this.lsvLog.Location = new System.Drawing.Point(160, 315);
            this.lsvLog.Name = "lsvLog";
            this.lsvLog.Size = new System.Drawing.Size(580, 187);
            this.lsvLog.TabIndex = 1;
            this.lsvLog.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            // 
            // btnCollect
            // 
            this.btnCollect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollect.Location = new System.Drawing.Point(590, 285);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(150, 24);
            this.btnCollect.TabIndex = 2;
            this.btnCollect.Text = "释放指定进程内存";
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // txtTimeSpan
            // 
            this.txtTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimeSpan.Enabled = false;
            this.txtTimeSpan.Location = new System.Drawing.Point(86, 471);
            this.txtTimeSpan.Name = "txtTimeSpan";
            this.txtTimeSpan.Size = new System.Drawing.Size(45, 20);
            this.txtTimeSpan.TabIndex = 3;
            this.txtTimeSpan.Text = "10";
            this.txtTimeSpan.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtTimeSpan_TextChanging);
            // 
            // radClock1
            // 
            this.radClock1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radClock1.Location = new System.Drawing.Point(12, 333);
            this.radClock1.Name = "radClock1";
            this.radClock1.Size = new System.Drawing.Size(134, 135);
            this.radClock1.TabIndex = 5;
            // 
            // chkAuto
            // 
            this.chkAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAuto.Location = new System.Drawing.Point(21, 472);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(66, 18);
            this.chkAuto.TabIndex = 6;
            this.chkAuto.Text = "自动释放";
            this.chkAuto.CheckStateChanged += new System.EventHandler(this.chkAuto_CheckStateChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel1.Location = new System.Drawing.Point(128, 471);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(23, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "(m)";
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lblStatusInfo});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 509);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(752, 26);
            this.radStatusStrip1.TabIndex = 8;
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.radStatusStrip1.SetSpring(this.lblStatusInfo, false);
            this.lblStatusInfo.Text = "            ";
            this.lblStatusInfo.TextWrap = true;
            // 
            // gvProcess
            // 
            this.gvProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvProcess.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.gvProcess.MasterTemplate.AllowAddNewRow = false;
            this.gvProcess.MasterTemplate.AllowDeleteRow = false;
            this.gvProcess.MasterTemplate.AllowDragToGroup = false;
            this.gvProcess.MasterTemplate.AllowEditRow = false;
            this.gvProcess.MasterTemplate.AllowRowResize = false;
            this.gvProcess.MasterTemplate.AutoGenerateColumns = false;
            this.gvProcess.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "PID";
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.Width = 56;
            gridViewTextBoxColumn2.FieldName = "ProcessName";
            gridViewTextBoxColumn2.HeaderText = "进程名称";
            gridViewTextBoxColumn2.Name = "ProcessName";
            gridViewTextBoxColumn2.Width = 169;
            gridViewTextBoxColumn3.FieldName = "ProcessTitle";
            gridViewTextBoxColumn3.HeaderText = "进程标题";
            gridViewTextBoxColumn3.Name = "ProcessTitle";
            gridViewTextBoxColumn3.Width = 169;
            gridViewTextBoxColumn4.FieldName = "FileName";
            gridViewTextBoxColumn4.HeaderText = "路径";
            gridViewTextBoxColumn4.Name = "FileName";
            gridViewTextBoxColumn4.Width = 226;
            gridViewTextBoxColumn5.FieldName = "WorkingSet64";
            gridViewTextBoxColumn5.HeaderText = "内存占用";
            gridViewTextBoxColumn5.Name = "WorkingSet64";
            gridViewTextBoxColumn5.Width = 91;
            this.gvProcess.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvProcess.MasterTemplate.EnableGrouping = false;
            this.gvProcess.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvProcess.Name = "gvProcess";
            this.gvProcess.ReadOnly = true;
            this.gvProcess.ShowNoDataText = false;
            this.gvProcess.Size = new System.Drawing.Size(728, 267);
            this.gvProcess.TabIndex = 0;
            this.gvProcess.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gvProcess_CellFormatting);
            // 
            // btnCollectTop20
            // 
            this.btnCollectTop20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollectTop20.Location = new System.Drawing.Point(434, 285);
            this.btnCollectTop20.Name = "btnCollectTop20";
            this.btnCollectTop20.Size = new System.Drawing.Size(150, 24);
            this.btnCollectTop20.TabIndex = 9;
            this.btnCollectTop20.Text = "释放前20进程内存";
            this.btnCollectTop20.Click += new System.EventHandler(this.btnCollectTop20_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 535);
            this.Controls.Add(this.btnCollectTop20);
            this.Controls.Add(this.gvProcess);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.txtTimeSpan);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.radClock1);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.lsvLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "内存释放工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lsvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radClock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCollectTop20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadListView lsvLog;
        private Telerik.WinControls.UI.RadButton btnCollect;
        private Telerik.WinControls.UI.RadTextBox txtTimeSpan;
        private Telerik.WinControls.UI.RadClock radClock1;
        private Telerik.WinControls.UI.RadCheckBox chkAuto;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement lblStatusInfo;
        private Telerik.WinControls.UI.RadGridView gvProcess;
        private Telerik.WinControls.UI.RadButton btnCollectTop20;
    }
}

