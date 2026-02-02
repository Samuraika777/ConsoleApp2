using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTworzeniaStronyWKsiazce()
        {
            Ksiazka ksiazka = new Ksiazka("Strona1");
            Strona strona = new Strona("Strona1");

            Assert.AreEqual(
                strona.trescStrony,
                ksiazka.strony[0].trescStrony
            );
        }

        [TestMethod]
        public void TestowanieWczytywanieZPliku()
        {
            string daneZPliku = File.ReadAllText(@"C:\Users\Student\Desktop\dane.txt");
            string[] tablicaStron = daneZPliku.Split(";");

            Ksiazka ksiazka = new Ksiazka(tablicaStron[0]);

            for (int i = 1; i < tablicaStron.Length; i++)
            {
                ksiazka.DodajStrone(tablicaStron[i]);
            }

            string daneDoTestowania =
             "Powrót do miasta nie by³ ju¿ ucieczk¹, lecz wyborem. Ulice wydawa³y siê jaœniejsze, a ludzie mniej obcy. Adam zatrzyma³ siê przy tym samym zegarze, który kiedyœ go niepokoi³. Tym razem uœmiechn¹³ siê, widz¹c jego niedok³adnoœæ. Czas nie by³ wrogiem, lecz towarzyszem. Wiedzia³, ¿e przed nim jeszcze wiele niewiadomych, ale nie ba³ siê ich jak dawniej. Z listem schowanym g³êboko w kieszeni ruszy³ przed siebie, gotów pisaæ dalsz¹ czêœæ w³asnej historii.";

            Assert.AreEqual(
                daneDoTestowania.Trim(),
                ksiazka.strony[ksiazka.strony.Count - 1].trescStrony.Trim()
            );
        }
    }
}
