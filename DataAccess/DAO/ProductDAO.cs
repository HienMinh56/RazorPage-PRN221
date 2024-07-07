using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        private readonly SaleManagerContext _context = null;
        private ProductDAO _instance = null;
        public  ProductDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductDAO();
                }
                return _instance;
            }
        }
        public ProductDAO()
        {
            _context = new SaleManagerContext();
        }

        public List<Product> GetAllProducts() => _context.Products.ToList();
        public Product GetProductById(int id) => _context.Products.SingleOrDefault(p => p.ProductId == id);
        public void AddProduct(Product product)
        {
            try
            {
                using (var saleManagement = new SaleManagerContext())
                {
                    Product p = saleManagement.Products.FirstOrDefault(item => item.ProductName.Equals(product.ProductName));
                    if (p == null)
                    {
                        // Generate new productId
                        int maxProductId = saleManagement.Products.Max(item => (int?)item.ProductId) ?? 0;
                        product.ProductId = maxProductId + 1;

                        saleManagement.Products.Add(product);
                        saleManagement.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The product already exists");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateProduct(Product product)
        {
            Product existingProduct = GetProductById(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.Weight = product.Weight;
                existingProduct.UnitsInStock = product.UnitsInStock;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        public IEnumerable<Product> SearchProduct(string searchTerm, int searchCriteria)
        {
            searchTerm = searchTerm.ToLower();
            switch (searchCriteria)
            {
                case 0: // Product ID
                    return _context.Products.Where(p => p.ProductId.ToString().ToLower().Contains(searchTerm));
                case 1: // Product Name
                    return _context.Products.Where(p => p.ProductName.ToLower().Contains(searchTerm));
                case 2: // Unit Price (assume string conversion for search)
                    return _context.Products.Where(p => p.UnitPrice.ToString().ToLower().Contains(searchTerm));
                case 3: // Units In Stock
                    return _context.Products.Where(p => p.UnitsInStock.ToString().ToLower().Contains(searchTerm));
                default:
                    return _context.Products.AsEnumerable();
            }
        }
    }
}
