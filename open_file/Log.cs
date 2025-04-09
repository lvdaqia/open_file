using System;
using System.IO;
namespace open_file
{
    public class Log
    {
        public static void Write(string TAG, string logMessage)
        {
            StreamWriter writer;
            string logfile;
            string path = Path.Combine(@"C:\Users", Environment.UserName, "XmlData");
            //检查这个路径存在吗，不存在就创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //创建路径后再定义log的文件名
            logfile = path +"\\"+ DateTime.Now.ToString("MM-dd") + "_log.txt";
            writer = new StreamWriter(logfile, true, System.Text.Encoding.UTF8);
            //在⽂件⾥写入日期，TAG和Log信息
            writer.WriteLine(DateTime.Now.ToLocalTime().ToString() + "    " + TAG + "    " + logMessage);
            //关闭写⽂件的流
            writer.Close();
        }
    }
}
