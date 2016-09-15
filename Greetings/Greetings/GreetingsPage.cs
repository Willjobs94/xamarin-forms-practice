using Xamarin.Forms;

namespace Greetings
{
	public class GreetingsPage : ContentPage
	{
		public GreetingsPage()
		{
			Content = new Label
			{

				Text = "Greetings, from Xamarin.Forms",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Yellow,
				TextColor = Color.Blue

			};

			//Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
			Device.OnPlatform(iOS: () => Padding = new Thickness(0,20,0,0));
		}

	}
}
