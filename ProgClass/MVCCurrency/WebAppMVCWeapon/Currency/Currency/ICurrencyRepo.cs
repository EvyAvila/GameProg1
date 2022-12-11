using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public interface ICurrencyRepo
    {
        //public List<ICoin> Coins { get; set; }
        public List<ICurrency> Coins { get; set; }
        public List<ICurrency> BankNotes { get; set; }
        public string About();

        public void AddCoin(ICoin c);
        public void AddBankNote(IBankNote b);

        public int GetCoinCount();

        public int GetBankNoteCount();

        public ICurrencyRepo MakeChange(double Amount);
        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost);

        public ICoin RemoveCoin(ICoin c);
        public IBankNote RemoveBankNote(IBankNote b);

        public double TotalValue();

    }
}
