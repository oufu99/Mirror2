using Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqReceived
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelName = "AaronMq";
            var channelName2 = "AaronMq2";
            EventHandler<BasicDeliverEventArgs> func = (model, ea) =>
              {
                  var body = ea.Body;
                  var msg = Encoding.UTF8.GetString(body);
                  Console.WriteLine("第一个处理中...");
                  Console.WriteLine(channelName + "接收到了:" + msg);
                  Console.WriteLine("向第二个Mq发送信息...");
                  //如果要添加链条其实可以直接写在这  也可以这个方法被调用的时候传入  总是肯定有一个地方会传进来的
                  RabbitMqHelper.Send(channelName2);
              };
            RabbitMqHelper.Received(channelName, func);



            Console.ReadLine();
        }
    }
}
