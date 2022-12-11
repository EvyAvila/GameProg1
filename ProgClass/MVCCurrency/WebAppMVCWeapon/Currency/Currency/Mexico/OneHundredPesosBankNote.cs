using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class OneHundredPesosBankNote : MEXBankNote
    {
        public OneHundredPesosBankNote() :this(MXWaterMark.VC) { }
        public OneHundredPesosBankNote(MXWaterMark m) 
        {
            Name = "100 pesos";
            MonetaryValue = 100.00;
            WaterMark = m;
        }
    }
}
