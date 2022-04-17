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
        public Form3( string xmlTxt )
        {
            InitializeComponent();
            this.xmlTxt = xmlTxt;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTxt);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                string str = node.InnerText;
                this.listBox1.Items.Add(str);
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
            if( File.Exists(xmlTxt))
            {
                File.Delete(xmlTxt);
            }
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement = xmlDocument.CreateElement("路径");
            xmlDocument.AppendChild(xmlElement);
            string[] all_path = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                XmlElement xmlElement1 = xmlDocument.CreateElement("path" + i);
                xmlElement1.InnerText = listBox1.Items[i].ToString();
                xmlElement.AppendChild(xmlElement1);
                //all_path[i] = listBox1.GetItemText(listBox1.Items[i]);
            }
            xmlDocument.Save(xmlTxt);
            //File.WriteAllLines(@"c:\ldq.txt", all_path);
            Application.Restart();
            Process.GetCurrentProcess()?.Kill();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
