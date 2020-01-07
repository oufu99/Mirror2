using Aaron.DataCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace PubSubPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            RedisHelper redis = new RedisHelper();
            var client = redis.GetClient();
         
            client.Publish(new RedisChannel("aaron", RedisChannel.PatternMode.Auto), "i'm json");
        }
    }
}
