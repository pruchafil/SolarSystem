
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SmallPlanets : ContentPage {
		public SmallPlanets() {
			InitializeComponent();

			Objects.SmallPlanet.Init();
			lv.ItemsSource = Objects.SmallPlanet.GetCollection();
			lv.ItemSelected += async (sender, e) => {
				Objects.SmallPlanet obj = (Objects.SmallPlanet)lv.SelectedItem;
				await Navigation.PushModalAsync
				(
					new AddPage
					(
						new[] {
							new AddPage.Entry("Jméno", false, false, 30, obj.Name),
							new AddPage.Entry("Poloměr (km)", false, true, 30, obj.Radius.ToString()),
							new AddPage.Entry("Informace", true, false, 1000, obj.About)
						},
						(x) => {
							Objects.SmallPlanet.AddItem(new Objects.SmallPlanet() { Name = x[0], Radius = double.Parse(x[1]), About = x[2] });
							Objects.SmallPlanet.RemoveItem((Objects.SmallPlanet)lv.SelectedItem);
							lv.ItemsSource = Objects.SmallPlanet.GetCollection();
						},
						() => {
							Objects.SmallPlanet.RemoveItem(obj);
							lv.ItemsSource = Objects.SmallPlanet.GetCollection();
						}
					)
				);
			};
		}

		private async void ImageButton_Clicked(object sender, System.EventArgs e) =>
			await Navigation.PushModalAsync
			(
				new AddPage
				(
					new[] {
						new AddPage.Entry("Jméno", false, false, 30, string.Empty),
						new AddPage.Entry("Poloměr (km)", false, true, 30, string.Empty),
						new AddPage.Entry("Informace", true, false, 1000, string.Empty)
					},
					(x) => Objects.SmallPlanet.AddItem(new Objects.SmallPlanet() { Name = x[0], Radius = double.Parse(x[1]), About = x[2] })
				)
			);
	}
}