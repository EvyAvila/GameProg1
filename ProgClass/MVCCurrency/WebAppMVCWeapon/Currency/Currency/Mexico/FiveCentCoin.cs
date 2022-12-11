using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class FiveCentCoin : MEXCoin
    {
        public FiveCentCoin() : this(MexicanCoinMintMark.OM)
        { }

        public FiveCentCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "5 centavos";
            MonetaryValue = 0.05;
            MXMintMark = m;
        }
    }

   

}
