using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class DollarCoin : USCoin
    {
        public DollarCoin() { }

        public DollarCoin(USCoinMintMark m)
        {
            MintMark = m;
            MonetaryValue = 1.00;
        }
    }
}
