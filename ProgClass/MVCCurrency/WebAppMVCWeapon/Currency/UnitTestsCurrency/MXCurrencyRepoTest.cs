using Currency.Mexico;
using Currency.US;
using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCurrency
{
    [TestClass]
    public class MXCurrencyRepoTest
    {
        //Come back 
        ICurrencyRepo repo;
        FiveCentCoin fiveC;
        TenCentCoin tenC;
        TwentyCentCoin twentyC;
        FiftyCentCoin fiftyC;
        OnePesoCoin oneDollarC;
        TwoPesosCoin twoDollarC;
        FivePesosCoin fiveDollarC;
        TenPesosCoin tenDollarC;

        TwentyPesosBankNote twentyBN;
        FiftyPesosBankNote fiftyBN;
        OneHundredPesosBankNote oneHundredBN;
        TwoHundredPesosBankNote twoHundredBN;
        FiveHundredPesosBankNote fiveHundredBN;
        OneThousandPesosBankNote oneThousandBN;

        public MXCurrencyRepoTest()
        {
            repo = new MXCurrencyRepo();
            fiveC = new FiveCentCoin();
            tenC = new TenCentCoin();
            twentyC = new TwentyCentCoin();
            fiftyC = new FiftyCentCoin();
            oneDollarC = new OnePesoCoin();
            twoDollarC = new TwoPesosCoin();
            fiveDollarC = new FivePesosCoin();
            tenDollarC = new TenPesosCoin();
            twentyBN = new TwentyPesosBankNote();
            fiftyBN = new FiftyPesosBankNote();
            oneHundredBN = new OneHundredPesosBankNote();
            twoHundredBN = new TwoHundredPesosBankNote();
            fiveHundredBN = new FiveHundredPesosBankNote();
            oneThousandBN = new OneThousandPesosBankNote();

        }

        [TestMethod]
        public void AddCoinTest()
        {
            //Arrange
            int coinCountOrg, coinCountAfter5Cent, coinCountAfterFiveMore5Cent;
            int num5Cents = 5;

            Double valueOrg, valueAfter5Cent, valueAfterFiveMore5Cent;
            Double valueAfter10Cent, valueAfter20Cent, valueAfter50cent, valueAfter1Dollar;

            //Act
            coinCountOrg = repo.GetCoinCount();
            valueOrg = repo.TotalValue();

            repo.AddCoin(fiveC);
            coinCountAfter5Cent = repo.GetCoinCount();
            valueAfter5Cent = repo.TotalValue();

            for(int i =0; i < num5Cents; i++) 
            {
                repo.AddCoin(fiveC);
            }
            coinCountAfterFiveMore5Cent= repo.GetCoinCount();
            valueAfterFiveMore5Cent= repo.TotalValue();

            repo.AddCoin(tenC);
            valueAfter10Cent = repo.TotalValue();
            repo.AddCoin(twentyC);
            valueAfter20Cent = repo.TotalValue();
            repo.AddCoin(fiftyC);
            valueAfter50cent = repo.TotalValue();
            repo.AddCoin(oneDollarC);
            valueAfter1Dollar = repo.TotalValue();

            //Assert
            Assert.AreEqual(coinCountOrg + 1, coinCountAfter5Cent);
            Assert.AreEqual(coinCountAfter5Cent + num5Cents, coinCountAfterFiveMore5Cent);

            Assert.AreEqual(valueOrg + fiveC.MonetaryValue, valueAfter5Cent);
            Assert.AreEqual(valueAfter5Cent + (num5Cents * fiveC.MonetaryValue), valueAfterFiveMore5Cent);

            Assert.AreEqual(valueAfterFiveMore5Cent + tenC.MonetaryValue, valueAfter10Cent);
            Assert.AreEqual(valueAfter10Cent + twentyC.MonetaryValue, valueAfter20Cent);
            Assert.AreEqual(valueAfter20Cent + fiftyC.MonetaryValue, valueAfter50cent);
            Assert.AreEqual(valueAfter50cent + oneDollarC.MonetaryValue, valueAfter1Dollar);
        }

        [TestMethod]
        public void AddBankNoteTest() 
        {
            //Arrange
            int bankCountOrg, bankNoteCountAfter20Dollar, bankNoteCountAfterFiveMore20Dollar;
            int num20Dollar = 5;

            Double valueOrg, valueAfter20Dollar, valueAfterFiveMore20Dollar;
            Double valueAfter50dollar, valueAfter100Dollar, valueAfter200Dollar, valueAfter500Dollar;

            //Act
            bankCountOrg = repo.GetBankNoteCount();
            valueOrg = repo.TotalValue();

            repo.AddBankNote(twentyBN);
            bankNoteCountAfter20Dollar = repo.GetBankNoteCount();
            valueAfter20Dollar = repo.TotalValue();

            for (int i = 0; i < num20Dollar; i++)
            {
                repo.AddBankNote(twentyBN);
            }
            bankNoteCountAfterFiveMore20Dollar = repo.GetBankNoteCount();
            valueAfterFiveMore20Dollar = repo.TotalValue();

            repo.AddBankNote(fiftyBN);
            valueAfter50dollar = repo.TotalValue();
            repo.AddBankNote(oneHundredBN);
            valueAfter100Dollar = repo.TotalValue();
            repo.AddBankNote(twoHundredBN);
            valueAfter200Dollar = repo.TotalValue();
            repo.AddBankNote(fiveHundredBN);
            valueAfter500Dollar = repo.TotalValue();

            //Assert
            Assert.AreEqual(bankCountOrg + 1, bankNoteCountAfter20Dollar);
            Assert.AreEqual(bankNoteCountAfter20Dollar + num20Dollar, bankNoteCountAfterFiveMore20Dollar);

            Assert.AreEqual(valueOrg + twentyBN.MonetaryValue, valueAfter20Dollar);
            Assert.AreEqual(valueAfter20Dollar + (num20Dollar * twentyBN.MonetaryValue), valueAfterFiveMore20Dollar);

            Assert.AreEqual(valueAfterFiveMore20Dollar + fiftyBN.MonetaryValue, valueAfter50dollar);
            Assert.AreEqual(valueAfter50dollar + oneHundredBN.MonetaryValue, valueAfter100Dollar);
            Assert.AreEqual(valueAfter100Dollar + twoHundredBN.MonetaryValue, valueAfter200Dollar);
            Assert.AreEqual(valueAfter200Dollar + fiveHundredBN.MonetaryValue, valueAfter500Dollar);
        }

        [TestMethod]
        public void RemoveCoinTest()
        {
            #region Arrange
            //Arrange
            int coinCountOrg, coinCountAfter5Cent, coinCountAfterFiveMore5Cent;
            int num5Cents = 5;

            decimal valueOrg, valueAfter5Cent, valueAfterFiveMore5Cent;
            decimal valueAfter10Cent, valueAfter20Cent, valueAfter50cent, valueAfter1Dollar;

            repo = new InternationalCurrencyRepo();

            repo.AddCoin(fiveC);
            for (int i = 0; i < num5Cents; i++)
            {
                repo.AddCoin(fiveC);
            }
            repo.AddCoin(tenC);
            repo.AddCoin(twentyC);
            repo.AddCoin(fiftyC);
            repo.AddCoin(oneDollarC);
            #endregion
            #region Act
            //Act
            coinCountOrg = repo.GetCoinCount();
            valueOrg = (decimal)repo.TotalValue();

            repo.RemoveCoin(fiveC);
           
            coinCountAfter5Cent =   repo.GetCoinCount();
            valueAfter5Cent = (decimal)repo.TotalValue();

            for(int i = 0; i < num5Cents; i++) 
            {
                repo.RemoveCoin(fiveC);
            }

            coinCountAfterFiveMore5Cent = repo.GetCoinCount();
            valueAfterFiveMore5Cent = (decimal)repo.TotalValue();

            repo.RemoveCoin(tenC);
            valueAfter10Cent = (decimal)repo.TotalValue();
            repo.RemoveCoin(twentyC);
            valueAfter20Cent = (decimal)repo.TotalValue();
            repo.RemoveCoin(fiftyC);
            valueAfter50cent = (decimal)repo.TotalValue();
            repo.RemoveCoin(oneDollarC);
            valueAfter1Dollar = (decimal)repo.TotalValue();
            #endregion
            #region Assert
            //Assert
            Assert.AreEqual(coinCountOrg - 1, coinCountAfter5Cent);
            Assert.AreEqual(coinCountAfter5Cent - num5Cents, coinCountAfterFiveMore5Cent);

            //decimal decimaleValueOrg = (decimal)valueOrg
            Assert.AreEqual(valueOrg - (decimal)fiveC.MonetaryValue, valueAfter5Cent);
            Assert.AreEqual(valueAfter5Cent - (num5Cents * (decimal)fiveC.MonetaryValue), valueAfterFiveMore5Cent);

            Assert.AreEqual(valueAfterFiveMore5Cent - (decimal)tenC.MonetaryValue, valueAfter10Cent);
            Assert.AreEqual(valueAfter10Cent - (decimal)twentyC.MonetaryValue, valueAfter20Cent);
            Assert.AreEqual(valueAfter20Cent - (decimal)fiftyC.MonetaryValue, valueAfter50cent);
            Assert.AreEqual(valueAfter50cent - (decimal)oneDollarC.MonetaryValue, valueAfter1Dollar);
            #endregion
        }

        [TestMethod]
        public void RemoveBankNoteTest()
        {
            #region Arrange
            //Arrange
            int bankCountOrg, bankNoteCountAfter20Dollar, bankNoteCountAfterFiveMore20Dollar;
            int num20Dollar = 5;

            decimal valueOrg, valueAfter20Dollar, valueAfterFiveMore20Dollar;
            decimal valueAfter50dollar, valueAfter100Dollar, valueAfter200Dollar, valueAfter500Dollar;

            repo = new InternationalCurrencyRepo();

            repo.AddBankNote(twentyBN);
            for(int i = 0; i < num20Dollar; i++)
            {
                repo.AddBankNote(twentyBN);
            }
            repo.AddBankNote(fiftyBN);
            repo.AddBankNote(oneHundredBN);
            repo.AddBankNote(twoHundredBN);
            repo.AddBankNote(fiveHundredBN);
            #endregion
            //Act
            bankCountOrg = repo.GetBankNoteCount();
            valueOrg = (decimal)repo.TotalValue();

            repo.RemoveBankNote(twentyBN);

            bankNoteCountAfter20Dollar = repo.GetBankNoteCount();
            valueAfter20Dollar = (decimal)repo.TotalValue();

            for (int i = 0; i < num20Dollar; i++)
            {
                repo.RemoveBankNote(twentyBN);
            }
            bankNoteCountAfterFiveMore20Dollar = repo.GetBankNoteCount();
            valueAfterFiveMore20Dollar = (decimal)repo.TotalValue();

            repo.RemoveBankNote(fiftyBN);
            valueAfter50dollar = (decimal)repo.TotalValue();
            repo.RemoveBankNote(oneHundredBN);
            valueAfter100Dollar = (decimal)repo.TotalValue();
            repo.RemoveBankNote(twoHundredBN);
            valueAfter200Dollar = (decimal)repo.TotalValue();
            repo.RemoveBankNote(fiveHundredBN);
            valueAfter500Dollar = (decimal)repo.TotalValue();

            //Assert
            Assert.AreEqual(bankCountOrg - 1, bankNoteCountAfter20Dollar);
            Assert.AreEqual(bankNoteCountAfter20Dollar - num20Dollar, bankNoteCountAfterFiveMore20Dollar);

            Assert.AreEqual(valueOrg - (decimal)twentyBN.MonetaryValue, valueAfter20Dollar);
            Assert.AreEqual(valueAfter20Dollar - (num20Dollar * (decimal)twentyBN.MonetaryValue), valueAfterFiveMore20Dollar);

            Assert.AreEqual(valueAfterFiveMore20Dollar - (decimal)fiftyBN.MonetaryValue, valueAfter50dollar);
            Assert.AreEqual(valueAfter50dollar - (decimal)oneHundredBN.MonetaryValue, valueAfter100Dollar);
            Assert.AreEqual(valueAfter100Dollar - (decimal)twoHundredBN.MonetaryValue, valueAfter200Dollar);
            Assert.AreEqual(valueAfter200Dollar - (decimal)fiveHundredBN.MonetaryValue, valueAfter500Dollar);
        }

        [TestMethod]
        public void MakeChangeTest()
        {
            //Arrange
            MXCurrencyRepo change40Pesos50Cent, change1403Pesos, change580Pesos;

            //Act
            change40Pesos50Cent = (MXCurrencyRepo)MXCurrencyRepo.CreateChange(40.50);
            change1403Pesos = (MXCurrencyRepo)MXCurrencyRepo.CreateChange(1403);
            change580Pesos = (MXCurrencyRepo)MXCurrencyRepo.CreateChange(580);

            //Assert
            Assert.AreEqual(change40Pesos50Cent.Coins.Count, 1);
            Assert.AreEqual(change40Pesos50Cent.BankNotes.Count, 2);
            Assert.AreEqual(change40Pesos50Cent.Coins[0].GetType(), new FiftyCentCoin().GetType());
            Assert.AreEqual(change40Pesos50Cent.BankNotes[0].GetType(), new TwentyPesosBankNote().GetType());
            Assert.AreEqual(change40Pesos50Cent.BankNotes[1].GetType(), new TwentyPesosBankNote().GetType());

            Assert.AreEqual(change1403Pesos.Coins.Count, 2);
            Assert.AreEqual(change1403Pesos.BankNotes.Count, 3);
            Assert.AreEqual(change1403Pesos.Coins[0].GetType(), new TwoPesosCoin().GetType());
            Assert.AreEqual(change1403Pesos.Coins[1].GetType(), new OnePesoCoin().GetType());
            Assert.AreEqual(change1403Pesos.BankNotes[0].GetType(), new OneThousandPesosBankNote().GetType());
            Assert.AreEqual(change1403Pesos.BankNotes[1].GetType(), new TwoHundredPesosBankNote().GetType());
            Assert.AreEqual(change1403Pesos.BankNotes[2].GetType(), new TwoHundredPesosBankNote().GetType());

            Assert.AreEqual(change580Pesos.Coins.Count, 1);
            Assert.AreEqual(change580Pesos.BankNotes.Count, 3);
            Assert.AreEqual(change580Pesos.Coins[0].GetType(), new TenPesosCoin().GetType());
            Assert.AreEqual(change580Pesos.BankNotes[0].GetType(), new FiveHundredPesosBankNote().GetType());
            Assert.AreEqual(change580Pesos.BankNotes[1].GetType(), new FiftyPesosBankNote().GetType());
            Assert.AreEqual(change580Pesos.BankNotes[2].GetType(), new TwentyPesosBankNote().GetType());
        }
    }
}
