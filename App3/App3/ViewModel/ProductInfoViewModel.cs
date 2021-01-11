using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using App7.DataAccess;
using App7.Model;
using Xamarin.Forms;

namespace App7.ViewModel
{
    public class ProductInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nameProduct;
        private int calloriesProduct;
        private int proteinProduct;
        private int fatsProduct;
        private int carbohydratesProduct;
        public string NameProduct
        {
            get => nameProduct;

            set
            {
                nameProduct = value;
                OnPropertyChanged();
            }
        }
        public int CalloriesProduct
        {
            get => calloriesProduct = (proteinProduct * 4) + (fatsProduct * 9) + (carbohydratesProduct * 4);
            private set
            {
                calloriesProduct = value;
                OnPropertyChanged();
            }
        }
        public int ProteinProduct
        {
            get => proteinProduct;
            set
            {
                proteinProduct = value;
                OnPropertyChanged();
            }
        }
        public int FatsProduct
        {
            get => fatsProduct;
            set
            {
                fatsProduct = value;
                OnPropertyChanged();
            }
        }
        public int CarbohytratesProduct
        {
            get => carbohydratesProduct;
            set
            {
                carbohydratesProduct = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get => products;
            set => products = value;
        }
        public ProductDbContext _productDbContext { get; set; }

        private readonly int _productId;
        public ICommand DeleteProductCommand { get; set; }

        public ProductInfoViewModel(int productId)
        {
            _productId = productId;
            _productDbContext = new ProductDbContext();
            var product = _productDbContext.Products.Find(productId);

            NameProduct = product.NameProduct;
            CalloriesProduct = product.CalloriesProduct;
            ProteinProduct = product.ProteinProduct;
            FatsProduct = product.FatsProduct;
            CarbohytratesProduct = product.CarbohytratesProduct;

            Products = new ObservableCollection<Product>(
                _productDbContext.Products.Where(n => n.ProductId == productId));
            DeleteProductCommand = new Command(Delete);
        }

        private async void Delete()
        {
            var deleteProduct = _productDbContext.Products.Find(_productId);
            _productDbContext.Products.Remove(deleteProduct);
            _productDbContext.SaveChanges();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
