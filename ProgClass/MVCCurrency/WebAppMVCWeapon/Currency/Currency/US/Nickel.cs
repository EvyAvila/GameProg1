using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Nickel : USCoin
    {
        public Nickel() { }

        public Nickel(USCoinMintMark m)
        {
            MintMark = m;
            MonetaryValue = 0.05;
        }
    }
}
