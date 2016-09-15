using System;

using Xamarin.Forms;

namespace Greetings
{
	public class ButtonLogger : ContentPage
	{
		public ButtonLogger()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

