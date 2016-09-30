using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MonkeyTap
{
	public partial class MonkeyTapPage : ContentPage
	{
		const int sequenceTime = 750;
		protected int flashDuration = 250;

		const double offLuminosity = 0.4;
		const double onLuminosity = 0.75;
		BoxView[] boxViews;
		Color[] colors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };
		List<int> sequence = new List<int>();
		int sequenceIndex;
		bool awatingTaps;
		bool gameEnded;
		Random random = new Random();

		public MonkeyTapPage()
		{
			InitializeComponent();
			boxViews = new BoxView[] { boxView0, boxView1, boxView2, boxView3 };
			InitializeBoxViewColors();
		}

		void InitializeBoxViewColors()
		{
			for (var i = 0; i < 4; i++)
			{
				boxViews[i].Color = colors[i].WithLuminosity(offLuminosity);
			}
		}

		public void OnBoxViewTapped(object sender, EventArgs args)
		{
			if (gameEnded) return;
			if (!awatingTaps) 
			{
				EndGame();
				return;
			}

			var tappedBoxView = sender as BoxView;
			var index = Array.IndexOf(boxViews, tappedBoxView);

			if (index != sequence[sequenceIndex])
			{
				EndGame();
				return;
			}

			FlashBoxView(index);
			sequenceIndex++;
			awatingTaps = sequenceIndex < sequence.Count;
			if (!awatingTaps) StartSequence();
			    
		}

		void EndGame()
		{
			gameEnded = true;
			for (int i = 0; i < 4; i++)
			{
				boxViews[i].Color = Color.Gray;
			}

			startGameButton.Text = "Try Again";
			startGameButton.IsVisible = true;

		}

		public void OnStartButtonClicked(object sender, EventArgs args)
		{
			gameEnded = false;
			startGameButton.IsVisible = false;
			InitializeBoxViewColors();
			sequence.Clear();
			StartSequence();
		}

		void StartSequence()
		{
			sequence.Add(random.Next(4));
			sequenceIndex = 0;
			Device.StartTimer(TimeSpan.FromMilliseconds(1), OnTimerTick);
		}

		bool OnTimerTick()
		{
			if (gameEnded) return false;

			FlashBoxView(sequence[sequenceIndex]);
			sequenceIndex++;
			awatingTaps = sequenceIndex == sequence.Count;
			sequenceIndex = awatingTaps ? 0 : sequenceIndex;
			return !awatingTaps;
		}

		void FlashBoxView(int index)
		{
			boxViews[index].Color = colors[index].WithLuminosity(onLuminosity);
			Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
			{
				if (gameEnded) return false;

				boxViews[index].Color = colors[index].WithLuminosity(offLuminosity);
				return false;

			});

		}
	}
}
