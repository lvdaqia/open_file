using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace open_file
{
    public partial class Form6 : Form
    {
        private string _apkPath;
        private string _outApk;
        private string _pk8;
        private string _pem;

        public Form6(string apkpath, string aosp_path)
        {
            InitializeComponent();
            this._apkPath = apkpath;

            // 初始逻辑：自动推导 AOSP 默认路径
            string securityPath = Path.Combine(aosp_path, "build", "make", "target", "product", "security");
            if (!Directory.Exists(securityPath))
                securityPath = Path.Combine(aosp_path, "build", "target", "product", "security");

            _pk8 = Path.Combine(securityPath, "platform.pk8");
            _pem = Path.Combine(securityPath, "platform.x509.pem");

            _outApk = Path.Combine(Path.GetDirectoryName(apkpath),
                      Path.GetFileNameWithoutExtension(apkpath) + "_platform_signed.apk");

            RefreshUI();
        }

        private void RefreshUI()
        {
            label2.Text = _pk8;
            label3.Text = _pem;
            label4.Text = "输出路径: " + _outApk;

            if (!File.Exists(_pk8) || !File.Exists(_pem))
                label1.Text = "⚠️ 警告：未找到默认签名文件，请手动更换";
            else
                label1.Text = "✅ 签名文件已就绪";
        }

        // 更换 PK8 按钮
        private void btnSelectPk8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "PK8文件|*.pk8|所有文件|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _pk8 = ofd.FileName;
                RefreshUI();
            }
        }

        // 更换 PEM 按钮
        private void btnSelectPem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "PEM文件|*.pem|所有文件|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _pem = ofd.FileName;
                RefreshUI();
            }
        }

        // 执行签名
        private void btnRunSign_Click(object sender, EventArgs e)
        {
            // 1. 定位工具路径 (假设在程序目录下的 tools 文件夹里)
            string jarPath = Path.Combine(Application.StartupPath, "tool", "apksigner.jar");

            // 2. 检查工具是否存在
            if (!File.Exists(jarPath))
            {
                txtLog.SelectionColor = Color.Red;
                txtLog.AppendText($"\r\n[错误] 找不到工具: {jarPath}\r\n");
                return;
            }

            // 3. 核心命令拼凑
            // 标准格式: java -jar "apksigner.jar" sign --key "pk8路径" --cert "pem路径" --out "输出路径" "原始APK"
            // 注意：所有的路径都包裹了 \" (转义双引号) 以防止空格导致路径截断
            string arguments = $"-jar \"{jarPath}\" sign " +
                               $"--key \"{_pk8}\" " +
                               $"--cert \"{_pem}\" " +
                               $"--out \"{_outApk}\" " +
                               $"\"{_apkPath}\"";

            txtLog.Clear();
            txtLog.SelectionColor = Color.White;
            txtLog.AppendText("开始签名任务...\r\n");
            txtLog.AppendText($"命令: java {arguments}\r\n\r\n");

            // 4. 开启进程执行
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = System.Text.Encoding.UTF8 // 避免乱码
                };

                using (Process p = new Process())
                {
                    p.StartInfo = psi;

                    // 启动
                    p.Start();

                    // 读取输出
                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();

                    p.WaitForExit();

                    if (p.ExitCode == 0)
                    {
                        txtLog.SelectionColor = Color.Lime;
                        txtLog.AppendText("✅ 签名成功！\r\n");
                        txtLog.SelectionColor = Color.White;
                        txtLog.AppendText($"生成文件: {Path.GetFileName(_outApk)}\r\n");

                        // 自动打开输出目录并选中文件 (可选，增加体验)
                        // Process.Start("explorer.exe", $"/select,\"{_outApk}\"");

                        MessageBox.Show("签名已完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // 成功后返回 OK 状态
                    }
                    else
                    {
                        txtLog.SelectionColor = Color.Red;
                        txtLog.AppendText("❌ 签名失败！\r\n");
                        txtLog.AppendText($"错误详情: {error}\r\n");
                        MessageBox.Show("签名失败，请查看日志。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                txtLog.SelectionColor = Color.Red;
                txtLog.AppendText($"\r\n系统错误: {ex.Message}\r\n");
                txtLog.AppendText("请确保电脑已安装 Java (JDK) 环境，并在环境变量中配置了 java 命令。");
            }
        }
    }
}