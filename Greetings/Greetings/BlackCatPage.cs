using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace Greetings
{
	public class BlackCatPage : ContentPage
	{
		public BlackCatPage()
		{
			BackgroundColor = Color.White;
			Device.OnPlatform(iOS: () => Padding = new Thickness(0, 20, 0, 0));
			var mainStack = new StackLayout();
			var textStack = new StackLayout
			{
				Padding = new Thickness(5),
				Spacing = 10
			};

			var assembly = GetType().GetTypeInfo().Assembly;
			var resource = "Greetings.Texts.TheBlackCat.txt";

			using (var resourceStream = assembly.GetManifestResourceStream(resource))
			{
				using (var reader = new StreamReader(resourceStream))
				{
					var gotTitle = false;
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						var label = new Label
						{
							Text = line,
							TextColor = Color.Black
						};
						if (!gotTitle)
						{
							label.HorizontalOptions = LayoutOptions.Center;
							label.FontSize = Device.GetNamedSize(NamedSize.Medium, label);
							label.FontAttributes = FontAttributes.Bold;
							mainStack.Children.Add(label);
							gotTitle = true;
						}
						else
						{
							textStack.Children.Add(label);
						}
					}
				}
			}

			var scrollView = new ScrollView
			{
				Content = textStack,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5, 0)
			};

			mainStack.Children.Add(scrollView);
			Content = mainStack;
		}
	}
}

