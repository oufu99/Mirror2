using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            //多线程的意义就是不做无谓的等待  什么时候需要结果了再去用就行了
            Console.WriteLine("主流程1");
            Console.WriteLine("开始执行耗时操作");
            Task1();
            Console.WriteLine("主流程2");

            Console.ReadLine();

        }

        static async void Task1()
        {
            // 如果不加await就像普通的异步直接向下走了  但是如果加了线程就会先回到主线程,然后等Task完了再继续向下走 如果需要返回值,就可以使用Result来获取结果
            Console.WriteLine("耗时操作1");
            await Task.Run(() => { Thread.Sleep(3000); });
            Console.WriteLine("耗时操作1完成");

        }
    }
}
