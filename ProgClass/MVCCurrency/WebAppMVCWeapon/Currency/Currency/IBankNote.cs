using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public interface IBankNote : ICurrency
    {
        public int Year { get; }
    }
}
