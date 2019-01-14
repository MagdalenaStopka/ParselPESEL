using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserPESEL.Test
{
    [TestClass]
    public class ParserPESELTest
    {
        [TestMethod]
        public void SprawdzDlugoscTestPowinienZwracacTrueGdyLiczbaZnakowWPESELJestRowna11()
        {
            string PESEL = "234-78976o8";
            Program p = new Program();
            bool oczekiwanaDlugosc = true;
            bool aktualnaDlugosc = p.SprawdzDlugosc(PESEL);
            Assert.AreEqual(oczekiwanaDlugosc, aktualnaDlugosc);
        }

        [TestMethod]
        public void SprawdzZnakiTestSpradzaCzyWPESELUSaTylkoCyfryPowinienZamienicStringNaLong()
        {
            string PESEL = "234578976889";
            Program p = new Program();
            long oczekiwaneCyfry = long.Parse(PESEL);
            long aktualneCyfry = p.SprawdzZnaki(PESEL);
            Assert.AreEqual(oczekiwaneCyfry, aktualneCyfry);
        }
        [TestMethod]
        public void DataUrodzeniaTestPowinienZWracacDateUrodzeniaZSzesciuPierwszychCyfr()
        {
            string PESEL = "961207897688";
            Program p = new Program();
            string dataUrodzeniaOczekiwana = "07-12-96";
            string dataUrodzeniaAktulana = p.DataUrodzenia(PESEL);
            Assert.AreEqual(dataUrodzeniaOczekiwana, dataUrodzeniaAktulana);
        }

        [TestMethod]
        public void SprawdzCyfreKontrolnaTestPowinienZwracacFalseWPrzypadkuNiepoprawnegoPESEL()
        {

            string PESEL = "23457897688";
            Program p = new Program();
            bool oczekiwanaCyfraKontrolna = false;

            bool aktualnaCyfraKontrolna = p.SprawdzCyfreKontrolna(PESEL);
            Assert.AreEqual(oczekiwanaCyfraKontrolna, aktualnaCyfraKontrolna);
        }
    }
}
