
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Others : ContentPage {
		public Others() {
			InitializeComponent();

			Objects.Other.Init();
			lv.ItemsSource = Objects.Other.GetCollection();
			lv.ItemSelected += async (sender, e) => {
				Objects.Other obj = (Objects.Other)lv.SelectedItem;
				await Navigation.PushModalAsync
				(
					new AddPage
					(
						new[] {
							new AddPage.Entry("Jméno", false, false, 30, obj.Name),
							new AddPage.Entry("Informace", true, false, 1000, obj.About)
						},
						(x) => {
							Objects.Other.AddItem(new Objects.Other() { Name = x[0], About = x[1] });
							Objects.Other.RemoveItem((Objects.Other)lv.SelectedItem);
							lv.ItemsSource = Objects.SmallPlanet.GetCollection();
						},
						() => {
							Objects.Other.RemoveItem(obj);
							lv.ItemsSource = Objects.Other.GetCollection();
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
						new AddPage.Entry("Informace", true, false, 1000, string.Empty)
					},
					(x) => Objects.Other.AddItem(new Objects.Other() { Name = x[0], About = x[1] })
				)
			);
	}
}