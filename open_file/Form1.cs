using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace open_file
{
    public partial class Form1 : Form
    {
        private String SelectPath;

        String xmlPath = "";
        String ComboBoxXml = "";
        String listBoxXml = "";
        String openFileWayXml = "";
        String[] openFileALLWay = {"Notepad++.exe", "C:\\Program Files (x86)\\Source Insight 4.0\\sourceinsight4.exe" };
        String openFileWay = "";
        private int maxItems = 20;
        public Form1()
        {
            InitXmlPath();
            InitializeComponent();
            InitComboBoxData();
            InitlistBoxData();
            InitOpenFileWay();
        }

        private void InitOpenFileWay()
        {
            openFileWayXml = xmlPath + "\\openFileWay.xml";
            if (!File.Exists(openFileWayXml))
            {
                XmlDocument xml = new XmlDocument();
                XmlElement xmlElement = xml.CreateElement("文件打开方式");
                xml.AppendChild(xmlElement);
                XmlElement xmlElement2 = xml.CreateElement("way1");
                xmlElement2.InnerText = openFileALLWay[0];
                xmlElement.AppendChild(xmlElement2);
                xml.Save(openFileWayXml);
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileWayXml);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            openFileWay = xmlNode.ChildNodes[0].InnerText;
            if (openFileWay == "Notepad++.exe")
            {
                button1.Text += "\n( Notepad++ )";
            }
            else
            {
                button1.Text += "\n( Source Insight4.0 )";
            }
        }

        private void InitXmlPath()
        {
            xmlPath = Path.Combine(@"C:\Users", Environment.UserName, "XmlData");
            //xmlPath = xmlPath.Replace("/", "\\");
            //xmlPath = xmlPath.Substring(0, xmlPath.LastIndexOf("\\"));
            //xmlPath = xmlPath + "\\XmlData"
            if (!Directory.Exists(xmlPath))
            {
                Directory.CreateDirectory(xmlPath);
            }
        }

        private void InitComboBoxData()
        {
            /***************************************************/
            /***************************************************/
            //获取到保存 Data的xml文件
           
             ComboBoxXml = xmlPath + "\\combobox.xml";
            /***************************************************/
          

            /***************************************************/
            /***************************************************/
            //如果xml文件不存在，则创建该xml
            if (!File.Exists(ComboBoxXml))
            {
                XmlDocument xml = new XmlDocument();
                XmlElement xmlElement = xml.CreateElement("路径");
                xml.AppendChild(xmlElement);
                XmlElement xmlElement2 = xml.CreateElement("path1");
                xmlElement.AppendChild(xmlElement2);
                XmlElement xmlElement3 = xml.CreateElement("SelectPath");
                xmlElement.AppendChild(xmlElement3);
                xml.Save(ComboBoxXml);
            }
            /***************************************************/

            /***************************************************/
            /***************************************************/
            //读取 xml 文件的数据，并赋值给comboBox1
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ComboBoxXml);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (!node.Name.Equals("SelectPath"))
                {
                    string str = node.InnerText;
                    comboBox1.Items.Add(str);
                }
                else {
                    SelectPath = node.InnerText.Trim();
                }
       
            }
            /***************************************************/

            /***************************************************/
            /***************************************************/
            if (SelectPath != "")
            {
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(SelectPath);
            }
           
            /***************************************************/
        }
        public void InitlistBoxData()
        {
           
            listBoxXml = xmlPath + "\\listBox.xml";
            /***************************************************/
            /***************************************************/
            /***************************************************/
            //如果xml文件不存在，则创建该xml
            if (!File.Exists(listBoxXml))
            {
                XmlDocument xml = new XmlDocument();
                XmlElement xmlElement = xml.CreateElement("历史记录");
                xml.AppendChild(xmlElement);
                xml.Save(listBoxXml);
            }
            /***************************************************/

            /***************************************************/
            /***************************************************/
            //读取 xml 文件的数据，并赋值给comboBox1
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(listBoxXml);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                string str = node.InnerText;
                this.listBox1.Items.Add(str);
                
            }
            /***************************************************/
           
        }
        /*
         ********* 打开文件 *****************
         */
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ( textBox1.Text.Equals("ldq") ) { 
                    textBox1.Text="";
                    return;
                }
                string txt = SelectPath + textBox1.Text;
                txt = txt.Replace("/", "\\");

                if (txt.EndsWith("\n"))   //判断文本末尾是否存在换行，如果存在则删除
                {
                    txt = txt.Remove(txt.Length - 2, 2);
                }

                if (File.Exists(txt))
                {
                    System.Diagnostics.Process.Start(openFileWay, txt);
                    if (!listBox1.Items.Contains(textBox1.Text.Replace("/", @"\")))
                    {
                        listBox1.Items.Add(textBox1.Text.Replace("/", @"\"));
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }

                }
                else
                {
                    MessageBox.Show("打开失败！请检查该文件是否正确！！");
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(openFileWayXml);
                XmlNode xmlNode = xmlDocument.DocumentElement;
                if (openFileWay.Equals(openFileALLWay[0]))
                {
                    openFileWay = openFileALLWay[1];
                }
                else
                {
                    openFileWay = openFileALLWay[0];
                }
                //MessageBox.Show("默认打开方式已切换为："+openFileWay);
                xmlNode.ChildNodes[0].InnerText = openFileWay;
                xmlDocument.Save(openFileWayXml);
                button1.Text = "打开文件";
                if (openFileWay == "Notepad++.exe")
                {
                    button1.Text += "\n( Notepad++ )";
                }
                else
                {
                    button1.Text += "\n( Source Insight4.0 )";
                }
            }
        }

        /*
         ********* 打开路径 *****************
         */

        private void button2_Click(object sender, EventArgs e)
        {
            string txt = SelectPath + textBox1.Text;
            txt = txt.Replace("/", "\\");

            if (txt.EndsWith("\n"))   //判断文本末尾是否存在换行，如果存在则删除
            {
                txt = txt.Remove(txt.Length - 2, 2);
            }

            if (File.Exists(txt))
            {
                txt = txt.Substring(0, txt.LastIndexOf("\\"));
               
                System.Diagnostics.Process.Start("Explorer.exe", txt);

                if (!listBox1.Items.Contains(textBox1.Text.Replace("/", @"\")))
                {
                    listBox1.Items.Add(textBox1.Text.Replace("/", @"\"));
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

            }
            else if (Directory.Exists(txt))
            {
                System.Diagnostics.Process.Start("Explorer.exe", txt);
                if (!listBox1.Items.Contains(textBox1.Text.Replace("/", @"\")))
                {
                    listBox1.Items.Add(textBox1.Text.Replace("/", @"\"));
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                   
                }
            }
            else
            {
                MessageBox.Show("打开失败！请检查该路径是否正确！！");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPath = comboBox1.GetItemText( comboBox1.Items[comboBox1.SelectedIndex] );
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ComboBoxXml);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode)
            {
                if (node.Name.Equals("SelectPath"))
                {
                    node.InnerText = SelectPath;
                    break;
                }
            }
            xmlDocument.Save(ComboBoxXml);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3( ComboBoxXml,SelectPath );
            form3.StartPosition = FormStartPosition.CenterScreen;
            form3.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭窗口时把 listbox 数据进xml里
            if (File.Exists(listBoxXml))
            {
                File.Delete(listBoxXml);
            }
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement = xmlDocument.CreateElement("历史记录");
            xmlDocument.AppendChild(xmlElement);
            string[] all_path = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() != "")
                {
                    XmlElement xmlElement1 = xmlDocument.CreateElement("his" + i);
                    xmlElement1.InnerText = listBox1.Items[i].ToString();
                    xmlElement.AppendChild(xmlElement1);
                }
            }
           
            xmlDocument.Save(listBoxXml);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)    //如果没有挑选中
            {
                return;
            }
            string str = listBox1.GetItemText(listBox1.Items[listBox1.SelectedIndex]);

            if (File.Exists(str))
            {
                System.Diagnostics.Process.Start(openFileWay, str);
            }
            else if (Directory.Exists(str))
            {
                System.Diagnostics.Process.Start("Explorer.exe", str);
            }
            else
            {
                MessageBox.Show("打开失败！请检查该 文件名/路径 是否正确！！");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            if (listBox1.Items.Count > maxItems)
            {
                listBox1.Items.RemoveAt(0);

            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)    //如果没有挑选中
            {
                return;
            }
            textBox1.Text = listBox1.GetItemText(listBox1.Items[listBox1.SelectedIndex]);
        }


        private bool IsApkFile(string filePath)
        {
            return File.Exists(filePath) &&
                   Path.GetExtension(filePath).Equals(".apk", StringComparison.OrdinalIgnoreCase);
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // 只允许单个APK文件
                if (files.Length == 1 && IsApkFile(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖放的文件路径
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0 && IsApkFile(files[0]))
            {
                textBox2.Text = $"{files[0]}{Environment.NewLine}";
                new Form2(textBox2.Text.Replace("/", "\\")).Show();
            }
            else
            {
                textBox2.Text = "请拖放有效的APK文件(.apk)";
            }
        }

        private void btnRemote_Click(object sender, EventArgs e)
        {
            // 1. 实例化 Form4
            Form4 remote = new Form4();

            // 2. 设置启动位置为“手动指定”
            remote.StartPosition = FormStartPosition.Manual;

            // 3. 计算位置：Form1 的右边界坐标，Form1 的顶部对齐
            // this.Right 是 Form1 右侧的坐标，this.Top 是 Form1 顶部的坐标
            int targetX = this.Right + 5; // 加5个像素的间距，好看一点
            int targetY = this.Top;

            // 4. 检查是否超出屏幕右侧（可选逻辑）
            // 如果屏幕右边没位置了，就弹在 Form1 的左边
            if (targetX + remote.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                targetX = this.Left - remote.Width - 5;
            }

            remote.Location = new Point(targetX, targetY);

            // 5. 显示窗体
            remote.Show();
        }

        // 点击打开 ADB 工具箱
        private void btnAdbTools_Click(object sender, EventArgs e)
        {
            // 创建 Form5 实例
            Form5 adbForm = new Form5();

            // 2. 设置启动位置为“手动指定”
            adbForm.StartPosition = FormStartPosition.Manual;

            // 3. 计算位置：Form1 的右边界坐标，Form1 的顶部对齐
            // this.Right 是 Form1 右侧的坐标，this.Top 是 Form1 顶部的坐标
            int targetX = this.Right + 5; // 加5个像素的间距，好看一点
            int targetY = this.Top;

            // 4. 检查是否超出屏幕右侧（可选逻辑）
            // 如果屏幕右边没位置了，就弹在 Form1 的左边
            if (targetX + adbForm.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                targetX = this.Left - adbForm.Width - 5;
            }
            adbForm.Location = new Point(targetX, targetY);
            // 显示窗口
            adbForm.Show();
        }
    }
}
