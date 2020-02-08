using Common;
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


            RabbitMqHelper.Send(channelName);

            Console.ReadLine();
        }


    }

}
