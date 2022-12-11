using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class TenCentCoin : MEXCoin
    {
        public TenCentCoin() : this(MexicanCoinMintMark.OM) { }

        public TenCentCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "10 centavos";
            MonetaryValue = 0.10;
            MXMintMark = m;
        }
    }
}
