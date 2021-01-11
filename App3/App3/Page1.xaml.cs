using System;
using App3.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        public Page1()
        {
            InitializeComponent();
            allButton.Clicked += Button1_Clicked;
            grudandbicepsButton.Clicked += Button3_Clicked;
            pressButton.Clicked += Button4_Clicked;
            spinaandtricepsButton.Clicked += Button5_Clicked;
            nogiandplechiButton.Clicked += Button6_Clicked;
        }

        private async void Button6_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new TrainListPage(3));
        }

        private async void Button5_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainListPage(4));
        }

        private async void Button4_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainListPage(2));

        }

        private async void Button3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainListPage(1));

        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainListPage(0));
        }
    }
}