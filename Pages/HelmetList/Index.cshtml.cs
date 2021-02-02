using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyHelmet.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BuyHelmet.Pages.HelmetList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Helmet> Helmets { get; set; }
        public async Task OnGet()
        {
            Helmets = await _db.Helmet.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var helmet = await _db.Helmet.FindAsync(id);
            if(helmet == null)
            {
                return NotFound();
            }
            _db.Helmet.Remove(helmet);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
