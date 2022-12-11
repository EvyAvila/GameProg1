using Currency.Mexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCurrency
{
    [TestClass]
    public class MXBankNoteTest
    {
        TwentyPesosBankNote twentyBN;
        FiftyPesosBankNote fiftyBN;
        OneHundredPesosBankNote oneHundredBN;
        TwoHundredPesosBankNote twoHundredBN;
        FiveHundredPesosBankNote fiveHundredBN;
        OneThousandPesosBankNote oneThousandBN;

        public MXBankNoteTest() 
        {
            twentyBN = new TwentyPesosBankNote();
            fiftyBN = new FiftyPesosBankNote();
            oneHundredBN = new OneHundredPesosBankNote();
            twoHundredBN = new TwoHundredPesosBankNote();
            fiveHundredBN = new FiveHundredPesosBankNote();
            oneThousandBN = new OneThousandPesosBankNote();
        }

        [TestMethod]
        public void MX20PesosAbout()
        {
            //Arrange
            twentyBN= new TwentyPesosBankNote();

            //Act
            string About = "Mexican 20 pesos is from 2022. It is worth $20.00. The water mark is Benito Juarez";
            
            //Assert
            Assert.AreEqual(About, twentyBN.About());
        }

        [TestMethod]
        public void MXPesosAbout()
        {
            //Arrange
            fiftyBN = new FiftyPesosBankNote();
            oneHundredBN = new OneHundredPesosBankNote();
            fiveHundredBN = new FiveHundredPesosBankNote();
            
            string fiftyAbout, oneHundredAbout, fiveHundredAbout;

            //Act
            fiftyAbout = "Mexican 50 pesos is from 2022. It is worth $50.00. The water mark is Jose Maria Morelos";
            oneHundredAbout = "Mexican 100 pesos is from 2022. It is worth $100.00. The water mark is Venustiano Carranza";
            fiveHundredAbout = "Mexican 500 pesos is from 2022. It is worth $500.00. The water mark is Diego Rivera and Frida Kahlo";

            //Assert
            Assert.AreEqual(fiftyAbout, fiftyBN.About());
            Assert.AreEqual(oneHundredAbout, oneHundredBN.About());
            Assert.AreEqual(fiveHundredAbout, fiveHundredBN.About());
        }

        [TestMethod]
        public void MX20BankNoteMonetaryValue()
        {
            //Arrange
            twentyBN = new TwentyPesosBankNote();

            //Act
            double value = 20;

            //Assert
            Assert.AreEqual(value, twentyBN.MonetaryValue);
        }

        [TestMethod]
        public void MXBankNoteMonetaryValue()
        {
            //Arrange
            twoHundredBN = new TwoHundredPesosBankNote();
            oneThousandBN = new OneThousandPesosBankNote();

            double twoHundredValue, oneThousandValue;

            //Act
            twoHundredValue = 200;
            oneThousandValue = 1000;

            //Assert
            Assert.AreEqual(twoHundredValue, twoHundredBN.MonetaryValue);
            Assert.AreEqual(oneThousandValue, oneThousandBN.MonetaryValue);
        }

        [TestMethod]
        public void MXBankNoteWaterMark()
        {
            //Arrange
            string waterNameBJ, waterNameJMM, waterNameVC, waterNameJIC, waterNameDRFK, waterNameMHC;
            MXWaterMark BJ, JMM, VC, JIC, DRFK, MHC;

            //Act
            waterNameBJ = "Benito Juarez";
            waterNameJMM = "Jose Maria Morelos";
            waterNameVC = "Venustiano Carranza";
            waterNameJIC = "Sor Juana Inés de la Cruz";
            waterNameDRFK = "Diego Rivera and Frida Kahlo";
            waterNameMHC = "Miguel Hidalgo y Costilla";
            BJ = MXWaterMark.BJ;
            JMM = MXWaterMark.JMM;
            VC = MXWaterMark.VC;
            JIC = MXWaterMark.JIC;
            DRFK= MXWaterMark.DRFK;
            MHC = MXWaterMark.MHC;

            //Assert
            Assert.AreEqual(MEXBankNote.GetWaterNameFromMark(BJ), waterNameBJ);
            Assert.AreEqual(MEXBankNote.GetWaterNameFromMark(JMM), waterNameJMM);
            Assert.AreEqual(MEXBankNote.GetWaterNameFromMark(VC), waterNameVC);
            Assert.AreEqual(MEXBankNote.GetWaterNameFromMark(JIC), waterNameJIC);
            Assert.AreEqual(MEXBankNote.GetWaterNameFromMark(DRFK), waterNameDRFK);
            Assert.AreEqual(MEXBankNote.GetWaterNameFromMark(MHC), waterNameMHC);
        }

        [TestMethod]
        public void MXBankNoteConstructor()
        {
            //Arrange
            twentyBN = new TwentyPesosBankNote();

            //Act
            int year = 2022;

            //Assert
            Assert.AreEqual(year, twentyBN.Year);
            Assert.AreEqual(MXWaterMark.BJ, twentyBN.WaterMark);
        }
    }
}
