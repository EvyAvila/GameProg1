using Currency.US;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCurrency
{
    [TestClass]
    public class PennyTests
    {

        [TestMethod]
        public void PennyConstructor()
        {
            //Arrange
            Penny p, philiPenny;
            //Act 
            p = new Penny();
            philiPenny = new Penny(USCoinMintMark.P);
            //Assert
            //D is the default mint mark
            //Current Year is default year

            Assert.AreEqual(USCoinMintMark.P, philiPenny.MintMark);
        }

        [TestMethod]
        public void PennyMonetaryValue()
        {
            //Arrange
            Penny p;
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        [TestMethod]
        public void PennyAbout()
        {
            //Arrange
            Penny p;
            //Act 
            p = new Penny();
            //Assert
            //About output "US Penny is from 2017. It is worth $0.01. It was made in Denver"
        }
    }
}
