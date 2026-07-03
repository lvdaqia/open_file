namespace open_file
{
    partial class Form4
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
            this.btnPower = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnVolUp = new System.Windows.Forms.Button();
            this.btnVolDown = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            // 数字键与功能键
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // --- 第一栏：电源 与 静音 ---
            this.btnPower.BackColor = System.Drawing.Color.White;
            this.btnPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPower.Location = new System.Drawing.Point(30, 20);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(65, 45);
            this.btnPower.Text = "电源";

            this.btnMute.BackColor = System.Drawing.Color.White;
            this.btnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMute.Location = new System.Drawing.Point(155, 20);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(65, 45);
            this.btnMute.Text = "静音";

            // --- 第二栏：音量 ---
            this.btnVolUp.BackColor = System.Drawing.Color.White;
            this.btnVolUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolUp.Location = new System.Drawing.Point(30, 75);
            this.btnVolUp.Name = "btnVolUp";
            this.btnVolUp.Size = new System.Drawing.Size(90, 40);
            this.btnVolUp.Text = "音量 +";

            this.btnVolDown.BackColor = System.Drawing.Color.White;
            this.btnVolDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolDown.Location = new System.Drawing.Point(130, 75);
            this.btnVolDown.Name = "btnVolDown";
            this.btnVolDown.Size = new System.Drawing.Size(90, 40);
            this.btnVolDown.Text = "音量 -";

            // --- 第三栏：菜单 与 设置 ---
            this.btnMenu.BackColor = System.Drawing.Color.White;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Location = new System.Drawing.Point(30, 125);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(90, 40);
            this.btnMenu.Text = "菜单";

            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(130, 125);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(90, 40);
            this.btnSettings.Text = "设置";

            // --- 方向键区 ---
            this.btnUp.BackColor = System.Drawing.Color.White;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(95, 180);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(60, 50);
            this.btnUp.Text = "▲";

            this.btnLeft.BackColor = System.Drawing.Color.White;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Location = new System.Drawing.Point(30, 235);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(60, 50);
            this.btnLeft.Text = "◀";

            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(95, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 50);
            this.btnOK.Text = "OK";

            this.btnRight.BackColor = System.Drawing.Color.White;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Location = new System.Drawing.Point(160, 235);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(60, 50);
            this.btnRight.Text = "▶";

            this.btnDown.BackColor = System.Drawing.Color.White;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(95, 290);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(60, 50);
            this.btnDown.Text = "▼";

            // --- 数字键区 (从 Y=350 开始) ---
            // 第一排: 1, 2, 3
            this.btn1.BackColor = System.Drawing.Color.White;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Location = new System.Drawing.Point(30, 350);
            this.btn1.Size = new System.Drawing.Size(60, 45);
            this.btn1.Text = "1";

            this.btn2.BackColor = System.Drawing.Color.White;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Location = new System.Drawing.Point(95, 350);
            this.btn2.Size = new System.Drawing.Size(60, 45);
            this.btn2.Text = "2";

            this.btn3.BackColor = System.Drawing.Color.White;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Location = new System.Drawing.Point(160, 350);
            this.btn3.Size = new System.Drawing.Size(60, 45);
            this.btn3.Text = "3";

            // 第二排: 4, 5, 6
            this.btn4.BackColor = System.Drawing.Color.White;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Location = new System.Drawing.Point(30, 400);
            this.btn4.Size = new System.Drawing.Size(60, 45);
            this.btn4.Text = "4";

            this.btn5.BackColor = System.Drawing.Color.White;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Location = new System.Drawing.Point(95, 400);
            this.btn5.Size = new System.Drawing.Size(60, 45);
            this.btn5.Text = "5";

            this.btn6.BackColor = System.Drawing.Color.White;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Location = new System.Drawing.Point(160, 400);
            this.btn6.Size = new System.Drawing.Size(60, 45);
            this.btn6.Text = "6";

            // 第三排: 7, 8, 9
            this.btn7.BackColor = System.Drawing.Color.White;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Location = new System.Drawing.Point(30, 450);
            this.btn7.Size = new System.Drawing.Size(60, 45);
            this.btn7.Text = "7";

            this.btn8.BackColor = System.Drawing.Color.White;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Location = new System.Drawing.Point(95, 450);
            this.btn8.Size = new System.Drawing.Size(60, 45);
            this.btn8.Text = "8";

            this.btn9.BackColor = System.Drawing.Color.White;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Location = new System.Drawing.Point(160, 450);
            this.btn9.Size = new System.Drawing.Size(60, 45);
            this.btn9.Text = "9";

            // 第四排: . , 0 , 删除
            this.btnDot.BackColor = System.Drawing.Color.White;
            this.btnDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDot.Location = new System.Drawing.Point(30, 500);
            this.btnDot.Size = new System.Drawing.Size(60, 45);
            this.btnDot.Text = ".";

            this.btn0.BackColor = System.Drawing.Color.White;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Location = new System.Drawing.Point(95, 500);
            this.btn0.Size = new System.Drawing.Size(60, 45);
            this.btn0.Text = "0";

            this.btnDel.BackColor = System.Drawing.Color.White;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(160, 500);
            this.btnDel.Size = new System.Drawing.Size(60, 45);
            this.btnDel.Text = "删除";
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 8F);

            // --- 底部：返回 与 Home ---
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(30, 565);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 45);
            this.btnBack.Text = "返回";

            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(130, 565);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(90, 45);
            this.btnHome.Text = "主页";

            // --- Form 设置 ---
            this.ClientSize = new System.Drawing.Size(250, 630);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnVolUp);
            this.Controls.Add(this.btnVolDown);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Text = "遥控器";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnVolUp;
        private System.Windows.Forms.Button btnVolDown;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHome;
        // 数字键
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnDel;
    }
}