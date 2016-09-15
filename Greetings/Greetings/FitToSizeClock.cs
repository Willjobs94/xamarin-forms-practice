using System;

using Xamarin.Forms;

namespace Greetings
{
	public class FitToSizeClock : ContentPage
	{
		Label clockLabel;
		public FitToSizeClock()
		{
			clockLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			Content = clockLabel;
			SizeChanged += OnSizeChanged;

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				clockLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
				return true;
			});
		}

		void OnSizeChanged(object sender, EventArgs e)
		{
			if (this.Width > 0)
			{
				clockLabel.FontSize = this.Width / 6;
			}

		}
	}
}

