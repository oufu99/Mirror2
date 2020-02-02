using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier.Models
{
    public interface ICashComputer
    {
        decimal Computer(decimal money);
    }
}
