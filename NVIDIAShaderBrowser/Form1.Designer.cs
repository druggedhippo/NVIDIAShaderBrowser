namespace NVIDIAShaderBrowser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.refreshButton = new System.Windows.Forms.Button();
            this.autoRefreshCheck = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clearCacheButton = new System.Windows.Forms.Button();
            this.totalTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.advancedListView1 = new Fluent.Lists.AdvancedListView();
            this.uidColumn = ((Fluent.OLVColumn)(new Fluent.OLVColumn()));
            this.processNameColumn = ((Fluent.OLVColumn)(new Fluent.OLVColumn()));
            this.sizeColumn = ((Fluent.OLVColumn)(new Fluent.OLVColumn()));
            this.deltaColumn = ((Fluent.OLVColumn)(new Fluent.OLVColumn()));
            this.totalDelta = ((Fluent.OLVColumn)(new Fluent.OLVColumn()));
            this.buttonResetTotals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advancedListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 568);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // autoRefreshCheck
            // 
            this.autoRefreshCheck.AutoSize = true;
            this.autoRefreshCheck.Checked = true;
            this.autoRefreshCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRefreshCheck.Location = new System.Drawing.Point(141, 568);
            this.autoRefreshCheck.Name = "autoRefreshCheck";
            this.autoRefreshCheck.Size = new System.Drawing.Size(88, 17);
            this.autoRefreshCheck.TabIndex = 2;
            this.autoRefreshCheck.Text = "Auto Refresh";
            this.autoRefreshCheck.UseVisualStyleBackColor = true;
            this.autoRefreshCheck.CheckedChanged += new System.EventHandler(this.autoRefreshCheck_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clearCacheButton
            // 
            this.clearCacheButton.Location = new System.Drawing.Point(697, 562);
            this.clearCacheButton.Name = "clearCacheButton";
            this.clearCacheButton.Size = new System.Drawing.Size(75, 23);
            this.clearCacheButton.TabIndex = 3;
            this.clearCacheButton.Text = "Clear Cache";
            this.clearCacheButton.UseVisualStyleBackColor = true;
            this.clearCacheButton.Click += new System.EventHandler(this.clearCacheButton_Click);
            // 
            // totalTextBox1
            // 
            this.totalTextBox1.Location = new System.Drawing.Point(349, 562);
            this.totalTextBox1.Name = "totalTextBox1";
            this.totalTextBox1.ReadOnly = true;
            this.totalTextBox1.Size = new System.Drawing.Size(136, 20);
            this.totalTextBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 562);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total";
            // 
            // advancedListView1
            // 
            this.advancedListView1.AllColumns.Add(this.uidColumn);
            this.advancedListView1.AllColumns.Add(this.processNameColumn);
            this.advancedListView1.AllColumns.Add(this.sizeColumn);
            this.advancedListView1.AllColumns.Add(this.deltaColumn);
            this.advancedListView1.AllColumns.Add(this.totalDelta);
            this.advancedListView1.CellEditUseWholeCell = false;
            this.advancedListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uidColumn,
            this.processNameColumn,
            this.sizeColumn,
            this.deltaColumn,
            this.totalDelta});
            this.advancedListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.advancedListView1.FullRowSelect = true;
            this.advancedListView1.GridLines = true;
            this.advancedListView1.HasCollapsibleGroups = false;
            this.advancedListView1.HideSelection = false;
            this.advancedListView1.Location = new System.Drawing.Point(12, 13);
            this.advancedListView1.Name = "advancedListView1";
            this.advancedListView1.ShowGroups = false;
            this.advancedListView1.Size = new System.Drawing.Size(760, 532);
            this.advancedListView1.TabIndex = 6;
            this.advancedListView1.UseCompatibleStateImageBehavior = false;
            this.advancedListView1.UseNotifyPropertyChanged = true;
            this.advancedListView1.View = System.Windows.Forms.View.Details;
            // 
            // uidColumn
            // 
            this.uidColumn.AspectName = "Uid";
            this.uidColumn.IsEditable = false;
            this.uidColumn.Text = "UID";
            this.uidColumn.Width = 155;
            // 
            // processNameColumn
            // 
            this.processNameColumn.AspectName = "ProcessName";
            this.processNameColumn.IsEditable = false;
            this.processNameColumn.Text = "Process";
            this.processNameColumn.Width = 167;
            // 
            // sizeColumn
            // 
            this.sizeColumn.AspectName = "Size";
            this.sizeColumn.IsEditable = false;
            this.sizeColumn.Text = "Size";
            this.sizeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // deltaColumn
            // 
            this.deltaColumn.AspectName = "Delta";
            this.deltaColumn.Text = "Delta Change";
            this.deltaColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.deltaColumn.Width = 96;
            // 
            // totalDelta
            // 
            this.totalDelta.AspectName = "TotalDelta";
            this.totalDelta.Text = "Cummulative Delta";
            // 
            // buttonResetTotals
            // 
            this.buttonResetTotals.Location = new System.Drawing.Point(573, 562);
            this.buttonResetTotals.Name = "buttonResetTotals";
            this.buttonResetTotals.Size = new System.Drawing.Size(75, 23);
            this.buttonResetTotals.TabIndex = 7;
            this.buttonResetTotals.Text = "Reset totals";
            this.buttonResetTotals.UseVisualStyleBackColor = true;
            this.buttonResetTotals.Click += new System.EventHandler(this.buttonResetTotals_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.buttonResetTotals);
            this.Controls.Add(this.advancedListView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalTextBox1);
            this.Controls.Add(this.clearCacheButton);
            this.Controls.Add(this.autoRefreshCheck);
            this.Controls.Add(this.refreshButton);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "NVIDIA Cache size";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox autoRefreshCheck;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button clearCacheButton;
        private System.Windows.Forms.TextBox totalTextBox1;
        private System.Windows.Forms.Label label1;
        private Fluent.Lists.AdvancedListView advancedListView1;
        private Fluent.OLVColumn uidColumn;
        private Fluent.OLVColumn processNameColumn;
        private Fluent.OLVColumn sizeColumn;
        private Fluent.OLVColumn deltaColumn;
        private Fluent.OLVColumn totalDelta;
        private System.Windows.Forms.Button buttonResetTotals;
    }
}

