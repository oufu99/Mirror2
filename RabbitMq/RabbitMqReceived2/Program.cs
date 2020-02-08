using Common;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqReceived2
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelName2 = "AaronMq2";

            EventHandler<BasicDeliverEventArgs> func = (model, ea) =>
            {
                var body = ea.Body;
                var msg = Encoding.UTF8.GetString(body);
                Console.WriteLine("第二个处理中...");
                Console.WriteLine(channelName2 + "接收到了:" + msg);
            };
            RabbitMqHelper.Received(channelName2, func);
        }
    }
}
