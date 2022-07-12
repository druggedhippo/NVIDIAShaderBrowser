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
using System.Runtime.CompilerServices;
using Fluent;

namespace NVIDIAShaderBrowser
{
   
    public partial class Form1 : Form
    {
        Dictionary<string, ShaderObject> shaderObjects;
        String shaderDir = "%localappdata%\\NVIDIA\\DXCache";
        public Form1()
        {
            InitializeComponent();
            shaderObjects = new Dictionary<string, ShaderObject>();
            advancedListView1.GetColumn("Size").AspectToStringConverter = delegate (object y) 
            {
                long size = (long)y;
                return FormatBytes(size, true);
            };
            advancedListView1.GetColumn("Delta Change").AspectToStringConverter = delegate (object z)
            {
                if (z != null)
                { 
                    long size = (long)z;
                    return FormatBytes(size, true);
                }
                return "0";
            };
            advancedListView1.GetColumn("Cummulative Delta").AspectToStringConverter = delegate (object z)
            {
                if (z != null)
                {
                    long size = (long)z;
                    return FormatBytes(size, true);
                }
                return "0";
            };
            


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

            foreach (KeyValuePair<string, List<string>> entry in files)
            {
                string processName = getProcessName(entry.Value);
                string key = entry.Key;
                if (processName != null)
                {
                    ShaderObject item;
                    if (shaderObjects.ContainsKey(key))
                    {
                        item = shaderObjects[key];

                        //ring newSum = (FormatBytes(entry.Value.Sum(s => new FileInfo(s).Length), true));
                        long  newSum = ((entry.Value.Sum(s => new FileInfo(s).Length)));
                        long newDelta = newSum - item.Size;
                        if (newDelta != item.Delta)
                        {
                            item.Delta = newDelta;
                            item.TotalDelta += newDelta;
                        }
                        if (newSum != item.Size)
                            item.Size = newSum;

                    }
                    else
                    {
                        item = new ShaderObject();
                        item.Uid = key;
                        item.ProcessName = processName;
                        item.Size = ((entry.Value.Sum(s => new FileInfo(s).Length)));
                        item.Delta = item.Size;
                        //item.TotalDelta += Delta;
                        shaderObjects.Add(item.Uid, item);
                        advancedListView1.AddObject(item);
                    }
                    
                }
            }

            //advancedListView1.SetObjects(shaderObjects.Values);

            //List<ShaderObjectListViewItem> itemsToRemove = new List<ListViewItem>();
            foreach (ShaderObject i in shaderObjects.Values.ToArray())
            {
                if (!files.ContainsKey(i.Uid))
                {
                    shaderObjects.Remove(i.Uid);
                    advancedListView1.RemoveObject(i);
                }
            }

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
                tocFs.Seek(0x08, SeekOrigin.Begin);
                int seekPos = 80;
                /** if the header has this byte, the name seems to start at a different place */
                if (tocFs.ReadByte() == 0x55)
                {
                    seekPos = 72;
                }


                tocFs.Seek(seekPos, SeekOrigin.Begin);
                byte[] processNameB = new byte[255];
                tocFs.Read(processNameB, 0, processNameB.Length);
                processNameB = TrimTailingZeros(processNameB);
                string s =  System.Text.Encoding.UTF8.GetString(processNameB, 0, processNameB.Length).Trim();
                return s;
            }
            return null;
        }

        // https://stackoverflow.com/a/58717282/2499697
        public static byte[] TrimTailingZeros(byte[] arr)
        {
            if (arr == null || arr.Length == 0)
                return arr;
            return arr.Reverse().SkipWhile(x => x == 0).Reverse().ToArray();
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

        private void buttonResetTotals_Click(object sender, EventArgs e)
        {
            this.shaderObjects.Values.ToList().ForEach(x => x.TotalDelta = 0);
        }
    }

    public class ShaderObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string uid;
        private string processName;
        private long size;
        private long delta;
        private long totalDelta;


        public string Uid
        {
            get { return uid;  }
            set { this.uid = value;  }
        }
        public string ProcessName
        {
            get { return processName; }
            set { this.processName = value;  }

        }

        public long Size
        {
            get { return size;  }
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }
        public long Delta
        {
            get { return delta; }
            set
            {
                delta = value;
                OnPropertyChanged();
            }
        }
        public long TotalDelta
        {
            get { return totalDelta; }
            set
            {
                totalDelta = value;
                OnPropertyChanged();
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
