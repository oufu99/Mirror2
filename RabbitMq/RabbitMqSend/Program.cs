using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMqSend
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelName = "AaronMq";

            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";

            using (var conn = factory.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.QueueDeclare(channelName, false, false, false, null);
                    var prop = channel.CreateBasicProperties();
                    prop.DeliveryMode = 2;
                    for (int i = 0; i < 100; i++)
                    {
                        string msg = "遇到困难不要怕,勇敢的面对它" + i.ToString();
                        channel.BasicPublish("", channelName, prop, Encoding.UTF8.GetBytes(msg));
                        Console.WriteLine("发送了" + msg);
                        Thread.Sleep(3000);
                    }

                }
            }


            Console.ReadLine();
        }


    }

}
