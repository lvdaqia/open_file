using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

namespace open_file
{
    public partial class Form1 : MaterialForm
    {
        private String SelectPath = "";  //文件路径前缀
        private String openFileWay = ""; //打开文件的方式
        private String[] openFileALLWay = { "Notepad++.exe",     //内置两种打开文件的方式
            "C:\\Program Files (x86)\\Source Insight 4.0\\sourceinsight4.exe" };  
        
        String xmlPath = "";
        String ComboBoxXml = "";
        String listBoxXml = "";
        String openFileWayXml = "";
        
        
        public Form1()
        {
            InitializeComponent();
            InitXmlPath();  // 创建存放 xml 的路径
            InitComboBoxData();
            InitlistBoxData();
            InitOpenFileWay();
        }

        

        private void InitXmlPath()
        {
            xmlPath = System.Environment.CurrentDirectory;
            xmlPath = xmlPath.Replace("/", "\\");
            xmlPath = xmlPath.Substring(0, xmlPath.LastIndexOf("\\"));
            xmlPath = xmlPath + "\\XmlData";
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
                String current_path = System.Environment.CurrentDirectory + "\\";
                xmlElement2.InnerText = current_path;
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
                    materialComboBox1.Items.Add(str);
                }
                else {
                    SelectPath = node.InnerText.Trim();
                }
       
            }
            /***************************************************/

            /***************************************************/
            /***************************************************/
            //读取到的 第一条数据赋值给comboBox1显示；
            if (SelectPath == "")
            {
                materialComboBox1.SelectedIndex = 0;
                SelectPath = materialComboBox1.GetItemText(materialComboBox1.Items[0]);
            }
            else {
                materialComboBox1.SelectedIndex = materialComboBox1.Items.IndexOf(SelectPath);
            }
           
            /***************************************************/
        }
        public void InitlistBoxData()
        {
            //获取到保存 Data的xml文件
            listBoxXml = xmlPath + "\\listBox.xml";
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
            //读取 xml 文件的数据，并赋值给listBox1
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(listBoxXml);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                string str = node.InnerText;
                this.materialListBox1.AddItem(str);
            }
            /***************************************************/
           
        }

        private void InitOpenFileWay()
        {
            openFileWayXml = xmlPath + "\\openFileWay.xml";
            if (!File.Exists(openFileWayXml))
            {
                XmlDocument xml = new XmlDocument();
                XmlElement xmlElement = xml.CreateElement("文件打开方式");
                xml.AppendChild(xmlElement);
                XmlElement xmlElement2 = xml.CreateElement("open_way");
                xmlElement2.InnerText = openFileALLWay[0];
                xmlElement.AppendChild(xmlElement2);
                xml.Save(openFileWayXml);
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileWayXml);
            XmlNode xmlNode = xmlDocument.DocumentElement;

            openFileWay = xmlNode.ChildNodes[0].InnerText;
        }

        /*
         ********* 打开文件 *****************
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string txt = SelectPath + materialMultiLineTextBox1.Text;
            txt = txt.Replace("/", "\\");

            if (txt.EndsWith("\n"))   //判断文本末尾是否存在换行，如果存在则删除
            {
                txt = txt.Remove(txt.Length - 2, 2);
            }

            if (File.Exists(txt))
            {
                System.Diagnostics.Process.Start(openFileWay, txt);

                if (!IsTextInListBox(txt))
                {
                    materialListBox1.AddItem(txt.Replace("/", @"\"));
                    materialListBox1.SelectedIndex = materialListBox1.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("打开失败！请检查该文件是否正确！！");
            }
        }

        /*
         ********* 打开路径 *****************
         */

        private void button2_Click(object sender, EventArgs e)
        {
            string txt = SelectPath + materialMultiLineTextBox1.Text;
            txt = txt.Replace("/", "\\");

            if (txt.EndsWith("\n"))   //判断文本末尾是否存在换行，如果存在则删除
            {
                txt = txt.Remove(txt.Length - 2, 2);
            }

            if (File.Exists(txt) || Directory.Exists(txt))
            {
                txt = txt.Substring(0, txt.LastIndexOf("\\"));

                System.Diagnostics.Process.Start("Explorer.exe", txt);

            
                if (!IsTextInListBox(txt)) { 
                    materialListBox1.AddItem(txt.Replace("/", @"\"));
                    materialListBox1.SelectedIndex = materialListBox1.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("打开失败！请检查该路径是否正确！！");
            }
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPath = materialComboBox1.GetItemText(materialComboBox1.Items[materialComboBox1.SelectedIndex]);
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
           
            for (int i = 0; i < materialListBox1.Items.Count; i++)
            {
                if (materialListBox1.Items[i].Text != "")
                {
                    XmlElement xmlElement1 = xmlDocument.CreateElement("his" + i);
                    xmlElement1.InnerText = materialListBox1.Items[i].Text;
                    xmlElement.AppendChild(xmlElement1);
                }
            }
            xmlDocument.Save(listBoxXml);

            //关闭窗口时把 打开方式 进xml里
            SaveOpenFileWayXml();
           
        }

        private void SaveOpenFileWayXml()
        {
            if (File.Exists(openFileWayXml))
            {
                File.Delete(openFileWayXml);
            }
            XmlDocument SaveOpenWayXml = new XmlDocument();

            XmlElement xmlElement = SaveOpenWayXml.CreateElement("文件打开方式");
            SaveOpenWayXml.AppendChild(xmlElement);

            XmlElement xmlElement1 = SaveOpenWayXml.CreateElement("open_way");
            xmlElement1.InnerText = openFileWay;
            xmlElement.AppendChild(xmlElement1);
            
            SaveOpenWayXml.Save(openFileWayXml);
        }

        private bool IsTextInListBox(string searchText)
        {
            // 遍历 MaterialListBox 中的项，检查是否包含指定的文本
            foreach (MaterialListBoxItem item in materialListBox1.Items)
            {
                if (item.Text == searchText)
                {
                    return true;
                }
            }
            return false;
        }

        private void materialListBox1_DoubleClick(object sender, EventArgs e)
        {
            if (materialListBox1.SelectedIndex < 0)    //如果没有挑选中
            {
                return;
            }
            string str = materialListBox1.SelectedItem.Text;
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

        private void materialListBox1_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (materialListBox1.Items.Count > 10)
            {
                materialListBox1.Items.RemoveAt(0);
            }
        }

    
        private void materialListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (materialListBox1.SelectedItem != null)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.Show(materialListBox1.SelectedItem.Text, materialListBox1, 5000); // 显示 5 秒
            }
        }

        private void materialMultiLineTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 右键点击时，模拟粘贴操作
                materialMultiLineTextBox1.Paste();
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            materialListBox2.Items.Remove(materialListBox2.SelectedItem);
         
            foreach (var item in materialComboBox1.Items.Cast<object>().ToList())
            {
                if (item.ToString() == materialListBox2.SelectedItem.Text)
                {
                    materialComboBox1.Items.Remove(item);
                    break; // 如果找到并移除了，就跳出循环  
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (materialMultiLineTextBox2.Text == "")
                return;
            if (!materialMultiLineTextBox2.Text.EndsWith("\\"))
            {
                materialMultiLineTextBox2.Text += "\\";
            }

            if (Directory.Exists(materialMultiLineTextBox2.Text))
            {

                if (IsTextInListBox(materialMultiLineTextBox2.Text))
                {
                    MessageBox.Show("文件路径已存在！");
                }
                else
                {
                    materialListBox2.AddItem(materialMultiLineTextBox2.Text);
                    materialComboBox1.Items.Add(materialMultiLineTextBox2.Text);
                }
            }
            else
            {
                MessageBox.Show("文件路径错误！");
            }
        }

        

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 当TabPage切换时触发的事件处理程序
            TabPage selectedTabPage = materialTabControl1.SelectedTab as TabPage;

            if (selectedTabPage != null)
            {
                switch (selectedTabPage.Name)
                {
                    case "tabPage1":
                        
                        break;
                    case "tabPage2":      // 切换到路径管理
                        InitTabPage2();
                        
                        break;
                    case "tabPage3":
                        InitTabPage3();
                        break;
                    default:
                        
                        break;
                }
            }

        }

        private void InitTabPage2()
        {
            materialListBox2.Clear();
            foreach (var item in materialComboBox1.Items)
            {
                var itemString = item.ToString();
                materialListBox2.AddItem(itemString);
            }
        }

        private void InitTabPage3()
        {
            openway_ComboBox.Items.Clear();
            foreach (String item in openFileALLWay) { 
                openway_ComboBox.Items.Add(item);
            }
            openway_ComboBox.SelectedIndex = openway_ComboBox.Items.IndexOf(openFileWay);
        }

        private void openway_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            openFileWay = openway_ComboBox.SelectedItem.ToString();
        }
    }
}
