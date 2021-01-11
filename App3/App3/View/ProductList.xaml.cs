using System.Linq;
using App7.Model;
using App7.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList : ContentPage
    {
        private ProductListViewModel productListViewModel;
        public ProductList()
        {
            InitializeComponent();
            listProduct.ItemTapped += ListProduct_ItemTapped;
            listProduct.ItemSelected += (s, e) => { ((ListView) s).SelectedItem = null; };
            searchProduct.TextChanged += SearchProduct_TextChanged;
        }

        private void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            productListViewModel = new ProductListViewModel();
            var keyword = searchProduct.Text;
            var suggestion =
                productListViewModel.Products.Where(c => c.NameProduct.ToLower().Contains(keyword.ToLower()));
            listProduct.ItemsSource = suggestion;
        }

        private async void ListProduct_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = (Product) e.Item;
            await Navigation.PushAsync(new ProductInfo(product.ProductId), true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ProductListViewModel();
            
        }
    }
}