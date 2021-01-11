using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using App7.DataAccess;
using App7.Model;

namespace App7.ViewModel
{
    public class StandartProductInfoViewModel : INotifyPropertyChanged
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
            get => calloriesProduct = proteinProduct + fatsProduct + carbohydratesProduct;
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

        public StandartProductDbContext _standartProductDbContext { get; set; }
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get => products;
            set => products = value;
        }

        private readonly int _productId;

        public StandartProductInfoViewModel(int productId)
        {
            _productId = productId;
            _standartProductDbContext = new StandartProductDbContext();
            var product = _standartProductDbContext.Products.Find(productId);
            NameProduct = product.NameProduct;
            CalloriesProduct = product.CalloriesProduct;
            ProteinProduct = product.ProteinProduct;
            FatsProduct = product.FatsProduct;
            CarbohytratesProduct = product.CarbohytratesProduct;
            Products = new ObservableCollection<Product>(_standartProductDbContext.Products.Where(n => n.ProductId == productId));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
