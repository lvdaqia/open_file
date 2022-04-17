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
        private String file;
        String xmlTxt = System.Environment.CurrentDirectory + "//ldq.xml";
        String imgefile = "";
        public Form1()
        {
            InitializeComponent();

            if (!File.Exists(xmlTxt))
            {
                XmlDocument xml = new XmlDocument();
                XmlElement xmlElement = xml.CreateElement("路径");
                xml.AppendChild(xmlElement);
                XmlElement xmlElement2 = xml.CreateElement("path1");
                xmlElement.AppendChild(xmlElement2);
                String current_path = System.Environment.CurrentDirectory;
                xmlElement2.InnerText = current_path;
                xml.Save(xmlTxt);
            }
            
            //读取 xml 文件
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTxt);
            XmlNode xmlNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name == "imgefile")
                {
                    if( node.InnerText != "")
                    {
                        if(  File.Exists(node.InnerText))
                        {
                            this.BackgroundImage = Image.FromFile(node.InnerText);
                            imgefile = node.InnerText;
                        }
                        else
                        {
                            MessageBox.Show("该壁纸文件已经被删除");
                            node.InnerText = imgefile;
                            xmlDocument.Save(xmlTxt);
                        }
                        
                    }
                }
                else
                {
                    string str = node.InnerText;
                    this.comboBox1.Items.Add(str);
                }
            }
           
            this.comboBox1.SelectedIndex = 0;
            file = comboBox1.GetItemText(comboBox1.Items[0]);
            label1.Dock = DockStyle.Fill;
            label1.AutoSize = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt_file = file + textBox1.Text;
            if (File.Exists(txt_file))
            {
                System.Diagnostics.Process.Start("Notepad++.exe", txt_file);
                label1.Text = button1.Text + ": " + txt_file.Replace("/", @"\");
            }
            else {
                MessageBox.Show( "文件不存在！！！" );
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            file = comboBox1.GetItemText( comboBox1.Items[comboBox1.SelectedIndex] );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = file+textBox2.Text.Replace( "/", "\\" );
            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start("Explorer.exe", path);
                label1.Text = button2.Text + "： " + path;
            }
            else {
                MessageBox.Show( "路径不存在！！！" );
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Form2 form2 = new Form2(file);
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();*/
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择一张图片";
            ofd.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp";
            ofd.ShowDialog();
            string imgFile = ofd.FileName;
            if (imgFile != "")
            {
                this.BackgroundImage = Image.FromFile(imgFile);
                imgefile = imgFile;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlTxt);
                Boolean ImageNodeHas = false;
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    if (node.Name == ("imgefile"))
                    {
                        node.InnerText = imgFile;
                        ImageNodeHas = true;
                    }
                }
                if ( !ImageNodeHas )
                {
                    XmlElement xmlElement = xmlDoc.DocumentElement;
                    XmlElement xmlElement1 = xmlDoc.CreateElement("imgefile");
                    xmlElement1.InnerText = imgFile;
                    xmlElement.AppendChild(xmlElement1);
                }
                xmlDoc.Save(xmlTxt);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3( xmlTxt,imgefile );
            form3.StartPosition = FormStartPosition.CenterScreen;
            form3.Show();
        }
      
    }
}
