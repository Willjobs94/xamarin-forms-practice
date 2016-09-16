using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CodePlusXaml
{
	public partial class CodePlusXamlPage : ContentPage
	{
		public CodePlusXamlPage()
		{
			InitializeComponent();

			var label = new Label
			{
				Text = "Hello From code",
				TextColor = Color.Blue,
				FontSize = Device.GetNamedSize(NamedSize.Large, this),
				BackgroundColor = Color.FromHex("#FF8080"),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				Opacity = 0.75,
				FontAttributes = FontAttributes.Bold | FontAttributes.Italic
			};

			(Content as StackLayout).Children.Insert(0,label);
		}
	}
}
