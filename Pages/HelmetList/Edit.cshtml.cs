using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyHelmet.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuyHelmet.Pages.HelmetList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Helmet Helmet { get; set; }


        public async Task OnGet(int id)
        {
            Helmet = await _db.Helmet.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var HelmetFromDb = await _db.Helmet.FindAsync(Helmet.Id);
                HelmetFromDb.Name = Helmet.Name;
                HelmetFromDb.Brand = Helmet.Brand;
                HelmetFromDb.Refnumber = Helmet.Refnumber;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
