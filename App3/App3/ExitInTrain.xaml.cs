using System;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExitInTrain : PopupPage
    {
        public ExitInTrain()
        {
            InitializeComponent();
            No.Clicked += (s, e) =>
            {
                Navigation.PopAllPopupAsync();
            };
            Yes.Clicked += Yes_Clicked;
        }

        private void Yes_Clicked(object sender, EventArgs e) // using async/await is not correct
        {
         Navigation.PushModalAsync(new MainPage2(),false);
         Navigation.PopModalAsync(false);
         Navigation.PopPopupAsync(false);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}