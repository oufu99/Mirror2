using Aaron.DataCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubClient
{
    class Program
    {
        private static RedisHelper redis;

        static void Main(string[] args)
        {

            redis = new RedisHelper();
            redis.RedisSubMessageEvent += RedisSubMessageEvent;
            redis.Use(1).RedisSub("aaronSay");

            Console.ReadKey();

        }

        private static void RedisSubMessageEvent(string msg)
        {

            Console.Write($"接到订阅,消息是{msg}");
        }
    }
}
