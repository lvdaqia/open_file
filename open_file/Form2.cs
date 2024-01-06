using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MaterialSkin;
using MaterialSkin.Controls;

namespace open_file
{
    public partial class Form2 : MaterialForm
    {
        string xmlTxt;
        string SelectPath;
        public Form2(string xmlTxt, string SelectPath)
        {
            InitializeComponent();


            // 设置窗体启动位置为居中
            this.StartPosition = FormStartPosition.CenterScreen;

            // 创建 MaterialSkinManager 实例
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

            // 设置颜色方案
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Pink200,
                TextShade.WHITE
            );

            this.xmlTxt = xmlTxt;
            this.SelectPath = SelectPath;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTxt);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name.Contains("path"))
                {
                    string str = node.InnerText;
                    this.materialListBox1.AddItem(str);
                }

            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            materialListBox1.Items.Remove(materialListBox1.SelectedItem);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (!materialTextBox1.Text.EndsWith("\\"))
            {
                materialTextBox1.Text += "\\";
            }

            if (Directory.Exists(materialTextBox1.Text))
            {

                if (IsTextInListBox(materialTextBox1.Text))
                {
                    MessageBox.Show("文件路径已存在！");
                }
                else
                {        
                    materialListBox1.AddItem(materialTextBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("文件路径错误！");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
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
           
            // 遍历 MaterialListBox 中的项，为每个项创建一个 XmlElement，使用索引命名
            for (int i = 0; i < materialListBox1.Items.Count; i++)
            {
                if (materialListBox1.Items[i].Text != "")
                {
                    XmlElement xmlElement1 = xmlDocument.CreateElement("path" + i);
                    xmlElement1.InnerText = materialListBox1.Items[i].Text;
                    xmlElement.AppendChild(xmlElement1);
                }
            }
            xmlDocument.Save(xmlTxt);
            Application.Restart();
            Process.GetCurrentProcess()?.Kill();
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
    }
}
