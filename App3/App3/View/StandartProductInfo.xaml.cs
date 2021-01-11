using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App7.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StandartProductInfo : ContentPage
    {
        private readonly int productID;
        public StandartProductInfo(int productID)
        {
            InitializeComponent();
            this.productID = productID;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new StandartProductInfoViewModel(productID);
        }
    }
}