using Xamarin.Forms;
namespace App3
{
    public partial class App : Application
    {
        public const string NotificationReceivedKey = "NotificationReceived";
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SplashImage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
