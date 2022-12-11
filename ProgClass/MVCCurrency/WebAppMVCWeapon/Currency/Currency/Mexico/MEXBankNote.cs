using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public enum MXWaterMark { MHC, DRFK, JIC, VC, JMM, BJ}
    public abstract class MEXBankNote : BankNote
    {
        public MXWaterMark WaterMark { get; set; }

        public MEXBankNote() { }

        public MEXBankNote(MXWaterMark waterMark) 
        {
            WaterMark = waterMark;
        }

        public override string About()
        {
            return $"Mexican {Name} is from {Year}. It is worth {MonetaryValue.ToString("c")}. The water mark is {GetWaterNameFromMark(WaterMark)}";
        }

        public static string GetWaterNameFromMark(MXWaterMark waterMark) 
        {
            string output = String.Empty;

            switch(waterMark)
            {
                case MXWaterMark.BJ: //20
                    output = "Benito Juarez";
                    break;
                case MXWaterMark.JMM: //50
                    output = "Jose Maria Morelos";
                    break;
                case MXWaterMark.VC: //100
                    output = "Venustiano Carranza";
                    break;
                case MXWaterMark.JIC: //200
                    output = "Sor Juana Inés de la Cruz";
                    break;
                case MXWaterMark.DRFK: //500
                    output = "Diego Rivera and Frida Kahlo";
                    break;
                case MXWaterMark.MHC: //1000
                    output = "Miguel Hidalgo y Costilla";
                    break;
            }

            return output;
        }

        public static List<IBankNote> GetMXBankNoteList()
        {
            IBankNote TwentyPBN = new TwentyPesosBankNote();
            IBankNote FiftyPBN = new FiftyPesosBankNote();
            IBankNote OneHundredPBN = new OneHundredPesosBankNote();
            IBankNote TwoHundredPBN = new TwoHundredPesosBankNote();
            IBankNote FiveHundredPBN = new FiveHundredPesosBankNote();
            IBankNote OneThousandPBN = new OneThousandPesosBankNote();
            


            List<IBankNote> bankNoteList = new List<IBankNote>
            {
                { OneThousandPBN },
                { FiveHundredPBN },
                { TwoHundredPBN },
                { OneHundredPBN },
                { FiftyPBN },
                { TwentyPBN }
            };

            return bankNoteList.OrderByDescending(c => c.MonetaryValue).ToList();
        }
    }
}
