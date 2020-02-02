using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier.Models
{
    public class CashFactory
    {
        public static ICashComputer GetComputer(string switchValue)
        {
            switch (switchValue)
            {
                case "正常收费":
                    return new NormalComputer(1);
                case "打8折":
                    return new NormalComputer(0.8M);
                case "满100减50":
                    return new RebateComputer(100,50);
                default:
                    throw new Exception("系统未设置这种计算方式,请联系管理员!"); 
            }
        }
    }
}
