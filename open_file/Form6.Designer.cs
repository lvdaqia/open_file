using System.Drawing;
using System.Windows.Forms;

namespace open_file
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectPk8 = new System.Windows.Forms.Button();
            this.btnSelectPem = new System.Windows.Forms.Button();
            this.btnRunSign = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1 (标题/状态)
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.Text = "待使用的签名文件";
            // 
            // label2 (显示 PK8 路径)
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(34, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 25);
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectPk8 (更换 PK8)
            // 
            this.btnSelectPk8.Location = new System.Drawing.Point(505, 55);
            this.btnSelectPk8.Name = "btnSelectPk8";
            this.btnSelectPk8.Size = new System.Drawing.Size(90, 25);
            this.btnSelectPk8.Text = "更换 PK8";
            this.btnSelectPk8.Click += new System.EventHandler(this.btnSelectPk8_Click);
            // 
            // label3 (显示 PEM 路径)
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(34, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(460, 25);
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectPem (更换 PEM)
            // 
            this.btnSelectPem.Location = new System.Drawing.Point(505, 95);
            this.btnSelectPem.Name = "btnSelectPem";
            this.btnSelectPem.Size = new System.Drawing.Size(90, 25);
            this.btnSelectPem.Text = "更换 PEM";
            this.btnSelectPem.Click += new System.EventHandler(this.btnSelectPem_Click);
            // 
            // label4 (输出文件预览)
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(32, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.Text = "输出文件预览";
            // 
            // txtLog (日志输出)
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(34, 160);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(561, 200);
            this.txtLog.Text = "等待开始签名...";
            // 
            // btnRunSign (执行按钮)
            // 
            this.btnRunSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRunSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunSign.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnRunSign.ForeColor = System.Drawing.Color.White;
            this.btnRunSign.Location = new System.Drawing.Point(34, 375);
            this.btnRunSign.Name = "btnRunSign";
            this.btnRunSign.Size = new System.Drawing.Size(561, 45);
            this.btnRunSign.Text = "确认并开始签名";
            this.btnRunSign.UseVisualStyleBackColor = false;
            this.btnRunSign.Click += new System.EventHandler(this.btnRunSign_Click);
            // 
            // Form6
            // 
            this.ClientSize = new System.Drawing.Size(627, 450);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnRunSign);
            this.Controls.Add(this.btnSelectPem);
            this.Controls.Add(this.btnSelectPk8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统签名助手";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Button btnSelectPk8;
        private System.Windows.Forms.Button btnSelectPem;
        private System.Windows.Forms.Button btnRunSign;
        private System.Windows.Forms.RichTextBox txtLog;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
