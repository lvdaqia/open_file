using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace open_file
{
    public partial class Form3 : Form
    {
        string xmlTxt;
        string SelectPath;
        public Form3( string xmlTxt,string SelectPath)
        {
            InitializeComponent();
            this.xmlTxt = xmlTxt;
            this.SelectPath = SelectPath;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTxt);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name.Contains("path")) {
                    string str = node.InnerText;
                    this.listBox1.Items.Add(str);
                }
             
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
            {
                if (listBox1.Items.Contains(textBox1.Text))
                {
                    MessageBox.Show("文件路径已存在！");
                }
                else
                {
                    if (!textBox1.Text.EndsWith("\\")) { 
                        textBox1.Text += "\\";
                    }
                    listBox1.Items.Add(textBox1.Text);
                }
            }
            else {
                MessageBox.Show("文件路径错误！");
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(xmlTxt))
            {
                File.Delete(xmlTxt);
            }
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement = xmlDocument.CreateElement("路径");
            xmlDocument.AppendChild(xmlElement);
            XmlElement xmlElement2 = xmlDocument.CreateElement("SelectPath");
            xmlElement2.InnerText = SelectPath;
            xmlElement.AppendChild(xmlElement2);
            string[] all_path = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() != "")
                {
                    XmlElement xmlElement1 = xmlDocument.CreateElement("path" + i);
                    xmlElement1.InnerText = listBox1.Items[i].ToString();
                    xmlElement.AppendChild(xmlElement1);
                }
            }
            xmlDocument.Save(xmlTxt);
            Application.Restart();
            Process.GetCurrentProcess()?.Kill();
        }

    }
}
