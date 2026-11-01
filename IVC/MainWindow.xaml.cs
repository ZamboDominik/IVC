using System.Globalization;
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

namespace IVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class BoolToVisibilityConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool logikaiErtek)
            {
                
                return logikaiErtek ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility lathatosag)
            {
                return lathatosag == Visibility.Visible;
            }
            return false;
        }

    }

    //Ez egy példa a cultureinfora
    public class ArKonverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double ar)
            {
                // A "C" (Currency = Pénznem) formázókód a 'culture' alapján 
                // teszi ki a Ft, $ vagy € jelet és a megfelelő tizedesvesszőt/pontot!
                return ar.ToString("C", culture);
            }
            return "0";
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string beirtSzoveg)
            {
                // A TryParse a 'culture' alapján tudja, hogy a "12,5" vagy a "12.5" a helyes szám,
                // és még a pénznem szimbólumot (NumberStyles.Currency) is le tudja vágni róla.
                if (double.TryParse(beirtSzoveg, NumberStyles.Currency, culture, out double eredmeny))
                {
                    return eredmeny;
                }
            }
            return 0.0;
        }
    }
}