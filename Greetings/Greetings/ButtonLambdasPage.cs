using System;
using Xamarin.Forms;

namespace Greetings
{
	public class ButtonLambdasPage : ContentPage
	{
		public ButtonLambdasPage()
		{
			double number = 1;
			var label = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = number.ToString(),
				FontSize = Device.GetNamedSize(NamedSize.Large, this)
			};

			var timesButton = new Button
			{
				Text = "Double",
				FontSize = Device.GetNamedSize(NamedSize.Large, this),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			timesButton.Clicked += (sender, e) =>
			{
				number *= 2;
				label.Text = number.ToString();
			};

			var devideButton = new Button
			{
				Text = "Devide",
				FontSize = Device.GetNamedSize(NamedSize.Large, this),
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			devideButton.Clicked += (sender, e) => 
			{
				number /= 2;
				label.Text = number.ToString();
			};

			Content = new StackLayout
			{
				Children = 
				{
					label, 
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Children = 
						{
							timesButton, 
							devideButton
						}
					}
				}
			};
		}
	}
}
