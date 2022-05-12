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
            //获取当前项⽬的基⽬录  E:\hzrvs\ConsoleApplication1\ConsoleApplication1\bin\Debug\
            string path = AppDomain.CurrentDomain.BaseDirectory;
            //移除某个位置的后⼏个字符，我这⾥的意思是移除lenth-1 位置的后⼀个字符 E:\hzrvs\ConsoleApplication1\ConsoleApplication1\bin\Debug
            path = path.Remove(path.Length - 1, 1);
            //返回⼀个新字符串，其中当前实例中出现的所有指定字符串都替换为另⼀个指定的字符串
            //将/替换为\\  E:\hzrvs\ConsoleApplication1\ConsoleApplication1\bin\Debug
            path = path.Replace("/", "\\");
            //截取字符串，截取从0到最后⼀个\\出现的位置的字符串  E:\hzrvs\ConsoleApplication1\ConsoleApplication1\bin
            path = path.Substring(0, path.LastIndexOf("\\"));
            //拼串，拼出⾃⼰想要存放的位置的路径   E:\hzrvs\ConsoleApplication1\ConsoleApplication1\bin\logs\11-18\
            path = path + "\\logs\\" + DateTime.Now.Date.ToString("MM-dd");
            //检查这个路径存在吗，不存在就创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //创建路径后再定义log的文件名
            logfile = path + "\\" + "log.txt";
            writer = new StreamWriter(logfile, true, System.Text.Encoding.UTF8);
            //在⽂件⾥写入日期，TAG和Log信息
            writer.WriteLine(DateTime.Now.ToLocalTime().ToString() + "    " + TAG + "    " + logMessage);
            //关闭写⽂件的流
            writer.Close();
        }
    }
}
