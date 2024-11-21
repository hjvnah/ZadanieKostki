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

        private void Ilosckostek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateIlosckostekText();
        }
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

    }
}