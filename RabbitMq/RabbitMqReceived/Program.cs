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


                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var msg = Encoding.UTF8.GetString(body);
                        Console.WriteLine("接收到了" + msg);
                        //channel.BasicAck(ea.DeliveryTag, true);
                    };
                    Console.ReadLine();
                }
            }


            Console.ReadLine();
        }
    }
}
