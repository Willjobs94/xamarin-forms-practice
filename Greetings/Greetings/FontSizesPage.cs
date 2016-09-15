using System;
using System.Reflection;

using Xamarin.Forms;

namespace Greetings
{
	public class FontSizesPage : ContentPage
	{
		public FontSizesPage()
		{
			BackgroundColor = Color.White;
			var stackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			NamedSize[] namedSizes =
			{
				NamedSize.Default, NamedSize.Micro, NamedSize.Small, NamedSize.Medium, NamedSize.Large
			};
			foreach (NamedSize namedSize in namedSizes)
			{
				double fontSize = Device.GetNamedSize(namedSize, typeof(Label));
				stackLayout.Children.Add(new Label
				{
					Text = string.Format("Named Size = {0} ({1:F2})", namedSize, fontSize),
					FontSize = fontSize,
					TextColor = Color.Black
				});
			}

			var resolution = 160;

			stackLayout.Children.Add(
				new BoxView
				{
					Color = Color.Accent,
					HeightRequest = resolution / 80
				}
			);

			int[] ptSizes = { 4, 6, 8, 10, 12 };

			foreach (var ptSize in ptSizes)
			{
				double fontSize = resolution * ptSize / 72;
				stackLayout.Children.Add(new Label
				{
					Text = string.Format("Point Size = {0} ({1:F2})", ptSize, fontSize),
					FontSize = fontSize,
					TextColor = Color.Black
				});
			}

			Content = stackLayout;
		}
	}
}

