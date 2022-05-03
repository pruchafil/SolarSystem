using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class Planents : ContentPage {

		public Planents() {
			InitializeComponent();
			lv.ItemsSource = Objects.Planet.GetCollection();
		}
	}
}