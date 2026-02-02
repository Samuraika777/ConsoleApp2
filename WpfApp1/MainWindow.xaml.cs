using ConsoleApp2;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public string Tytul { get; set; } = "";
        public string LewaStrona { get; set; } = "";
        public string PrawaStrona { get; set; } = "";
        public string Licznik { get; set; } = "";

        Ksiazka ksiazka;
        int indeksStrony = 0;

        public MainWindow()
        {
            InitializeComponent();
            WczytajKsiazke();
            OdswiezWidok();
            DataContext = this;
        }

        void WczytajKsiazke()
        {
            string daneZPliku = File.ReadAllText(@"C:\Users\Student\Desktop\dane.txt");
            string[] tablicaStron = daneZPliku.Split(";");

            ksiazka = new Ksiazka(tablicaStron[0]);

            for (int i = 1; i < tablicaStron.Length; i++)
                ksiazka.DodajStrone(tablicaStron[i]);
        }

        void OdswiezWidok()
        {
            if (indeksStrony < ksiazka.strony.Count)
                LewaStrona = ksiazka.strony[indeksStrony].trescStrony;
            else
                LewaStrona = "";

            if (indeksStrony + 1 < ksiazka.strony.Count)
                PrawaStrona = ksiazka.strony[indeksStrony + 1].trescStrony;
            else
                PrawaStrona = "";

            Tytul = ksiazka.strony[0].trescStrony;
            Licznik = $"Strony: {indeksStrony + 1}-{indeksStrony + 2} / {ksiazka.strony.Count}";

            DataContext = null;
            DataContext = this;
        }

        void Poprzednia_Click(object sender, RoutedEventArgs e)
        {
            if (indeksStrony >= 2)
            {
                indeksStrony -= 2;
                OdswiezWidok();
            }
        }

        void Nastepna_Click(object sender, RoutedEventArgs e)
        {
            if (indeksStrony + 2 < ksiazka.strony.Count)
            {
                indeksStrony += 2;
                OdswiezWidok();
            }
        }
    }
}
