using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class OneThousandPesosBankNote : MEXBankNote
    {
        public OneThousandPesosBankNote() : this(MXWaterMark.MHC) { }

        public OneThousandPesosBankNote(MXWaterMark m)
        {
            //Year = 2022;
            Name = "1,000 pesos";
            MonetaryValue = 1000.00;
            WaterMark = m;
        }
    }
}
