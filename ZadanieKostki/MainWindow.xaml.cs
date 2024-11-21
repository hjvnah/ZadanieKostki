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
        private int Ogolnywynik = 0; //stworzenie zmiennej ogolnywynik odpowiadacej za ogolny wynik
        public MainWindow()
        {
            InitializeComponent();
            UpdateIlosckostekText(); //odwolanie sie do stworzonych funkcji ponizej
            UpdateIloscscianText(); //odwolanie sie do stworzonych funkcji ponizej
        } 

        private void Ilosckostek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => UpdateIlosckostekText(); //nie mam pojecia co tu sie zadziało, kliknelam cos co mialo to naprawic no i dziala
        private void Iloscscian_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) 
        {
            UpdateIloscscianText();
        }
        private void UpdateIlosckostekText() //funkcja która zassysa informacje na temat wybranej liczby kostek
        {
            IlosckostekText.Text = $"{(int)Ilosckostek.Value}";
        }
        private void UpdateIloscscianText() //funkcja która zassysa informacje na temat wybranej liczby scian
        {
            IloscscianText.Text = $"{(int)Iloscscian.Value}";
        }
     
        private int zaawansowanywynik(int[] rzut) //stworzenie funkcji która będzie obliczać punkty za powtarzające się te same liczby
        {
            var wszystkierzuty = rzut.GroupBy(x => x).Where(g => g.Count() >= 2);  
            return wszystkierzuty.Sum(g => g.Key * g.Count());
        }

        private void Button_Click(object sender, RoutedEventArgs e) //wykonanie rzutu po kliknięciu buttona
        {
            Random random = new Random(); //stworzenie zmiennej z randomową wylosowaną liczbą
            int kostki = (int)Ilosckostek.Value; //przypisanie zmiennej kostki wybraną ilość kostek
            int sciany = (int)Iloscscian.Value; //przypisanie zmiennej sciany wybraną ilosc scian
            int[] rzut = new int[kostki]; //stworzenie tablicy, która będzie trzymać informacje na temat ilosci oczek każdej wylosowanej kostki 

            // Rzucanie kostkami
            for (int i = 0; i  < kostki; i++)
            {
                rzut[i] = random.Next(1, sciany + 1); //dodanie ilosci oczek do tablicy
            }

            // Obliczanie wyników
            int sumaoczek = rzut.Sum(); //sumowanie wszystkich danych z tablicy
            string pokazwynik = $"Wynik rzutu: {sumaoczek}\n" + "Wyniki kostek: " + string.Join(", ", rzut); //wypisanie każdych wylosowanych ilości oczek po kolei

            // Obliczanie wyników zaawansowanych
            int parzystewynik = zaawansowanywynik(rzut); //odwolanie sie do funkcji odpowiadajacej za zliczanie tych samych wynikow

            pokazwynik += $"\nSuma wszystkich oczek: {sumaoczek}"; //wypisanie wyniku sumy oczek
            pokazwynik += $"\nKiedy te same oczka dwa lub więcej razy: {parzystewynik}"; //wypisanie wyniku parzystych kostek

            // Dodanie wyniku do ogólnego
            Ogolnywynik += sumaoczek;

            // Wyświetlenie wyników w TextBoxie
            pokazwyniki.Text = pokazwynik;
        }
        //WSPOMOGLAM SIE TROCHE INTERNETEM !!!

        private void Button_Click_1(object sender, RoutedEventArgs e) //zresetowanie wyniku po kliknięciu buttona
        {
            Ogolnywynik = 0; //resetowanie wyniku ogólnego na zero
            pokazwyniki.Text = $"Wynik ogólny zresetowany.\n"; //wyświetlenie informacji na temat zresetowania wyniku
        }
    }
}