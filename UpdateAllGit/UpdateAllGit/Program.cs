using Aaron.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpdateAllGit
{
    class Program
    {
        public static List<string> proList = new List<string>();
        public static string IsContinue;
        static void Main(string[] args)
        {
            //调用cmd命令
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var disk = ConfigHelper.GetAppConfig("Disk");
            var path = ConfigHelper.GetAppConfig("GitPath");
            var isOnlyPull = ConfigHelper.GetAppConfig("IsOnlyPull");
            var pathList = path.Split(new string[] { @";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var arr = new string[pathList.Count];
            //新改了要加上盘符
            for (int i = 0; i < pathList.Count; i++)
            {
                pathList[i] = Path.Combine(disk, pathList[i]);
            }
            pathList.CopyTo(arr, 0);
            proList = arr.ToList();

            var list = new List<string>();


            var taskList = new List<Task>();
            foreach (var item in pathList)
            {

                if (isOnlyPull == "1")
                {
                    var res = PullGit(item);
                    taskList.Add(res);
                }
                else
                {
                    var res = UpdateGit(item);
                    taskList.Add(res);
                }

            }
            Task.Run(() =>
            {
                while (proList.Count > 0)
                {
                    Console.WriteLine($"还剩下{string.Join(",", proList)}");
                    Thread.Sleep(2000);
                }
            });
            Task.WaitAll(taskList.ToArray());
            sw.Stop();
            Console.WriteLine("运行了" + sw.ElapsedMilliseconds / 1000 + "秒");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("执行完毕");
            }

            Task.Run(() =>
            {
                Console.WriteLine("输入任意键终止退出");
                IsContinue = Console.ReadLine();
                Console.WriteLine("已经终止退出");

            });
            Thread.Sleep(5000);
            if (!string.IsNullOrEmpty(IsContinue))
            {
                Console.WriteLine("停止退出");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 拉取并提交
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static async Task<string> UpdateGit(string path)
        {
            return await Task.Run(() =>
            {
                Console.WriteLine(path + "开始同步");
                string disk = FileHelper.GetDiskNameByFullPath(path);
                List<string> list = GetCommonList();
                list.Add(disk);
                list.Add($"cd {path}");

                list.Add("git pull");
                list.Add("git add .");
                list.Add("git commit -m \"aaron commit\"");

                list.Add("git push");

                string res = CMDHelper.Excute(list);
                Console.WriteLine(res);
                proList.Remove(path);
                return res;
            });
        }

        /// <summary>
        /// 只需要拉取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static async Task<string> PullGit(string path)
        {
            return await Task.Run(() =>
           {
               Console.WriteLine(path + "开始拉取");
               string disk = FileHelper.GetDiskNameByFullPath(path);
               List<string> list = GetCommonList();
               list.Add(disk);
               list.Add($"cd {path}");
               list.Add("git pull");
               string res = CMDHelper.Excute(list);
               Console.WriteLine(res);
               proList.Remove(path);
               return res;
           });
        }

        /// <summary>
        /// 获取通用的List语句
        /// </summary>
        /// <returns></returns>
        private static List<string> GetCommonList()
        {
            var list = new List<string>();
            //加了这个以后 命令行中不能出现中文,不然会提交不上去
            list.Add("chcp 65001");
            return list;
        }
    }
}
