using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO = null;
        public ProductRepository()
        {
            if (_productDAO == null)
            {
                _productDAO = new ProductDAO();
            }
        }

        public void AddProduct(Product product)
        {
            _productDAO.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productDAO.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productDAO.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productDAO.GetProductById(id);
        }

        public IEnumerable<Product> SearchProduct(string searchTerm, int searchCriteria)
        {
            return _productDAO.SearchProduct(searchTerm, searchCriteria);
        }

        public void UpdateProduct(Product product)
        {
            _productDAO.UpdateProduct(product);
        }
    }
}
