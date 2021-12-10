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
            this.listView1 = new System.Windows.Forms.ListView();
            this.UID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BinSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refreshButton = new System.Windows.Forms.Button();
            this.autoRefreshCheck = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clearCacheButton = new System.Windows.Forms.Button();
            this.totalTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UID,
            this.CName,
            this.BinSize});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(760, 527);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // UID
            // 
            this.UID.Text = "UID";
            this.UID.Width = 147;
            // 
            // CName
            // 
            this.CName.Text = "Process";
            this.CName.Width = 189;
            // 
            // BinSize
            // 
            this.BinSize.Text = "Size";
            this.BinSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BinSize.Width = 104;
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
            this.totalTextBox1.Location = new System.Drawing.Point(420, 562);
            this.totalTextBox1.Name = "totalTextBox1";
            this.totalTextBox1.ReadOnly = true;
            this.totalTextBox1.Size = new System.Drawing.Size(136, 20);
            this.totalTextBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 562);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalTextBox1);
            this.Controls.Add(this.clearCacheButton);
            this.Controls.Add(this.autoRefreshCheck);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "NVIDIA Cache size";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader CName;
        private System.Windows.Forms.ColumnHeader BinSize;
        private System.Windows.Forms.ColumnHeader UID;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox autoRefreshCheck;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button clearCacheButton;
        private System.Windows.Forms.TextBox totalTextBox1;
        private System.Windows.Forms.Label label1;
    }
}

