using Aaron.DataCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            RedisHelper redis = new RedisHelper();
            var client=redis.GetClient();
            client.Publish();
        }
    }
}
