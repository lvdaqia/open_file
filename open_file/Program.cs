using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace open_file
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 示例：禁用 Guna UI Framework 的自动检查更新

            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(form1);
        }
    }
}
