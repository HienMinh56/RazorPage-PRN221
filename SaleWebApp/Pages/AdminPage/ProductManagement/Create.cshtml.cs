using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAccess;
using DataAccess.Repository.IRepository;

namespace SaleWebApp.Pages.AdminPage.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public CreateModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _productRepository.GetAllProducts() == null || Product == null)
            {
                return Page();
            }

            _productRepository.AddProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}
