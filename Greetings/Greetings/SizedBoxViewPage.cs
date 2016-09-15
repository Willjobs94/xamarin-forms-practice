using System;
using Xamarin.Forms;

namespace Greetings
{
	public class SizedBoxViewPage : ContentPage
	{
		public SizedBoxViewPage()
		{
			BackgroundColor = Color.Pink;

			Content = new BoxView
			{
				BackgroundColor = Color.Accent,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				WidthRequest = 200,
				HeightRequest = 100
			};
		}
	}
}
