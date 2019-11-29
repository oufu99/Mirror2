﻿using Aaron.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            var isOnlyPull = ConfigHelper.GetAppConfig("IsOnlyPull");
            var pathList = path.Split(new string[] { @";" }, StringSplitOptions.RemoveEmptyEntries);
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
            Task.WaitAll(taskList.ToArray());
            sw.Stop();
            Console.WriteLine("运行了" + sw.ElapsedMilliseconds / 1000 + "秒");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("执行完毕");
            }
            Console.ReadLine();
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
                 List<string> list = new List<string>();
                 list.Add(disk);
                 list.Add($"cd {path}");

                 list.Add("git pull");
                 list.Add("git add *");
                 list.Add("git  commit -m \"Aaron的程序自动批量提交\"");
                 list.Add("git push");

                 string res = CMDHelper.Excute(list);
                 Console.WriteLine(res);
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
               List<string> list = new List<string>();
               list.Add("chcp 65001");
               list.Add(disk);
               list.Add($"cd {path}");
               list.Add("git pull");
               string res = CMDHelper.Excute(list);
               Console.WriteLine(res);
               return res;
           });
        }

    }
}
