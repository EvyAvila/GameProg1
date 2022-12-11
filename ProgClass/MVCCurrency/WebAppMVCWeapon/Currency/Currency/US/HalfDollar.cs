using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class HalfDollar : USCoin
    {
        public HalfDollar() { }
        public HalfDollar(USCoinMintMark m)
        {
            MintMark = m;
            MonetaryValue = 0.50;
        }
    }
}
