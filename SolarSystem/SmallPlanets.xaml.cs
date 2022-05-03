
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SmallPlanets : ContentPage {
		public SmallPlanets() {
			InitializeComponent();
			lv.ItemsSource = Objects.SmallPlanet.GetCollection();
		}
	}
}