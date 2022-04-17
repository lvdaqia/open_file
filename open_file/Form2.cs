using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace open_file
{
    public partial class Form2 : Form
    {
        String path;
        public Form2(String path)
        {
            this.path = path;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread( cmdExcute );
            t.IsBackground = true;
            t.Start( "Settings.bat" );
        }
        private void cmdExcute( Object obj )
        {
            string bat_file = obj as string;
            Process proc = null;
            try
            {
                string targetDir = string.Format(@"C:\Users\85418\source\repos\open_file\bat\");//this is where testChange.bat lies
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = bat_file;
                proc.StartInfo.Arguments = string.Format("10");//this is argument
                //proc.StartInfo.CreateNoWindow = true;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(cmdExcute);
            t.IsBackground = true;
            t.Start("SystemUI.bat");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(cmdExcute);
            t.IsBackground = true;
            t.Start("service_jar.bat");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(cmdExcute);
            t.IsBackground = true;
            t.Start("disable-verity.bat");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            System.IO.File.WriteAllLines(@"E:\\test.bat", WriteBat("package\\app\\Settings"), Encoding.UTF8);
        }
        private string[] WriteBat( String package ) {
            string[] lines = { "adb root", "adb remount", "adb push "+path+"\\\\"+package , "adb reboot" };
            return lines;
        }
    }
}
