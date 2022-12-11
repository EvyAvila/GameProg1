using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    public abstract class BankNote : IBankNote
    {
        public int Year { get; set; }

        public double MonetaryValue { get; set; }

        public string Name { get; set; }

        public BankNote()
        {
            this.Year = 2022;
        }

        public virtual string About()
        {
            //return String.Empty;
            string BankNoteAbout = String.Empty;

            BankNoteAbout += $"{Name} is from {Year}. It is worth {MonetaryValue.ToString("c")}";

            return BankNoteAbout;
        }
    }
}
