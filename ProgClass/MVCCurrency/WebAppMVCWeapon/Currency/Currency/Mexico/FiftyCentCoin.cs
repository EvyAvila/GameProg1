using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class FiftyCentCoin : MEXCoin
    {
        public FiftyCentCoin() : this(MexicanCoinMintMark.OM) { }

        public FiftyCentCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "50 centavos";
            MonetaryValue = 0.50;
            MXMintMark = m;
        }
    }
}
