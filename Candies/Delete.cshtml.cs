using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;

namespace CandyShop.Pages.Candies
{
    public class DeleteModel : PageModel
    {
        private readonly CandyShop.Data.ApplicationDbContext _context;

        public DeleteModel(CandyShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candy Candy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candy = await _context.Candy
                .Include(c => c.Manufacturers)
                .Include(c => c.Stores).FirstOrDefaultAsync(m => m.CandyId == id);

            if (Candy == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candy = await _context.Candy.FindAsync(id);

            if (Candy != null)
            {
                _context.Candy.Remove(Candy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
