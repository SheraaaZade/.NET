using Examen_janvier_2023.Models;

namespace Examen_janvier_2023.ViewModel
{
    internal class ProductModel
    {
        private readonly Product _monProduct;

        public ProductModel(Product current)
        {
            this._monProduct = current;
        }


        public Product MonProduct
        {
            get { return _monProduct; }
        }

        public int ProductId
        {
            get { return this._monProduct.ProductId; }
            set { _monProduct.ProductId = value; }
        }

        public string ProductName
        {
            get { return this._monProduct.ProductName; }
            set { this._monProduct.ProductName = value; }
        }

        public string? Categorie
        {
            get { return this._monProduct.Category.CategoryName; }
            set { _monProduct.Category.CategoryName = value; }
        }

        public string? Fournisseur
        {
            get { return this._monProduct.Supplier.ContactName; }
            set { this._monProduct.Supplier.ContactName = value; }
        }


    }
}
