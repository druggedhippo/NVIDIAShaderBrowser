using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVIDIAShaderBrowser
{
    public partial class Form1 : Form
    {

        String shaderDir = "%localappdata%\\NVIDIA\\DXCache";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doStuff();
        }

        void doStuff()
        { 
            Dictionary<string, List<string>> files = new Dictionary<string, List<string>>();

            string[] binAndTocFiles = Directory.GetFiles(Environment.ExpandEnvironmentVariables(shaderDir), "*.*");
            foreach (string file in binAndTocFiles)
            {
                string uid = getUID(file);
                if (uid != null)
                {
                    if (!files.ContainsKey(uid))
                        files.Add(uid, new List<string>());
                    files[uid].Add(file);
                }
            }

            this.totalTextBox1.Text = FormatBytes(binAndTocFiles.ToList().Sum(x => new FileInfo(x).Length), true);

            // SortedDictionary<string, ListViewItem> items = new SortedDictionary<string, ListViewItem>();
            //listView1.BeginUpdate();
            foreach (KeyValuePair<string, List<string>> entry in files)
            {
                string processName = getProcessName(entry.Value);
                if (processName != null)
                {


                    ListViewItem item;
                    if (listView1.Items.ContainsKey(entry.Key))
                    {
                        item = listView1.Items[entry.Key];
                        //item.SubItems[1].Text = processName;
                        string newSum = (FormatBytes(entry.Value.Sum(s => new FileInfo(s).Length), true));
                        if (!item.SubItems[2].Text.Equals(newSum))
                            item.SubItems[2].Text = newSum;
                    }
                    else
                    {
                        item = new ListViewItem();
                        item.Text = entry.Key;
                        item.Name = entry.Key;
                        item.SubItems.Add(processName);
                        item.SubItems.Add(FormatBytes(entry.Value.Sum(s => new FileInfo(s).Length), true));
                        listView1.Items.Add(item);
                    }
                }
            }

            List<ListViewItem> itemsToRemove = new List<ListViewItem>();
            foreach(ListViewItem i in listView1.Items)
            {
                if (!files.ContainsKey(i.Text))
                    itemsToRemove.Add(i);
            }
            itemsToRemove.ToList().ForEach(x => listView1.Items.Remove(x));
            //listView1.EndUpdate();

        }

        /** Stolen from stackoverflow https://stackoverflow.com/questions/1242266/converting-bytes-to-gb-in-c */
        //note: this is the JLopez answer!!
        /// <summary>
        /// Return size in human readable form
        /// </summary>
        /// <param name="bytes">Size in bytes</param>
        /// <param name="useUnit ">Includes measure unit (default: false)</param>
        /// <returns>Readable value</returns>
        public static string FormatBytes(long bytes, bool useUnit = false)
        {
            string[] Suffix = { " B", " kB", " MB", " GB", " TB" };
            double dblSByte = bytes;
            int i;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }
            return $"{dblSByte:0.##}{(useUnit ? Suffix[i] : null)}";
        }

        string getUID(string path)
        {
            string file = Path.GetFileName(path);
            string[] parts = file.Split('_');
            if (parts.Length > 3)
            {
                return parts[0] + "_" + parts[1] + "_" + parts[2];
            }
            return null;
        }

        string getProcessName(List<string> files)
        {
            try
            {
                foreach (string s in files)
                {
                    string p = getProcessName(s);
                    if (p != null)
                        return p;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        string getProcessName(string file)
        {
            FileStream tocFs = File.OpenRead(file);
            if (tocFs.ReadByte() == 0x44 && tocFs.ReadByte() == 0x58 && tocFs.ReadByte() == 0x44 && tocFs.ReadByte() == 0x43)
            {

                tocFs.Seek(80, SeekOrigin.Begin);
                byte[] processNameB = new byte[255];
                tocFs.Read(processNameB, 0, processNameB.Length);
                return System.Text.Encoding.UTF8.GetString(processNameB, 0, processNameB.Length);
            }
            return null;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            doStuff();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            doStuff();
        }

        private void autoRefreshCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRefreshCheck.Checked)
            {
                timer1.Enabled = true;
            }
            else
                timer1.Enabled = false;
        }

        private void clearCacheButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you really sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                purgeDir();
                //MessageBox.Show("Complete");
            }
        }
        void purgeDir()
        {
            Directory.GetFiles(Environment.ExpandEnvironmentVariables(shaderDir), "*.toc").ToList().ForEach(s =>
            {
                try
                {
                    File.Delete(s);
                }
                catch (Exception ex)
                {

                }
            });
            Directory.GetFiles(Environment.ExpandEnvironmentVariables(shaderDir), "*.bin").ToList().ForEach(s =>
            {
                try
                {
                    File.Delete(s);
                }
                catch (Exception ex)
                {

                }
            });

        }
    }
}
