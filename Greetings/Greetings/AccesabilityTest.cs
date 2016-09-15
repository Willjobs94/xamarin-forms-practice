using System;

using Xamarin.Forms;

namespace Greetings
{
	public class AccesabilityTest : ContentPage
	{
		Label testLabel;
		Label displayLabel;
		public AccesabilityTest()
		{
			testLabel = new Label
			{
				Text = "Font Size of 20",
				FontSize = 20,
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			displayLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};

			testLabel.SizeChanged += OnTestLabelSizeChanged;

			Content = new StackLayout
			{
				Children =
				{
					testLabel,
					displayLabel
				}
			};

		}

		void OnTestLabelSizeChanged(object sender, EventArgs e)
		{
			displayLabel.Text = string.Format("{0:F0} \u00D7 {1:F0}", testLabel.Width, testLabel.Height);	
		}
}
}

