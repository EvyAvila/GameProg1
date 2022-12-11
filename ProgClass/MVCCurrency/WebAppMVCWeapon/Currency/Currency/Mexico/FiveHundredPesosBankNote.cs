using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class FiveHundredPesosBankNote : MEXBankNote
    {
        public FiveHundredPesosBankNote() :this(MXWaterMark.DRFK) { }
        public FiveHundredPesosBankNote(MXWaterMark m) 
        {
            //Year = 2022;
            Name = "500 pesos";
            MonetaryValue = 500.00;
            WaterMark= m;
        }
    }
}
