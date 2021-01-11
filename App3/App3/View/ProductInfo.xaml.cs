using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App7.ViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductInfo : ContentPage
    {
        private readonly int productID;
        public ProductInfo(int productID)
        {
            InitializeComponent();
            this.productID = productID;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ProductInfoViewModel(productID);
        }
    }
}