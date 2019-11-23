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


                string res = CMDHelper.Excute(list);
                Console.WriteLine(res);
            }
            Console.WriteLine("执行完毕");
            Console.WriteLine("执行完毕");
            Console.WriteLine("执行完毕");
            Console.ReadLine();
        }


    }
}
