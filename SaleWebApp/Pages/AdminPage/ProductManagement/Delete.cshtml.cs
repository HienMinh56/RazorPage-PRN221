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
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DeleteModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _productRepository.GetAllProducts() == null)
            {
                return NotFound();
            }

            var product = _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _productRepository.GetAllProducts() == null)
            {
                return NotFound();
            }
            var product = _productRepository.GetProductById(id);

            if (product != null)
            {
                Product = product;
                _productRepository.DeleteProduct(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
