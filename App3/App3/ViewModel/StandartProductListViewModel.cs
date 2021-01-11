using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using App7.DataAccess;
using App7.Model;

namespace App7.ViewModel
{
    public class StandartProductListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StandartProductDbContext _standartProductDbContext { get; set; }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> _Products
        {
            get => _products;
            set => _products = value;
        }
        public StandartProductListViewModel()
        {
            _standartProductDbContext = new StandartProductDbContext();
            var productList = _standartProductDbContext.Products.ToList();
            _Products = new ObservableCollection<Product>(productList);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
