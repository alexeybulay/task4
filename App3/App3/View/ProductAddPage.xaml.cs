using System;
using App7.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductAddPage : ContentPage
    {
        private DateTime dateTime;
        public ProductAddPage()
        {
            InitializeComponent();
            dateTime = DateTime.Now;
            dataLabel.Text = dateTime.ToString("f");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ProductAddViewModel();
        }
    }
}