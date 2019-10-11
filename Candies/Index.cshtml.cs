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
    public class IndexModel : PageModel
    {
        private readonly CandyShop.Data.ApplicationDbContext _context;

        public IndexModel(CandyShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Candy> Candy { get;set; }

        public async Task OnGetAsync()
        {
            Candy = await _context.Candy
                .Include(c => c.Manufacturers)
                .Include(c => c.Stores).ToListAsync();
        
        }
    }
}
