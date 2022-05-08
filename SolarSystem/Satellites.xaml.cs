
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Satellites : ContentPage {
		public Satellites() {
			InitializeComponent();

			Objects.Satellite.Init();
			lv.ItemsSource = Objects.SmallPlanet.GetCollection();
			lv.ItemSelected += async (sender, e) => {
				Objects.Satellite obj = (Objects.Satellite)lv.SelectedItem;
				await Navigation.PushModalAsync
				(
					new AddPage
					(
						new[] {
							new AddPage.Entry("Jméno", false, false, 30, obj.Name),
							new AddPage.Entry("Vznik", false, true, 30, obj.Creation),
							new AddPage.Entry("Informace", true, false, 1000, obj.About)
						},
						(x) => {
							Objects.Satellite.AddItem(new Objects.Satellite() { Name = x[0], Creation = x[1], About = x[2] });
							Objects.Satellite.RemoveItem((Objects.Satellite)lv.SelectedItem);
							lv.ItemsSource = Objects.SmallPlanet.GetCollection();
						},
						() => {
							Objects.Satellite.RemoveItem(obj);
							lv.ItemsSource = Objects.Satellite.GetCollection();
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
						new AddPage.Entry("Vznik", false, false, 30, string.Empty),
						new AddPage.Entry("Informace", true, false, 1000, string.Empty)
					},
					(x) => Objects.Satellite.AddItem(new Objects.Satellite() { Name = x[0], Creation = x[1], About = x[2] })
				)
			);
	}
}