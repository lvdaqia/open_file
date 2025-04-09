
namespace open_file
{
    partial class Form2
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
            this.labelPackageName = new System.Windows.Forms.Label();
            this.textPackageName = new System.Windows.Forms.TextBox();
            this.labelMainActivity = new System.Windows.Forms.Label();
            this.textMainActivity = new System.Windows.Forms.TextBox();
            this.labelVersionName = new System.Windows.Forms.Label();
            this.textVersionName = new System.Windows.Forms.TextBox();
            this.labelMinSdk = new System.Windows.Forms.Label();
            this.textMinSdk = new System.Windows.Forms.TextBox();
            this.labelTargetSdk = new System.Windows.Forms.Label();
            this.textTargetSdk = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPackageName
            // 
            this.labelPackageName.Location = new System.Drawing.Point(40, 30);
            this.labelPackageName.Name = "labelPackageName";
            this.labelPackageName.Size = new System.Drawing.Size(100, 23);
            this.labelPackageName.TabIndex = 0;
            this.labelPackageName.Text = "包名：";
            // 
            // textPackageName
            // 
            this.textPackageName.Location = new System.Drawing.Point(160, 30);
            this.textPackageName.Name = "textPackageName";
            this.textPackageName.ReadOnly = true;
            this.textPackageName.Size = new System.Drawing.Size(315, 21);
            this.textPackageName.TabIndex = 1;
            // 
            // labelMainActivity
            // 
            this.labelMainActivity.Location = new System.Drawing.Point(40, 65);
            this.labelMainActivity.Name = "labelMainActivity";
            this.labelMainActivity.Size = new System.Drawing.Size(100, 23);
            this.labelMainActivity.TabIndex = 2;
            this.labelMainActivity.Text = "主 Activity：";
            // 
            // textMainActivity
            // 
            this.textMainActivity.Location = new System.Drawing.Point(160, 65);
            this.textMainActivity.Name = "textMainActivity";
            this.textMainActivity.ReadOnly = true;
            this.textMainActivity.Size = new System.Drawing.Size(315, 21);
            this.textMainActivity.TabIndex = 3;
            // 
            // labelVersionName
            // 
            this.labelVersionName.Location = new System.Drawing.Point(40, 100);
            this.labelVersionName.Name = "labelVersionName";
            this.labelVersionName.Size = new System.Drawing.Size(100, 23);
            this.labelVersionName.TabIndex = 4;
            this.labelVersionName.Text = "版本名称：";
            // 
            // textVersionName
            // 
            this.textVersionName.Location = new System.Drawing.Point(160, 100);
            this.textVersionName.Name = "textVersionName";
            this.textVersionName.ReadOnly = true;
            this.textVersionName.Size = new System.Drawing.Size(315, 21);
            this.textVersionName.TabIndex = 5;
            // 
            // labelMinSdk
            // 
            this.labelMinSdk.Location = new System.Drawing.Point(40, 135);
            this.labelMinSdk.Name = "labelMinSdk";
            this.labelMinSdk.Size = new System.Drawing.Size(100, 23);
            this.labelMinSdk.TabIndex = 6;
            this.labelMinSdk.Text = "最低 SDK：";
            // 
            // textMinSdk
            // 
            this.textMinSdk.Location = new System.Drawing.Point(160, 135);
            this.textMinSdk.Name = "textMinSdk";
            this.textMinSdk.ReadOnly = true;
            this.textMinSdk.Size = new System.Drawing.Size(315, 21);
            this.textMinSdk.TabIndex = 7;
            // 
            // labelTargetSdk
            // 
            this.labelTargetSdk.Location = new System.Drawing.Point(40, 170);
            this.labelTargetSdk.Name = "labelTargetSdk";
            this.labelTargetSdk.Size = new System.Drawing.Size(100, 23);
            this.labelTargetSdk.TabIndex = 8;
            this.labelTargetSdk.Text = "目标 SDK：";
            // 
            // textTargetSdk
            // 
            this.textTargetSdk.Location = new System.Drawing.Point(160, 170);
            this.textTargetSdk.Name = "textTargetSdk";
            this.textTargetSdk.ReadOnly = true;
            this.textTargetSdk.Size = new System.Drawing.Size(315, 21);
            this.textTargetSdk.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "提取so";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "更多信息";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 274);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPackageName);
            this.Controls.Add(this.textPackageName);
            this.Controls.Add(this.labelMainActivity);
            this.Controls.Add(this.textMainActivity);
            this.Controls.Add(this.labelVersionName);
            this.Controls.Add(this.textVersionName);
            this.Controls.Add(this.labelMinSdk);
            this.Controls.Add(this.textMinSdk);
            this.Controls.Add(this.labelTargetSdk);
            this.Controls.Add(this.textTargetSdk);
            this.Name = "Form2";
            this.Text = "App 信息查看器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label labelPackageName;
        private System.Windows.Forms.TextBox textPackageName;
        private System.Windows.Forms.Label labelMainActivity;
        private System.Windows.Forms.TextBox textMainActivity;
        private System.Windows.Forms.Label labelVersionName;
        private System.Windows.Forms.TextBox textVersionName;
        private System.Windows.Forms.Label labelMinSdk;
        private System.Windows.Forms.TextBox textMinSdk;
        private System.Windows.Forms.Label labelTargetSdk;
        private System.Windows.Forms.TextBox textTargetSdk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}