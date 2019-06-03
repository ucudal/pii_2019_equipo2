using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;

namespace MercadoIgnis.Areas.Identity.Pages.MercadoIgnisUsers
{
    public class EditModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext _context;

        public EditModel(MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MercadoIgnisUser MercadoIgnisUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MercadoIgnisUser = await _context.MercadoIgnisUser.FirstOrDefaultAsync(m => m.Id == id);

            if (MercadoIgnisUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MercadoIgnisUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MercadoIgnisUserExists(MercadoIgnisUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MercadoIgnisUserExists(string id)
        {
            return _context.MercadoIgnisUser.Any(e => e.Id == id);
        }
    }
}
