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
using Xamarin.Forms;

namespace App7.ViewModel
{
    public class ProductAddViewModel : INotifyPropertyChanged
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

        public ProductDbContext _productDbContext { get; set; }
    
        public ICommand SaveProductCommand { get; set;}

        public ProductAddViewModel()
        {
            _productDbContext = new ProductDbContext();
            SaveProductCommand = new Command(SaveProduct);
            
        }

        private async void SaveProduct()
        {
            Product product = new Product
            {
                NameProduct = NameProduct,
                CalloriesProduct = CalloriesProduct,
                ProteinProduct = ProteinProduct,
                FatsProduct = FatsProduct,
                CarbohytratesProduct = CarbohytratesProduct
            };
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            await Application.Current.MainPage.Navigation.PopAsync();

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
