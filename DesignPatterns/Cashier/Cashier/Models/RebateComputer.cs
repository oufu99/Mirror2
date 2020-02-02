using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier.Models
{
    public class RebateComputer : ICashComputer
    {
        private decimal targetMoney;
        private decimal rebateMoney;



        public RebateComputer(decimal _targetMoney, decimal _rebateMoney)
        { 
            targetMoney = _targetMoney;
            rebateMoney = _rebateMoney;
        }
        /// <summary>
        /// 满减计算方式
        /// </summary>
        /// <param name="money"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        public decimal Computer(decimal money)
        {
            if (money < targetMoney)
            {
                return money;
            }
            var result = money - rebateMoney;
            result = Math.Round(Convert.ToDecimal(result), 2);
            return result;
        }
    }
}
