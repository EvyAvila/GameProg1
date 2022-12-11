using Currency;
using Currency.US;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    //US currency Repo
    public class CurrencyRepo : ICurrencyRepo
    {
        //public List<ICoin> Coins { get; set; }
        public List<ICurrency> Coins { get; set; }
        public List<ICurrency> BankNotes { get; set; }

        public CurrencyRepo()
        {
            Coins = new List<ICurrency>();
            BankNotes = new List<ICurrency>();
        }

        public string About()
        {
            //throw new NotImplementedException();
            return "";
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        public void AddBankNote(IBankNote b)
        {
            //
        }

        public int GetCoinCount()
        {
            return Coins.Where(c => c != null).Count();
        }

        public int GetBankNoteCount()
        {
            return 0;
        }

        public ICurrencyRepo MakeChange(double Amount)
        {
            Amount = NewMethod(Amount);

            return this;
        }

        private double NewMethod(double Amount)
        {
            var coinType = USCoin.GetUSCoinList().OrderByDescending(x => x.MonetaryValue).ToList();

            foreach(var coinN in coinType)
            {
                while(Amount >= coinN.MonetaryValue)
                {
                    if(Amount >= coinN.MonetaryValue)
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
            return b;
        }

        public Double TotalValue()
        {
           Double num = 0.00;

           foreach(Coin coin in Coins)
           {
                num += coin.MonetaryValue;
           }

           return num;
        }

        //Not really used at this location without the test giving an issue
        public ICurrencyRepo CreateChange(double Amount)
        {
            return (ICurrencyRepo)Coins.Where(c => c.MonetaryValue == Amount);
        }
        
        //I didn't see a general test with two paramaters
        public ICurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            return (ICurrencyRepo)Coins.Where(c => c.MonetaryValue == AmountTendered);
        }
    }
}
