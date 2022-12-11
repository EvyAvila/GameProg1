using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Quarter : USCoin
    {
        public Quarter() :this(USCoinMintMark.W) { }

        public Quarter(USCoinMintMark m)
        {
            MintMark = m;
            MonetaryValue = 0.25;
            //Name = "Quarter";
        }
    }
}
