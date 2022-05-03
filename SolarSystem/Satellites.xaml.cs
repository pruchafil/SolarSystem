
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Satellites : ContentPage {
		public Satellites() {
			InitializeComponent();
			lv.ItemsSource = Objects.Satellite.GetCollection();
		}
	}
}