using System;
using System.Diagnostics; // 必须引用，用于运行adb进程
using System.Windows.Forms;

namespace open_file
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            BindEvents();
        }

        private void BindEvents()
        {
            // --- 基础控制 ---
            btnPower.Click += (s, e) => SendAdbKey("26");      // KEYCODE_POWER
            btnMute.Click += (s, e) => SendAdbKey("164");     // KEYCODE_VOLUME_MUTE
            btnVolUp.Click += (s, e) => SendAdbKey("24");     // KEYCODE_VOLUME_UP
            btnVolDown.Click += (s, e) => SendAdbKey("25");   // KEYCODE_VOLUME_DOWN
            btnMenu.Click += (s, e) => SendAdbKey("82");      // KEYCODE_MENU
            btnSettings.Click += (s, e) => SendAdbKey("176"); // KEYCODE_SETTINGS

            // --- 方向键与确认 ---
            btnUp.Click += (s, e) => SendAdbKey("19");        // KEYCODE_DPAD_UP
            btnDown.Click += (s, e) => SendAdbKey("20");      // KEYCODE_DPAD_DOWN
            btnLeft.Click += (s, e) => SendAdbKey("21");      // KEYCODE_DPAD_LEFT
            btnRight.Click += (s, e) => SendAdbKey("22");     // KEYCODE_DPAD_RIGHT
            btnOK.Click += (s, e) => SendAdbKey("66");        // KEYCODE_ENTER (部分设备也可用 23)

            // --- 导航 ---
            btnBack.Click += (s, e) => SendAdbKey("4");       // KEYCODE_BACK
            btnHome.Click += (s, e) => SendAdbKey("3");       // KEYCODE_HOME

            // --- 数字键 (0-9) ---
            btn0.Click += (s, e) => SendAdbKey("7");          // KEYCODE_0
            btn1.Click += (s, e) => SendAdbKey("8");          // KEYCODE_1
            btn2.Click += (s, e) => SendAdbKey("9");          // KEYCODE_2
            btn3.Click += (s, e) => SendAdbKey("10");         // KEYCODE_3
            btn4.Click += (s, e) => SendAdbKey("11");         // KEYCODE_4
            btn5.Click += (s, e) => SendAdbKey("12");         // KEYCODE_5
            btn6.Click += (s, e) => SendAdbKey("13");         // KEYCODE_6
            btn7.Click += (s, e) => SendAdbKey("14");         // KEYCODE_7
            btn8.Click += (s, e) => SendAdbKey("15");         // KEYCODE_8
            btn9.Click += (s, e) => SendAdbKey("16");         // KEYCODE_9

            // --- 符号与功能 ---
            btnDot.Click += (s, e) => SendAdbKey("56");       // KEYCODE_PERIOD (.)
            btnDel.Click += (s, e) => SendAdbKey("67");       // KEYCODE_DEL (退格删除)
        }

        /// <summary>
        /// 执行ADB发送指令的方法
        /// </summary>
        /// <param name="keycode">安卓键值</param>
        private void SendAdbKey(string keycode)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "adb.exe";          // 确保 adb 在环境变量中
                startInfo.Arguments = $"shell input keyevent {keycode}";
                startInfo.CreateNoWindow = true;         // 不显示黑窗口
                startInfo.UseShellExecute = false;       // 必须为false才能隐藏窗口
                startInfo.RedirectStandardError = true;  // 重定向错误

                using (Process process = Process.Start(startInfo))
                {
                    // 对于单次点击，不需要读取输出，直接启动即可
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行失败: " + ex.Message + "\n请检查adb是否正确配置。");
            }
        }
    }
}