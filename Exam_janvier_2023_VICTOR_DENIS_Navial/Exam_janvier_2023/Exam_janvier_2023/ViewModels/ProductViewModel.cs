using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Exam_janvier_2023.Models;
using WpfApplication1.ViewModels;

namespace Exam_janvier_2023.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private NorthwindContext _context;
        private Product _selectedProduct;
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<dynamic> ProductCountsByCountry { get; set; }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public ICommand RemoveProductCommand { get; }

        public ProductViewModel()
        {
            _context = new NorthwindContext();
            LoadProducts();
            LoadProductCountsByCountry();
            RemoveProductCommand = new DelegateCommand(RemoveSelectedProduct);
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>(_context.Products.Where(p => !p.Discontinued).ToList());
            OnPropertyChanged(nameof(Products));
        }

        private void RemoveSelectedProduct()
        {
            if (SelectedProduct != null)
            {
                SelectedProduct.Discontinued = true;
                _context.SaveChanges();
                LoadProducts();
            }
        }

        private void LoadProductCountsByCountry()
        {
            var productCounts = _context.Products
                .Where(p => p.OrderDetails.Any())
                .GroupBy(p => p.Supplier.Country)
                .Select(g => new
                {
                    Country = g.Key,
                    Count = g.Count()
                }).OrderByDescending(g => g.Count).ToList();

            ProductCountsByCountry = new ObservableCollection<dynamic>(productCounts);
            OnPropertyChanged(nameof(ProductCountsByCountry));
        }
    }
}
