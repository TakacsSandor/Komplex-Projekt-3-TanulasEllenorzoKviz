using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TanulasEllenorzoKviz_TakacsSandor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> kerdesSzama = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int kSzam = 0;

        int i;

        int Pontszama;

        public MainWindow()
        {
            InitializeComponent();
            Beolvasas();
            EgyedikEloAllitasa();
            ListBoxFeltolteseTantargyNevekkel();
            Kerdesek();

        }
        public class Tantargy
        {
            public string tantargy;
            public string tema;
            public string kerdesek;
            public string valaszok;


        }
        static List<Tantargy> feladatok = new List<Tantargy>();
        public void Beolvasas()
        {
            string[] fajlNevek = { "fizikaKvizForras.txt", "informatikaKvizForras.txt", "magyarKvizForras.txt", "matematikaKvizForras.txt", "toriKvizForras.txt" };
            for (int i = 0; i < fajlNevek.Length; i++)
            {
                string[] forras = File.ReadAllLines(fajlNevek[i]);

                foreach (var sor in forras)
                {
                    string[] darab = sor.Split(';');
                    Tantargy egyAdat = new Tantargy();
                    egyAdat.tantargy = darab[0];
                    egyAdat.tema = darab[1];
                    egyAdat.kerdesek = darab[2];
                    egyAdat.valaszok = darab[3];
                    feladatok.Add(egyAdat);


                }
            }
        }

        static List<string> tantargyNevek = new List<string>();
        static List<List<string>> tantargyTemak = new List<List<string>>();

        public void EgyedikEloAllitasa()
        {
            foreach (var sor in feladatok)
            {
                if (!tantargyNevek.Contains(sor.tantargy))
                {
                    tantargyNevek.Add(sor.tantargy);
                }
            }
            foreach (var sor in tantargyNevek)
            {
                List<string> egySor = new List<string>();
                for (int i = 0; i < feladatok.Count; i++)
                {
                    if (feladatok[i].tantargy == sor)
                    {
                        if (!egySor.Contains(feladatok[i].tema))
                        {
                            egySor.Add(feladatok[i].tema);
                        }
                    }
                }
                tantargyTemak.Add(egySor);
            }

        }

        public void ListBoxFeltolteseTantargyNevekkel()
        {
            foreach (var sor in tantargyNevek)
            {
                tantargy.Items.Add(sor);
            }
        }
        public int listSorSzam = 0;
        private void tantargy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tema.Items.Clear();
            listSorSzam = tantargy.SelectedIndex;
            for (int i = 0; i < tantargyTemak[listSorSzam].Count; i++)
            {
                tema.Items.Add(tantargyTemak[listSorSzam][i]);
            }

        }

        private void tema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int listTemaSorszam = tema.SelectedIndex;

        }

        private void tesztInditasa_Click(object sender, RoutedEventArgs e)
        {

            kvizOldal.Visibility = Visibility.Visible;

        }
        private void UjraIndit()
        {
            Pontszama = 0;
            kSzam = -1;
            i = 0;
            KvizStart();
        }
        private void Kerdesek()
        {
            if (kSzam < kerdesSzama.Count)
            {
                i = kerdesSzama[kSzam];
            }
            else
            {
                UjraIndit();
            }

            switch (i)
            {
                case 1:

                    kerdesSzovege.Text = "Mi a feszültség jele?";
                    valasz1.Content = "V";
                    valasz2.Content = "U";
                    valasz3.Content = "I";
                    valasz4.Content = "R";

                    valasz2.Tag = "1";

                    break;

                case 2:

                    kerdesSzovege.Text = "Mi a feszültség mértékegysége?";

                    valasz1.Content = "V";
                    valasz2.Content = "A";
                    valasz3.Content = "F";
                    valasz4.Content = "U";

                    valasz1.Tag = "1";

                    break;

                case 3:

                    kerdesSzovege.Text = "Mi az áramerősség jele?";

                    valasz1.Content = "U";
                    valasz2.Content = "A";
                    valasz3.Content = "I";
                    valasz4.Content = "R";

                    valasz3.Tag = "1";

                    break;

                case 4:

                    kerdesSzovege.Text = "Mi az ellenállás jele?";

                    valasz1.Content = "I";
                    valasz2.Content = "V";
                    valasz3.Content = "Ω";
                    valasz4.Content = "R";

                    valasz4.Tag = "1";

                    break;

                case 5:

                    kerdesSzovege.Text = "Ohm törvénye melyik két mennyiség között állapít meg összefüggést?";

                    valasz1.Content = "feszültség, áramerősség";
                    valasz2.Content = "feszültség, ellenállás";
                    valasz3.Content = "áramerősség, ellenállás";
                    valasz4.Content = "egyik sem";

                    valasz1.Tag = "1";

                    break;

                case 6:

                    kerdesSzovege.Text = "Ohm törvénye értelmében az adott fogyasztón mért feszültség és áramerősség:";

                    valasz1.Content = "párhuzamos";
                    valasz2.Content = "fordítottan arányos";
                    valasz3.Content = "egyenesen arányos";
                    valasz4.Content = "egyenlő;";

                    valasz3.Tag = "1";

                    break;

                case 7:

                    kerdesSzovege.Text = "Mekkora az ellenállás, ha 20 V a feszültség és 10 A az áramerősség?";

                    valasz1.Content = "20 Ω";
                    valasz2.Content = "2 Ω";
                    valasz3.Content = "0,5 Ω";
                    valasz4.Content = "200 Ω";

                    valasz2.Tag = "1";

                    break;

                case 8:

                    kerdesSzovege.Text = "Mi a töltés jele?";

                    valasz1.Content = "C";
                    valasz2.Content = "T";
                    valasz3.Content = "R";
                    valasz4.Content = "Q";

                    valasz4.Tag = "1";

                    break;

                case 9:

                    kerdesSzovege.Text = "Mekkora a feszültség ha az ellenállás 20 Ω és 10 A az áramerősség?";

                    valasz1.Content = "2 V";
                    valasz2.Content = "0,5 V";
                    valasz3.Content = "200 V";
                    valasz4.Content = "20 V";

                    valasz3.Tag = "1";

                    break;

                case 10:

                    kerdesSzovege.Text = "Melyiket nevezzük fogyasztónak?";

                    valasz1.Content = "izzólámpa";
                    valasz2.Content = "párhuzamos kapcsolás";
                    valasz3.Content = "amper";
                    valasz4.Content = "elektroszkóp";

                    valasz1.Tag = "1";

                    break;
            }
        }

        private void KvizStart()
        {
            var randomList = kerdesSzama.OrderBy(a => Guid.NewGuid()).ToList();

            kerdesSzama = randomList;

            kerdesSorrend.Content = null;

            for (int i = 0; i < kerdesSzama.Count; i++)
            {
                kerdesSorrend.Content += " " + kerdesSzama[i].ToString();
            }
        }

        private void valaszokEllenorzese(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (senderButton.Tag.ToString() == "1")
            {
                Pontszama++;
            }
            if (kSzam < 0)
            {
                kSzam = 0;
            }
            else
            {
                kSzam++;
            }
            if (kSzam > 9)
            {
                valasz1.IsEnabled = false;
                valasz2.IsEnabled = false;
                valasz3.IsEnabled = false;
                valasz4.IsEnabled = false;
            }

            pontszam.Content = "Helyes válaszok száma: " + Pontszama + "/" + kerdesSzama.Count;
            Kerdesek();
            
        }

        private void kiertekeles_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A tantárgyi kvíz véget ért az ön számára. " + pontszam.Content);
            kvizOldal.Visibility = Visibility.Hidden;
            foOldal.Visibility = Visibility.Visible;
            valasz1.IsEnabled = true;
            valasz2.IsEnabled = true;
            valasz3.IsEnabled = true;
            valasz4.IsEnabled = true;
            UjraIndit();
        }

        private void elozo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kovetkezo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

