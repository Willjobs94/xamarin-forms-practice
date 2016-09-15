using System;

using Xamarin.Forms;

namespace Greetings
{
	public class WhatSize : ContentPage
	{
		Label label;

		public WhatSize()
		{
			label = new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Large, this),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			Content = label;

			SizeChanged += OnPageSizeChanged;
		}

		void OnPageSizeChanged(object sender, EventArgs e)
		{
			label.Text = string.Format("{0} \u00D7 {1}", Width, Height);
		}
	}
}

