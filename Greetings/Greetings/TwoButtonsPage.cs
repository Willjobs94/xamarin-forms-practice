using System;

using Xamarin.Forms;

namespace Greetings
{
	public class TwoButtonsPage : ContentPage
	{
		Button addButton;
		Button removeButton;
		StackLayout loggerLayout = new StackLayout();

		public TwoButtonsPage()
		{
			addButton = new Button
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Text = "Add"
			};

			addButton.Clicked += OnButtonClicked;

			removeButton = new Button
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Text = "Remove",
				IsEnabled = false
			};

			removeButton.Clicked += OnButtonClicked;

			Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

			Content = new StackLayout
			{
				Children =
				{
					new StackLayout 
					{
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							addButton, 
							removeButton
						}
					},

					new ScrollView
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Content = loggerLayout
					}
				}
			};
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			if (button == addButton)
			{
				loggerLayout.Children.Add(new Label
				{
					HorizontalOptions = LayoutOptions.Center,
					Text = string.Format("Clicked at {0}", DateTime.Now.ToString("T"))
				});
			}
			else 
			{
				loggerLayout.Children.RemoveAt(0);
			}

			removeButton.IsEnabled = loggerLayout.Children.Count > 0;
		}
}
}

