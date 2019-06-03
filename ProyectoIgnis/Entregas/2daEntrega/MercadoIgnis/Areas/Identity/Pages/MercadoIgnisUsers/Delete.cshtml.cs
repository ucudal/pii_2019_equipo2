using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;

namespace MercadoIgnis.Areas.Identity.Pages.MercadoIgnisUsers
{
    public class DeleteModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext _context;

        public DeleteModel(MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MercadoIgnisUser = await _context.MercadoIgnisUser.FindAsync(id);

            if (MercadoIgnisUser != null)
            {
                _context.MercadoIgnisUser.Remove(MercadoIgnisUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
