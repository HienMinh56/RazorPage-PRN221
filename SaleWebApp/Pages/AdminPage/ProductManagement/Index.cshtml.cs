using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccess;
using DataAccess.Repository.IRepository;

namespace SaleWebApp.Pages.AdminPage.ProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository = null;

        public IndexModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_productRepository.GetAllProducts != null)
            {
                Product = _productRepository.GetAllProducts();
            }
        }
        public async Task<IActionResult> OnPostAsync(string SearchKeyword, int SearchCriteria)
        {
            if (!string.IsNullOrEmpty(SearchKeyword))
            {
                Product = _productRepository.SearchProduct(SearchKeyword, SearchCriteria).ToList();
            }
            else
            {
                Product = _productRepository.GetAllProducts();
            }

            return Page();
        }
    }
}
