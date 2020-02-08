using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public class RabbitMqHelper
    {
        public static void Send(string channelName)
        {
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
                    for (int i = 0; i < 1; i++)
                    {
                        string msg = "大家遇到困难不要怕,勇敢的面对它" + i.ToString();
                        channel.BasicPublish("", channelName, prop, Encoding.UTF8.GetBytes(msg));
                        Console.WriteLine("发送了" + msg);
                        Thread.Sleep(3000);
                    }
                }
            }
        }

        public static void Received(string channelName, EventHandler<BasicDeliverEventArgs> func)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "guest";

            Console.WriteLine("接收开始");
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(channelName, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume(channelName, false, consumer);
                    consumer.Received += func;
                    consumer.Received += (obj, body) =>
                    {
                        channel.BasicAck(body.DeliveryTag, true);
                    };
                    Console.ReadLine();
                }
            }

        }
    }
}
