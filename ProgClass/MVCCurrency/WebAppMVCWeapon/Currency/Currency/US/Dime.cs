using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Dime : USCoin
    {
        public Dime() { }

        public Dime(USCoinMintMark m)
        {
            MintMark = m;
            MonetaryValue = 0.10;
        }
    }
}
