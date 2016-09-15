using System;
using System.Reflection;
using Xamarin.Forms;

namespace Greetings
{
	public class ReflectedColorPage : ContentPage
	{
		public ReflectedColorPage()
		{
			var stackLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Blue,
				HorizontalOptions = LayoutOptions.Start
			};

			Content = new ScrollView
			{
				Orientation = ScrollOrientation.Horizontal,
				BackgroundColor = Color.Red,
				Content = stackLayout
			};

			Padding = new Thickness(5, Device.OnPlatform(20, 10, 5), 5, 5);
			//Color fields
			foreach (var info in typeof(Color).GetRuntimeFields())
			{
				if (info.GetCustomAttribute<ObsoleteAttribute>() != null)
					continue;

				if (info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
				{
					stackLayout.Children.Add(CreateColorLabel((Color)info.GetValue(new { }), info.Name));
				}

			}


		}

		private Label CreateColorLabel(Color color, string name)
		{
			var backgroundColor = Color.Default;
			if (color != Color.Default)
			{
				double luminance = 0.30 * color.R + 0.59 * color.G + 0.11 * color.B;
				backgroundColor = luminance > 0.5 ? Color.Black : Color.White;
			}
			return new Label
			{
				//HorizontalOptions = LayoutOptions.Start,
				Text = name,
				TextColor = color,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				BackgroundColor = backgroundColor
			};
		}
	}
}
