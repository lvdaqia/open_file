using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AndroidXml;
using SharpCompress.Archives;

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

        private string myApk;
        public Form2(string apkPath)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            apkPath = ValidatePath(apkPath);
            this.myApk = apkPath;
            var apkInfo = ParseApk(apkPath,false);

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

        private ApkInfo ParseApk(string apkPath,Boolean allInfo)
        {
            var info = new ApkInfo();

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
                        if (!allInfo)
                        {
                            while (reader.Read())
                            {

                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    Log.Write("结点", reader.Name);
                                    // 解析manifest节点
                                    if (reader.Name == "manifest")
                                    {
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            Log.Write("manifest", reader.Name);
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
                                    // 解析uses-sdk节点
                                    else if (reader.Name == "uses-sdk")
                                    {

                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            Log.Write("uses-sdk", reader.Name);
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
                                    // 解析权限
                                    else if (reader.Name == "uses-permission")
                                    {
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            Log.Write("uses-permission", reader.Name);
                                            if (reader.Name == "android:name")
                                            {
                                                info.Permissions.Add(reader.Value);
                                            }
                                        }
                                    }
                                    // 解析application节点
                                    else if (reader.Name == "application")
                                    {
                                        inApplication = true;
                                    }
                                    // 解析主Activity
                                    else if (inApplication && reader.Name == "activity")
                                    {
                                        string activityName = null;
                                        bool isMain = false;

                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            Log.Write("activity", reader.Name);
                                            if (reader.Name == "android:name")
                                            {
                                                activityName = reader.Value;
                                                info.MainActivity = activityName;
                                            }
                                            else if (reader.Name == "android:exported" && reader.Value == "true")
                                            {
                                                isMain = true;
                                            }

                                            if (isMain && !string.IsNullOrEmpty(activityName))
                                            {
                                                // 转换相对类名为全限定名
                                                if (activityName.StartsWith("."))
                                                {
                                                    info.MainActivity = info.PackageName + activityName;
                                                }
                                                else if (!activityName.Contains("."))
                                                {
                                                    info.MainActivity = info.PackageName + "." + activityName;
                                                }
                                                else
                                                {
                                                    info.MainActivity = activityName;
                                                }
                                            }
                                        }

                                    }
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "application")
                                {
                                    inApplication = false;
                                }
                            }
                        }
                        else
                        {
                            int indentLevel = 0;
                            StringBuilder indent = new StringBuilder();

                            while (reader.Read())
                            {
                                // 处理缩进
                                if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    indentLevel--;
                                }

                                indent.Clear();
                                for (int i = 0; i < indentLevel; i++) indent.Append("  ");

                                // 打印节点信息
                                switch (reader.NodeType)
                                {
                                    case XmlNodeType.Element:
                                        Log.Write("Element", $"{indent}<{reader.Name}>");
                                        indentLevel++;

                                        // 打印属性
                                        for (int i = 0; i < reader.AttributeCount; i++)
                                        {
                                            reader.MoveToAttribute(i);
                                            Log.Write("Attribute", $"{indent}  {reader.Name}=\"{reader.Value}\"");
                                        }
                                        break;

                                    case XmlNodeType.EndElement:
                                        Log.Write("Element", $"{indent}</{reader.Name}>");
                                        break;

                                    case XmlNodeType.Text:
                                        Log.Write("Text", $"{indent}{reader.Value}");
                                        break;

                                    case XmlNodeType.Comment:
                                        Log.Write("Comment", $"{indent}<!--{reader.Value}-->");
                                        break;

                                    case XmlNodeType.XmlDeclaration:
                                        Log.Write("Declaration", $"<?xml {reader.Value}?>");
                                        break;

                                    default:
                                        Log.Write(reader.NodeType.ToString(), reader.Value);
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return info;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string apkPath = myApk;

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
                        }
                    }
                }
                // 提取完毕后自动打开文件夹
                Process.Start("explorer.exe", outputDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提取失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}