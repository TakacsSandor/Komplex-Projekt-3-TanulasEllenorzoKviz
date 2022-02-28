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
        public MainWindow()
        {
            InitializeComponent();
            Beolvasas();
            EgyedikEloAllitasa();
            ListBoxFeltolteseTantargyNevekkel();

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
            foOldal.Visibility = Visibility.Hidden;

        }


        private void KerdesekLegeneralasa()
        {
            Random rnd = new Random();
        }
    }
}
