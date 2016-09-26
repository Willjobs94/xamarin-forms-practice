using Xamarin.Forms;
using System;
namespace XamlClock
{
	public partial class XamlClockPage : ContentPage
	{
		public XamlClockPage()
		{
			InitializeComponent();

			Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
		}

		bool OnTimerTick()
		{
			var dt = DateTime.Now;
			timeLabel.Text = dt.ToString("T");
			dateLabel.Text = dt.ToString("D");
			return true;
		}
}
}
