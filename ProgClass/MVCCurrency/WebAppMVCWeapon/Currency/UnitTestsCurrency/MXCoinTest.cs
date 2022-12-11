using Currency.Mexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTestsCurrency
{
    [TestClass]
    public class MXCoinTest
    {
        FiveCentCoin fiveC;
        TenCentCoin tenC;
        TwentyCentCoin twentyC;
        FiftyCentCoin fiftyC;
        OnePesoCoin oneDollarC;
        TwoPesosCoin twoDollarC;
        FivePesosCoin fiveDollarC;
        TenPesosCoin tenDollarC;

        public MXCoinTest() 
        {
            fiveC = new FiveCentCoin();
            tenC = new TenCentCoin();
            twentyC = new TwentyCentCoin();
            fiftyC= new FiftyCentCoin();
            oneDollarC = new OnePesoCoin();
            twoDollarC = new TwoPesosCoin();
            fiveDollarC = new FivePesosCoin();
            tenDollarC = new TenPesosCoin();
        }

        [TestMethod]
        public void MX5CentAbout()
        {
            //Arrange
            fiveC = new FiveCentCoin();

            //Act
            string About = $"Mexican 5 centavos is from 2022. It is worth $0.05. It was made in La Casa de Moneda de México";

            //Assert
            Assert.AreEqual(About, fiveC.About());

        }

        [TestMethod]
        public void MXCentAbout()
        {
            //Arrange
            tenC = new TenCentCoin();
            fiftyC = new FiftyCentCoin();
            oneDollarC = new OnePesoCoin();
            fiveDollarC = new FivePesosCoin();

            string TenCentAbout, FiftyCentAbout, OneDollarAbout, FiveDollarAbout;
            
            //Act
            TenCentAbout = $"Mexican 10 centavos is from 2022. It is worth $0.10. It was made in La Casa de Moneda de México";
            FiftyCentAbout = $"Mexican 50 centavos is from 2022. It is worth $0.50. It was made in La Casa de Moneda de México";
            OneDollarAbout = $"Mexican 1 peso is from 2022. It is worth $1.00. It was made in La Casa de Moneda de México";
            FiveDollarAbout = $"Mexican 5 pesos is from 2022. It is worth $5.00. It was made in La Casa de Moneda de México";


            //Assert
            Assert.AreEqual(TenCentAbout, tenC.About());
            Assert.AreEqual(FiftyCentAbout, fiftyC.About());
            Assert.AreEqual(OneDollarAbout, oneDollarC.About());
            Assert.AreEqual(FiveDollarAbout, fiveDollarC.About());

        }

        [TestMethod]
        public void MX5CentMonetaryValue()
        {
            //Arrange
            fiveC= new FiveCentCoin();

            //Act

            //Assert
            Assert.AreEqual(0.05, fiveC.MonetaryValue);
        }

        [TestMethod]
        public void MXCentMonetaryValue()
        {
            //Arrange
            twentyC = new TwentyCentCoin();
            twoDollarC = new TwoPesosCoin();
            tenDollarC = new TenPesosCoin();

            double twentyCentValue, twoDollarValue, tenDollarValue;

            //Act
            twentyCentValue = 0.20;
            twoDollarValue = 2.00;
            tenDollarValue = 10.00;

            //Assert
            Assert.AreEqual(twentyCentValue, twentyC.MonetaryValue);
            Assert.AreEqual(twoDollarValue, twoDollarC.MonetaryValue);
            Assert.AreEqual(tenDollarValue, tenDollarC.MonetaryValue);
        }

        [TestMethod]
        public void MXCoinMintMark()
        {
            //Arrange
            string mintNameOM;
            MexicanCoinMintMark om;

            //Act
            mintNameOM = "La Casa de Moneda de México";
            om = MexicanCoinMintMark.OM;

            //Assert
            Assert.AreEqual(MEXCoin.WriteMintNameFromMake(om), mintNameOM);
        }


        [TestMethod]
        public void MXCoinConstructor()
        {
            //Arrange
            fiveC = new FiveCentCoin();

            //Act
            int year = 2022;

            //Assert
            Assert.AreEqual(MexicanCoinMintMark.OM, fiveC.MXMintMark);
            Assert.AreEqual(year, fiveC.Year);
        }
    }
}
