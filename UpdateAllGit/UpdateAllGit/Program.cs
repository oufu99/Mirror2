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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var path = ConfigHelper.GetAppConfig("GitPath");
            var pathList = path.Split(new string[] { @";" }, StringSplitOptions.RemoveEmptyEntries);
            var taskList = new List<Task>();
            foreach (var item in pathList)
            {
                var res = UpdateGit(item);
                taskList.Add(res);
            }
            Task.WaitAll(taskList.ToArray());
            sw.Stop();
            Console.WriteLine("运行了" + sw.ElapsedMilliseconds / 1000 + "秒");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("执行完毕");
            }
            Console.ReadLine();
        }

        private static async Task<string> UpdateGit(string path)
        {
            return await Task.Run(() =>
             {
                 Console.WriteLine(path + "开始");
                 string disk = FileHelper.GetDiskNameByFullPath(path);
                 List<string> list = new List<string>();
                 list.Add(disk);
                 list.Add($"cd {path}");

                 list.Add("git pull");
                 list.Add("git add *");
                 list.Add("git  commit -m \"批量提交\"");
                 list.Add("git push");

                 string res = CMDHelper.Excute(list);
                 Console.WriteLine(res);
                 return res;
             });
        }
    }
}
