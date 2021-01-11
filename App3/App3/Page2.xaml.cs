using System;
using App7.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {

        public Page2()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            button2.Clicked += Button2_Clicked;
        }

        private async void Button2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedProductPage());
        }
    }

}