using Aaron.DataCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Threading;

namespace PubSubPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            RedisHelper redis = new RedisHelper();

            for (var i = 1; i < 20; i++)
            {

                RedisHelper.Using(
                    rd =>
                    {
                        rd.Use(1).RedisPub<string>("aaronSay", i.ToString());
                    });

                Thread.Sleep(200);
            }


        }
    }
}
