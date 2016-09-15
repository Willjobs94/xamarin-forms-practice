using System;
using Xamarin.Forms;

namespace Greetings
{
	public class FramedTextPage : ContentPage
	{
		public FramedTextPage()
		{

			Padding = new Thickness(20);
			BackgroundColor = Color.Aqua;
			Content = new Frame
			{
				OutlineColor = Color.Black,
				BackgroundColor = Color.Yellow,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Content = new Label
				{
					Text = "I'm a framed label",
					FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
					//HorizontalOptions = LayoutOptions.Center,
					//VerticalOptions = LayoutOptions.Center
				}
			};
		}
	}
}
