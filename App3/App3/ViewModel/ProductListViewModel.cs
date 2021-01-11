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
using App7.View;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace App7.ViewModel
{
    public class ProductListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Product> products { get; set; }

        public ObservableCollection<Product> Products
        {
            get => products;
            set => products = value;
        }

        public ProductDbContext _productDbContext { get; set; }
        public ICommand AddProductCommand { get; set; }

        public ProductListViewModel()
        {
            _productDbContext = new ProductDbContext();
            var teamlist = _productDbContext.Products.ToList();
            Products = new ObservableCollection<Product>(teamlist);
            AddProductCommand = new Command(
                async () => await Application.Current.MainPage.Navigation.PushAsync(new ProductAddPage())
            );
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
