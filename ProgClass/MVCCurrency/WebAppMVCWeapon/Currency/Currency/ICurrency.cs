using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public interface ICurrency
    {
        public double MonetaryValue { get; }

        public string Name { get; }

        public string About();
    }
}
