using System;

using Xamarin.Forms;

namespace Greetings
{
	public class SimpleKeypad : ContentPage
	{
		Label displayLabel;
		Button backspaceButton;

		public SimpleKeypad()
		{
			var mainStack = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			displayLabel = new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Large, this),
				VerticalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.End
			};

			mainStack.Children.Add(displayLabel);

			backspaceButton = new Button
			{
				Text = "\u21E6",
				FontSize = Device.GetNamedSize(NamedSize.Large, this),
				IsEnabled = false
			};

			backspaceButton.Clicked += OnBackSpaceButtonClicked;

			mainStack.Children.Add(backspaceButton);

			StackLayout rowStack = null;

			for (int i = 1; i <= 10; i++)
			{
				if ((i - 1) % 3 == 0)
				{
					rowStack = new StackLayout
					{
						Orientation = StackOrientation.Horizontal
					};

					mainStack.Children.Add(rowStack);
				}

				var digitButton = new Button
				{
					Text = (i % 10).ToString(),
					StyleId = (i % 10).ToString(),
					FontSize = Device.GetNamedSize(NamedSize.Large, this)
				};

				digitButton.Clicked += OnDigitButtonClicked;

				if (i == 10)
				{
					digitButton.HorizontalOptions = LayoutOptions.FillAndExpand;
				}

				rowStack.Children.Add(digitButton);
			}

			Content = mainStack;

		}

		void OnBackSpaceButtonClicked(object sender, EventArgs e)
		{
			string text = displayLabel.Text;
			displayLabel.Text = text.Substring(0, text.Length - 1);
			backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
		}

		void OnDigitButtonClicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			displayLabel.Text += button.StyleId;
			backspaceButton.IsEnabled = true;


		}
	}
}

