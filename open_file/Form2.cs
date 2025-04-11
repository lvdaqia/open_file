using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using AndroidXml;
using SharpCompress.Archives;
using static System.Net.Mime.MediaTypeNames;


namespace open_file
{
    public partial class Form2 : Form
    {
        public class ApkInfo
        {
            public string PackageName { get; set; }
            public string VersionName { get; set; }
            public string VersionCode { get; set; }
            public string MainActivity { get; set; }
            public List<string> Permissions { get; } = new List<string>();
            public string MinSdkVersion { get; set; }
            public string TargetSdkVersion { get; set; }
        }

        private string myapk;
      
        public Form2(string apkPath)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            apkPath = ValidatePath(apkPath);
            this.myapk = apkPath;

            // 获取文件的属性
            var fileAttributes = File.GetAttributes(myapk);

            // 如果文件是只读的，取消只读属性
            if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                // 取消只读属性
                File.SetAttributes(myapk, fileAttributes & ~FileAttributes.ReadOnly);
            }

            var apkInfo = ParseApk(myapk);

            textPackageName.Text = apkInfo.PackageName;
            textMainActivity.Text = apkInfo.MainActivity;
            textVersionName.Text = apkInfo.VersionName;
            textMinSdk.Text = apkInfo.MinSdkVersion;
            textTargetSdk.Text = apkInfo.TargetSdkVersion;

           
        }

        private string ValidatePath(string path)
        {
            path = path.Trim();
            char[] invalidChars = Path.GetInvalidPathChars();
            if (path.IndexOfAny(invalidChars) >= 0)
            {
                throw new ArgumentException("路径包含非法字符");
            }
            return path;
        }

        private ApkInfo ParseApk(string apkPath)
        {
            var info = new ApkInfo();

            try
            {
                using (var fileStream = new FileStream(apkPath, FileMode.Open))
                using (var zipReader = ArchiveFactory.Open(fileStream))
                {
                    var manifestEntry = zipReader.Entries.FirstOrDefault(w =>
                        w.Key.Equals("AndroidManifest.xml", StringComparison.OrdinalIgnoreCase));

                    if (manifestEntry == null) return info;

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var entryStream = manifestEntry.OpenEntryStream())
                        {
                            entryStream.CopyTo(memoryStream);
                        }
                        memoryStream.Position = 0;

                        using (var reader = new AndroidXmlReader(memoryStream))
                        {
                            bool inApplication = false;
                            bool inActivity = false;
                            bool inIntentFilter = false;

                            string currentActivityName = null;
                            bool foundMainAction = false;
                            bool foundLauncherCategory = false;

                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    if (reader.Name == "manifest")
                                    {
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            switch (reader.Name)
                                            {
                                                case "package":
                                                    info.PackageName = reader.Value;
                                                    break;
                                                case "android:versionName":
                                                    info.VersionName = reader.Value;
                                                    break;
                                                case "android:versionCode":
                                                    info.VersionCode = reader.Value;
                                                    break;
                                            }
                                        }
                                    }
                                    else if (reader.Name == "uses-sdk")
                                    {
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            switch (reader.Name)
                                            {
                                                case "android:minSdkVersion":
                                                    info.MinSdkVersion = reader.Value;
                                                    break;
                                                case "android:targetSdkVersion":
                                                    info.TargetSdkVersion = reader.Value;
                                                    break;
                                            }
                                        }
                                    }
                                    else if (reader.Name == "uses-permission")
                                    {
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            if (reader.Name == "android:name")
                                            {
                                                info.Permissions.Add(reader.Value);
                                            }
                                        }
                                    }
                                    else if (reader.Name == "application")
                                    {
                                        inApplication = true;
                                    }
                                    else if (inApplication && (reader.Name == "activity" || reader.Name == "activity-alias"))
                                    {
                                        inActivity = true;
                                        currentActivityName = null;

                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            if (reader.Name == "android:name")
                                            {
                                                currentActivityName = reader.Value;
                                            }
                                        }
                                    }
                                    else if (inActivity && reader.Name == "intent-filter")
                                    {
                                        inIntentFilter = true;
                                        foundMainAction = false;
                                        foundLauncherCategory = false;
                                    }
                                    else if (inIntentFilter && reader.Name == "action")
                                    {
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            if (reader.Name == "android:name" && reader.Value == "android.intent.action.MAIN")
                                            {
                                                foundMainAction = true;
                                            }
                                        }
                                    }
                                    else if (inIntentFilter && reader.Name == "category")
                                    {
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            if (reader.Name == "android:name" && reader.Value == "android.intent.category.LAUNCHER")
                                            {
                                                foundLauncherCategory = true;
                                            }
                                        }
                                    }
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    if (reader.Name == "intent-filter")
                                    {
                                        inIntentFilter = false;

                                        if (foundMainAction && foundLauncherCategory && !string.IsNullOrEmpty(currentActivityName))
                                        {
                                            if (currentActivityName.StartsWith("."))
                                            {
                                                info.MainActivity = info.PackageName + currentActivityName;
                                            }
                                            else if (!currentActivityName.Contains("."))
                                            {
                                                info.MainActivity = info.PackageName + "." + currentActivityName;
                                            }
                                            else
                                            {
                                                info.MainActivity = currentActivityName;
                                            }
                                        }
                                    }
                                    else if (reader.Name == "activity" || reader.Name == "activity-alias")
                                    {
                                        inActivity = false;
                                        currentActivityName = null;
                                    }
                                    else if (reader.Name == "application")
                                    {
                                        inApplication = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"解析 APK 失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return info;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string apkPath = myapk;

            if (!File.Exists(apkPath))
            {
                MessageBox.Show("APK 文件不存在，请检查路径！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            string apkFileName = Path.GetFileNameWithoutExtension(apkPath); // 获取 APK 文件名（不带扩展名）
            string baseOutputDir = Path.Combine(@"C:\Users", Environment.UserName, "XmlData");
            string outputDir = Path.Combine(baseOutputDir, apkFileName);

            // 如果目标目录已存在，则删除它
            if (Directory.Exists(outputDir))
            {
                Directory.Delete(outputDir, true); // 删除目录及其所有内容
            }

            // 创建目标目录
            Directory.CreateDirectory(outputDir);

            try
            {
                List<string> extractedSoPaths = new List<string>();

                using (System.IO.Compression.ZipArchive archive = ZipFile.OpenRead(apkPath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.FullName.StartsWith("lib/") && entry.FullName.EndsWith(".so"))
                        {
                            string destPath = Path.Combine(outputDir, entry.FullName.Replace('/', Path.DirectorySeparatorChar));
                            string dir = Path.GetDirectoryName(destPath);
                            if (dir != null)
                            {
                                Directory.CreateDirectory(dir);
                            }

                            entry.ExtractToFile(destPath, true);
                            extractedSoPaths.Add(destPath); // 记录路径
                        }
                    }
                }

                // 输出到文本文件
                string logPath = Path.Combine(outputDir, "so_files_list.txt");
                File.WriteAllLines(logPath, extractedSoPaths, Encoding.UTF8);

                // 提取完毕后自动打开文件夹
                Process.Start("explorer.exe", outputDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提取 .so 文件失败：" + ex.Message);
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportAndroidManifest(myapk);
        }

        private void ExportAndroidManifest(string apkPath)
        {
            try
            {
                using (var fileStream = new FileStream(apkPath, FileMode.Open, FileAccess.Read))
                using (var zipReader = ArchiveFactory.Open(fileStream))
                {
                    var manifestEntry = zipReader.Entries.FirstOrDefault(e =>
                        e.Key.Equals("AndroidManifest.xml", StringComparison.OrdinalIgnoreCase));

                    if (manifestEntry == null)
                    {
                        MessageBox.Show("APK 中未找到 AndroidManifest.xml", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 使用内存流缓存读取内容
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var entryStream = manifestEntry.OpenEntryStream())
                        {
                            entryStream.CopyTo(memoryStream);
                        }
                        memoryStream.Position = 0;

                        // 使用 StringWriter 和 XmlWriter 创建格式化的输出
                        var manifestXmlContent = new StringBuilder();
                        using (var stringWriter = new StringWriter(manifestXmlContent))
                        using (var xmlWriter = new XmlTextWriter(stringWriter)
                        {
                            Formatting = Formatting.Indented,  // 启用缩进
                            Indentation = 4                    // 每级缩进 4 个空格
                        })
                        {
                            xmlWriter.WriteStartDocument();
                            using (var reader = new AndroidXmlReader(memoryStream))
                            {
                                while (reader.Read())
                                {
                                    if (reader.NodeType == XmlNodeType.Element)
                                    {
                                        xmlWriter.WriteStartElement(reader.Name);
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            xmlWriter.WriteAttributeString(reader.Name, reader.Value);
                                        }
                                    }
                                    else if (reader.NodeType == XmlNodeType.EndElement)
                                    {
                                        xmlWriter.WriteEndElement();
                                    }
                                }
                            }
                            xmlWriter.WriteEndDocument();
                        }

                        // 输出路径
                        string apkFileName = Path.GetFileNameWithoutExtension(apkPath);
                        string baseOutputDir = Path.Combine(@"C:\Users", Environment.UserName, "XmlData");

                        if (!Directory.Exists(baseOutputDir))
                            Directory.CreateDirectory(baseOutputDir);

                        string outputPath = Path.Combine(baseOutputDir, $"{apkFileName}_manifest.txt");

                        // 写入文件
                        File.WriteAllText(outputPath, manifestXmlContent.ToString(), Encoding.UTF8);

                        System.Diagnostics.Process.Start("Notepad++.exe",outputPath);
                        //MessageBox.Show($"Manifest 导出成功：{outputPath}", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"导出 Manifest 失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}