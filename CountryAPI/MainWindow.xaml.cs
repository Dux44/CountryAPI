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
using System.Collections.ObjectModel;

namespace CountryAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Country> countries = new ObservableCollection<Country>();
        CountryService countryService = new CountryService();
        DataBase dataBase = new DataBase();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void b_createNewCountry_Click(object sender, RoutedEventArgs e)
        {
            string text = tb_WriteCountry.Text;
            Country newcountry = await countryService.GetCountryByName(text);
            dataBase.AddCountry(newcountry);
            countries.Add(newcountry);
            dataGrid_Coutry.ItemsSource = countries;
            //валідація та обробка та API додавання до бази і показ на dataGrid
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            countries = dataBase.GetCountryList();
            dataGrid_Coutry.ItemsSource = countries;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //dont know yet if it really needed
        }
    }
}