using System;

using Xamarin.Forms;

namespace Greetings
{
	public class ButtonLoggerPage : ContentPage
	{
		StackLayout loggerLayout;
		public ButtonLoggerPage()
		{
			loggerLayout = new StackLayout();

			var button = new Button
			{
				HorizontalOptions = LayoutOptions.Center,
				Text = "Log the click time"
			};

			button.Clicked += OnButtonClicked;

			Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

			Content = new StackLayout
			{
				Children =
				{
					button,
					new ScrollView
					{
						VerticalOptions = LayoutOptions.FillAndExpand,
						Content = loggerLayout
					}
				}
			};
		}


		void OnButtonClicked(object sender, EventArgs e)
		{
			loggerLayout.Children.Add(new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				Text = string.Format("Button clicked at {0}", DateTime.Now.ToString("T"))
		    });
		}
	}
}

