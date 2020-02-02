using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier.Models
{
    public class NormalComputer : ICashComputer
    {
        private decimal discount ;
        public NormalComputer(decimal _discount)
        {
            this.discount = _discount;
        }
        public decimal Computer(decimal money)
        {
            var result = money * discount;
            result = Math.Round(Convert.ToDecimal(result), 2);
            return result;
        }
    }
}
