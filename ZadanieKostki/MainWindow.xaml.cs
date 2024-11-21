using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZadanieKostki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Ogolnywynik = 0;
        public MainWindow()
        {
            InitializeComponent();
            UpdateIlosckostekText();
            UpdateIloscscianText();
        }

        private void Ilosckostek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => UpdateIlosckostekText();
        private void Iloscscian_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateIloscscianText();
        }
        private void UpdateIlosckostekText()
        {
            IlosckostekText.Text = $"{(int)Ilosckostek.Value}";
        }
        private void UpdateIloscscianText()
        {
            IloscscianText.Text = $"{(int)Iloscscian.Value}";
        }
     
        private int zaawansowanywynik(int[] rzut)
        {
            var wszystkierzuty = rzut.GroupBy(x => x).Where(g => g.Count() >= 2);
            return wszystkierzuty.Sum(g => g.Key * g.Count());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int kostki = (int)Ilosckostek.Value;
            int sciany = (int)Iloscscian.Value;
            int[] rzut = new int[kostki];

            // Rzucanie kostkami
            for (int i = 0; i
        < kostki; i++)
            {
                rzut[i] = rand.Next(1, sciany + 1);
            }

            // Obliczanie wyników
            int sumaoczek = rzut.Sum();
            string pokazwynik = $"Wynik rzutu: {sumaoczek}\n" + "Wyniki kostek: " + string.Join(", ", rzut);

            // Obliczanie wyników zaawansowanych
            int parzystewynik = zaawansowanywynik(rzut);

            pokazwynik += $"\nSuma wszystkich oczek: {sumaoczek}";
            pokazwynik += $"\nZaawansowane liczenie (dwa lub więcej razy): {parzystewynik}";

            // Dodanie wyniku do ogólnego
            Ogolnywynik += sumaoczek;

            // Wyświetlenie wyników w TextBoxie
            pokazwyniki.Text = pokazwynik;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ogolnywynik = 0;
            pokazwyniki.Text = $"Wynik ogólny zresetowany.\n";
        }
    }
}