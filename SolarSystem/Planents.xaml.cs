using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class Planents : ContentPage {

		public Planents() {
			InitializeComponent();

			Objects.Planet.Init();
			lv.ItemsSource = Objects.Planet.GetCollection();
			lv.ItemSelected += async (sender, e) => {
				Objects.Planet obj = (Objects.Planet)lv.SelectedItem;
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
							Objects.Planet.AddItem(new Objects.Planet() { Name = x[0], Radius = double.Parse(x[1]), About = x[2] });
							Objects.Planet.RemoveItem((Objects.Planet)lv.SelectedItem);
							lv.ItemsSource = Objects.Planet.GetCollection();
						},
						() => {
							Objects.Planet.RemoveItem(obj);
							lv.ItemsSource = Objects.Planet.GetCollection();
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
					(x) => Objects.Planet.AddItem(new Objects.Planet() { Name = x[0], Radius = double.Parse(x[1]), About = x[2] })
				)
			);
	}
}