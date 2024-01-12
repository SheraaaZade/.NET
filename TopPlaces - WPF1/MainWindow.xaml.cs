using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TopPlaces;

namespace TopPlaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PlacesData placesData = new PlacesData();

            this.listBoxPhotos.DataContext = placesData.PlacesList;
        }

        private void listBoxPhotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
            BitmapSource photo = BitmapFrame.Create(new Uri(place.PathImageFile));
            image1.Source = photo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Place place = (Place)listBoxPhotos.SelectedItem;
            place.Vote();

        }
    }
}