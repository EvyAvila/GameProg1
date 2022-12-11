using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Penny : USCoin
    {
        public Penny() : this(USCoinMintMark.D)
        {

        }

        public Penny(USCoinMintMark m)
        {
            MintMark = m;
            Year = 2017;
            Name = "Penny";
            MonetaryValue = 0.01;
        }
    }
}
