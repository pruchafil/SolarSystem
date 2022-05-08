using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolarSystem {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage {
		public AddPage(Entry[] fields, Action<string[]> construct, Action destruct = null) {
			InitializeComponent();

			System.Collections.Generic.List<Xamarin.Forms.Entry> entries = new System.Collections.Generic.List<Xamarin.Forms.Entry>();

			foreach (Entry item in fields) {
				entries.Add
				(
					new Xamarin.Forms.Entry() {
						Text = item.text,
						TextColor = Color.White,
						PlaceholderColor = Color.Gray,
						Placeholder = item.placeholder,
						Margin = new Thickness(10, 10, 10, 10),
						MaxLength = item.maxlength,
						Keyboard = item.isnumeric ? Keyboard.Numeric : Keyboard.Text
					}
				);

				sl.Children.Add(entries[entries.Count - 1]);
			}

			Button b = new Button {
				Text = "OK",
				TextColor = Color.White,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End,
				BorderColor = Color.White,
				BorderWidth = 1d,
				CornerRadius = 99
			};

			b.Clicked += async (sender, e) => {
				construct(entries.Select(x => x.Text).ToArray());
				await Navigation.PopModalAsync();
			};

			Grid gr = new Grid();
			gr.ColumnDefinitions.Add(new ColumnDefinition());
			gr.Children.Add(b);
			Grid.SetColumn(b, 0);

			if (destruct != null) {
				Button b1 = new Button {
					Text = "Smazat",
					TextColor = Color.White,
					BackgroundColor = Color.Transparent,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.End,
					BorderColor = Color.Red,
					BorderWidth = 1d,
					CornerRadius = 99
				};

				b1.Clicked += async (sender, e) => {
					destruct();
					await Navigation.PopModalAsync();
				};

				gr.ColumnDefinitions.Add(new ColumnDefinition());
				gr.Children.Add(b1);
				Grid.SetColumn(b, 1);
			}

			sl.Children.Add(gr);
		}

		public struct Entry {
			public string placeholder;
			public bool multiline, isnumeric;
			public int maxlength;
			public string text;

			public Entry(string placeholder, bool multiline, bool isnumeric, int maxlength, string text) {
				this.placeholder = placeholder;
				this.multiline = multiline;
				this.isnumeric = isnumeric;
				this.maxlength = maxlength;
				this.text = text;
			}
		}
	}
}