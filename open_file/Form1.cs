using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace open_file
{
    public partial class Form1 : Form
    {
        private String SelectPath;

        String xmlPath = "";
        String ComboBoxXml = "";
        String listBoxXml = "";
 
        public Form1()
        {
            InitXmlPath();
            InitializeComponent();
            InitComboBoxData();
            InitlistBoxData();
    
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
                string str = node.InnerText;
                comboBox1.Items.Add(str);
            }
            /***************************************************/

            /***************************************************/
            /***************************************************/
            //读取到的 第一条数据赋值给comboBox1显示；
            comboBox1.SelectedIndex = 0;
            SelectPath = comboBox1.GetItemText(comboBox1.Items[0]);
            /***************************************************/
        }
        public void InitlistBoxData()
        {
            /***************************************************/
            /***************************************************/
            //获取到保存 Data的xml文件
            string xmlPath = System.Environment.CurrentDirectory;
            xmlPath = xmlPath.Replace("/", "\\");
            xmlPath = xmlPath.Substring(0, xmlPath.LastIndexOf("\\"));
            xmlPath = xmlPath + "\\XmlData";
            if (!Directory.Exists(xmlPath))
            {
                Directory.CreateDirectory(xmlPath);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string txt = SelectPath + textBox1.Text;
            txt = txt.Replace("/", "\\");

            if (txt.EndsWith("\n"))   //判断文本末尾是否存在换行，如果存在则删除
            {
                txt = txt.Remove(txt.Length - 2,2);
            }

            if (File.Exists(txt))
            {
                System.Diagnostics.Process.Start("Notepad++.exe", txt);

                if( !listBox1.Items.Contains(txt))
                {
                    listBox1.Items.Add(txt.Replace("/", @"\"));
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
    
            }else if (Directory.Exists(txt))
            {
                System.Diagnostics.Process.Start("Explorer.exe", txt);
                if (!listBox1.Items.Contains(txt))
                {
                    listBox1.Items.Add(txt.Replace("/", @"\"));
                }
            }
            else
            {
                MessageBox.Show("打开失败！请检查该 文件名/路径 是否正确！！");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPath = comboBox1.GetItemText( comboBox1.Items[comboBox1.SelectedIndex] );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3( ComboBoxXml );
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
                System.Diagnostics.Process.Start("Notepad++.exe", str);
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
    }
}
