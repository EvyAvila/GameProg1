using Currency.US;
using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class MXCurrencyRepo : InternationalCurrencyRepo
    {
        public MXCurrencyRepo() { }
        public MXCurrencyRepo(double num) 
        {
            this.MakeChange(num);
        }

        public static ICurrencyRepo CreateChange(double Amount) 
        {
            return new MXCurrencyRepo(Amount);
        }
    }

    public class InternationalCurrencyRepo : ICurrencyRepo
    {
        //public List<ICoin> Coins { get; set; }
        public List<ICurrency> Coins { get; set; }
        public List<ICurrency> BankNotes { get; set; }

        public InternationalCurrencyRepo()
        {
            Coins = new List<ICurrency>();
            BankNotes = new List<ICurrency>();
        }

        public string About()
        {
            return String.Empty;
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        public void AddBankNote(IBankNote b)
        {
            BankNotes.Add(b);
        }

        public int GetCoinCount()
        {
            return Coins.Where(c => c != null).Count();
        }

        public int GetBankNoteCount()
        {
            return BankNotes.Where(b => b != null).Count(); 
        }

        public ICurrencyRepo MakeChange(double Amount)
        {
            Amount = MoneyCalculations(Amount);

            return this;
        }

        private double MoneyCalculations(double Amount)
        {
            //Based on https://codereview.stackexchange.com/questions/178839/change-return-program

            var bankNoteType = MEXBankNote.GetMXBankNoteList().OrderByDescending(x => x.MonetaryValue).ToList();
            var coinTypes = MEXCoin.GetMXCoinList().OrderByDescending(x => x.MonetaryValue).ToList();

            foreach (var bankN in bankNoteType) //goes through the whole collection
            {
                while(Amount >= bankN.MonetaryValue) //makes sure it doesn't move on until the amount can't subtract anymore
                {
                    if (Amount >= bankN.MonetaryValue) //if the amount is larger than the value, then can make change
                    {
                        BankNotes.Add(bankN);
                        Amount -= bankN.MonetaryValue;
                    }
                }
            }

            foreach(var coinN in coinTypes)
            {
                while(Amount >= coinN.MonetaryValue)
                {
                    if (Amount >= coinN.MonetaryValue)
                    {
                        Coins.Add(coinN);
                        Amount -= coinN.MonetaryValue;
                    }
                }
               
            }
            return Amount;
        }

        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            return this;
        }

        public ICoin RemoveCoin(ICoin c)
        {
            Coins.Remove(c);
            return c;
        }

        public IBankNote RemoveBankNote(IBankNote b)
        {
            BankNotes.Remove(b);    
            return b;
        }

        public double TotalValue()
        {
            Double num = 0.00;

            foreach(Coin coin in Coins)
            {
                num += coin.MonetaryValue;
            }

            foreach(BankNote bankNote in BankNotes)
            {
                num += bankNote.MonetaryValue;
            }

            return num;
        }
    }

}
