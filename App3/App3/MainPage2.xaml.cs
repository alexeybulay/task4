using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage2 : TabbedPage
    {
        public MainPage2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override bool OnBackButtonPressed()
        {
            //Android.OS.Process.KillProcess(Android.OS.Process.MyPid()); // Full output of application.
            return base.OnBackButtonPressed();
        }
    }
}