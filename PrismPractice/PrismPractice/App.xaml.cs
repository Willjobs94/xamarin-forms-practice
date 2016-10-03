using Prism.Unity;
using PrismPractice.Views;

namespace PrismPractice
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
		}
	}
}
