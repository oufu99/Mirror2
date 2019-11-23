using Aaron.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateAllGit
{
    class Program
    {
        static void Main(string[] args)
        {
            //调用cmd命令

            var path = ConfigHelper.GetAppConfig("GitPath");
            var pathList = path.Split(new string[] { @";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in pathList)
            {
                string disk = FileHelper.GetDiskNameByFullPath(item);
                List<string> list = new List<string>();
                list.Add(disk);
                list.Add($"cd {item}");

                list.Add("git pull");
                list.Add("git add *");
                list.Add("git  commit -m \"批量提交\"");
                list.Add("git push");


                string res = Excute(list);
                Console.WriteLine(res);
            }
            Console.WriteLine("执行完毕");

            Console.ReadLine();
        }

        public static string Excute(List<string> strList)
        {
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Verb = "runas";

            //启动程序
            p.Start();
            foreach (var item in strList)
            {
                p.StandardInput.WriteLine(item + Environment.NewLine);
            }
            p.StandardInput.AutoFlush = true;
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine("exit");
            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
           return strOuput;
        }
    }
}
