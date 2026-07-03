using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace open_file
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            BindEvents();
        }

        private void BindEvents()
        {
            // 重启类
            btnAllwinner.Click += (s, e) => RunAdbCommand("reboot efex");
            btnRockchip.Click += (s, e) => RunAdbCommand("reboot loader");
            btnAmlogic.Click += (s, e) => RunAdbCommand("reboot update");

            // 诊断类 - 获取输出并用 Notepad++ 打开
            btnDumpsysInput.Click += (s, e) => {
                string res = GetAdbOutput("shell dumpsys input");
                SaveAndOpenWithNotepadPlusPlus(res, "adb_input_log.txt");
            };

            btnGetPkg.Click += (s, e) => {
                string res = GetAdbOutput("shell \"dumpsys window | grep mCurrentFocus\"");
                if (string.IsNullOrEmpty(res)) res = GetAdbOutput("shell \"dumpsys activity activities | grep mResumedActivity\"");
                SaveAndOpenWithNotepadPlusPlus(res, "adb_package_info.txt");
            };

            // 获取所有安装的包名
            btnGetAllPkgs.Click += (s, e) => {
                // pm list packages 会列出所有包
                // 如果只想看第三方APP，可以改成 "shell pm list packages -3"
                string res = GetAdbOutput("shell pm list packages");
                SaveAndOpenWithNotepadPlusPlus(res, "adb_all_packages.txt");
            };

            // 获取系统所有属性 (getprop)
            btnGetProps.Click += (s, e) => {
                // getprop 会列出系统所有的 build.prop 信息、厂商属性等
                string res = GetAdbOutput("shell getprop");
                SaveAndOpenWithNotepadPlusPlus(res, "adb_system_properties.txt");
            };
        }

        private void SaveAndOpenWithNotepadPlusPlus(string content, string fileName)
        {
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("未能获取到数据，请检查设备连接。");
                return;
            }

            try
            {
                // 1. 将内容保存到本地临时文件
                string filePath = Path.Combine(Application.StartupPath, fileName);
                File.WriteAllText(filePath, content, Encoding.UTF8);

                // 2. 尝试使用 Notepad++ 打开
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "notepad++.exe";
                psi.Arguments = $"\"{filePath}\"";

                try
                {
                    Process.Start(psi);
                }
                catch
                {
                    // 如果系统找不到 notepad++.exe，则使用默认记事本打开
                    Process.Start("notepad.exe", $"\"{filePath}\"");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存或打开文件失败: " + ex.Message);
            }
        }

        private string GetAdbOutput(string cmd)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("adb.exe", cmd);
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.StandardOutputEncoding = Encoding.UTF8;

                using (Process p = Process.Start(psi))
                {
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    return output;
                }
            }
            catch { return ""; }
        }

        private void RunAdbCommand(string cmd)
        {
            try
            {
                Process.Start(new ProcessStartInfo("adb.exe", cmd) { CreateNoWindow = true, UseShellExecute = false });
            }
            catch { }
        }
    }
}