
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Others : ContentPage {
		public Others() {
			InitializeComponent();
			lv.ItemsSource = Objects.Other.GetCollection();
		}
	}
}