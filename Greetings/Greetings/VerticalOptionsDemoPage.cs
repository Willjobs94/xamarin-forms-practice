using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Greetings
{
	public class VerticalOptionsDemoPage : ContentPage
	{
		public VerticalOptionsDemoPage()
		{
			StackLayout stackLayout = new StackLayout();
			Color[] colors = { Color.Yellow, Color.Blue };
			int flipFlopper = 0;

			IEnumerable<Label> labels = typeof(LayoutOptions).GetRuntimeFields()
			.Where(f => f.IsPublic && f.IsStatic).OrderBy(f => ((LayoutOptions)f.GetValue(new { })).Alignment)
			.Select(f => new Label
			{
				Text = "VerticalOptions - " + f.Name,
				VerticalOptions = (LayoutOptions)f.GetValue(null),
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				TextColor = colors[flipFlopper],
				BackgroundColor = colors[flipFlopper = 1 - flipFlopper]
			});

			foreach (var label in labels)
			{
				stackLayout.Children.Add(label);
			}

			Device.OnPlatform(iOS: () => Padding = new Thickness(0,20,0,0));

			Content = stackLayout;
		}	                                                          
	}
}
