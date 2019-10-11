using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyShop.Data;

namespace CandyShop.Pages.Candies
{
    public class CreateModel : PageModel
    {
        private readonly CandyShop.Data.ApplicationDbContext _context;

        public CreateModel(CandyShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MID"] = new SelectList(_context.Manufacturer, "MID", "MID");
        ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId");
            return Page();
        }

        [BindProperty]
        public Candy Candy { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candy.Add(Candy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}