namespace open_file
{
    partial class Form5
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
            this.btnAllwinner = new System.Windows.Forms.Button();
            this.btnRockchip = new System.Windows.Forms.Button();
            this.btnAmlogic = new System.Windows.Forms.Button();
            this.btnDumpsysInput = new System.Windows.Forms.Button();
            this.btnGetPkg = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnGetAllPkgs = new System.Windows.Forms.Button();
            this.btnGetProps = new System.Windows.Forms.Button();
            this.SuspendLayout();

            int btnW = 200;
            int btnH = 40;
            int startX = 23;

            // 标题
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(12, 10);
            this.labelTitle.Size = new System.Drawing.Size(223, 23);
            this.labelTitle.Text = "ADB 高级工具箱";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ================== 第一组：常规查询与诊断 (只读命令) ==================

            // 1. 查看输入设备状态
            this.btnDumpsysInput.Location = new System.Drawing.Point(startX, 45);
            this.btnDumpsysInput.Size = new System.Drawing.Size(btnW, btnH);
            this.btnDumpsysInput.Text = "🔍 查看输入设备状态";
            this.btnDumpsysInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDumpsysInput.BackColor = System.Drawing.Color.White;

            // 2. 获取当前APP包名
            this.btnGetPkg.Location = new System.Drawing.Point(startX, 90);
            this.btnGetPkg.Size = new System.Drawing.Size(btnW, btnH);
            this.btnGetPkg.Text = "📦 获取当前APP包名";
            this.btnGetPkg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetPkg.BackColor = System.Drawing.Color.White;

            // 3. 获取所有APP包名
            this.btnGetAllPkgs.Location = new System.Drawing.Point(startX, 135);
            this.btnGetAllPkgs.Size = new System.Drawing.Size(btnW, btnH);
            this.btnGetAllPkgs.Text = "📋 获取所有APP包名";
            this.btnGetAllPkgs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAllPkgs.BackColor = System.Drawing.Color.White;

            // 4. 获取所有系统属性
            this.btnGetProps.Location = new System.Drawing.Point(startX, 180);
            this.btnGetProps.Size = new System.Drawing.Size(btnW, btnH);
            this.btnGetProps.Text = "⚙️ 获取所有系统属性";
            this.btnGetProps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetProps.BackColor = System.Drawing.Color.White;


            // ================== 第二组：固件升级与设备重启 (断开连接命令) ==================
            // 注意：这里的 Y 坐标从 180+40 = 220 额外增加了 15 像素的分组间距，从 235 开始

            // 5. 全志升级 (EFEX)
            this.btnAllwinner.Location = new System.Drawing.Point(startX, 235);
            this.btnAllwinner.Size = new System.Drawing.Size(btnW, btnH);
            this.btnAllwinner.Text = "全志升级 (EFEX)";
            this.btnAllwinner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllwinner.BackColor = System.Drawing.Color.White;

            // 6. RK 升级 (Loader)
            this.btnRockchip.Location = new System.Drawing.Point(startX, 280);
            this.btnRockchip.Size = new System.Drawing.Size(btnW, btnH);
            this.btnRockchip.Text = "RK 升级 (Loader)";
            this.btnRockchip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRockchip.BackColor = System.Drawing.Color.White;

            // 7. Amlogic 升级 (Update)
            this.btnAmlogic.Location = new System.Drawing.Point(startX, 325);
            this.btnAmlogic.Size = new System.Drawing.Size(btnW, btnH);
            this.btnAmlogic.Text = "Amlogic 升级 (Update)";
            this.btnAmlogic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmlogic.BackColor = System.Drawing.Color.White;

            // Form5 窗体设置
            this.ClientSize = new System.Drawing.Size(247, 390); // 刚好包住所有控件
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADB 工具箱";

            // 一次性整齐地添加所有控件
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.labelTitle,
            this.btnDumpsysInput, this.btnGetPkg, this.btnGetAllPkgs, this.btnGetProps,
            this.btnAllwinner, this.btnRockchip, this.btnAmlogic
             });
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Button btnAllwinner;
        private System.Windows.Forms.Button btnRockchip;
        private System.Windows.Forms.Button btnAmlogic;
        private System.Windows.Forms.Button btnNormalReboot;
        private System.Windows.Forms.Button btnDumpsysInput;
        private System.Windows.Forms.Button btnGetPkg;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnGetAllPkgs;
        private System.Windows.Forms.Button btnGetProps;
    }
}