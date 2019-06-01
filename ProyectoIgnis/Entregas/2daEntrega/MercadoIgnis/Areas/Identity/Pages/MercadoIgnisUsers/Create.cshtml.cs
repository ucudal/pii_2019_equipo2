using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Areas.Identity.Data;

namespace MercadoIgnis.Areas.Identity.Pages.MercadoIgnisUsers
{
    public class CreateModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext _context;

        public CreateModel(MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MercadoIgnisUser MercadoIgnisUser { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MercadoIgnisUser.Add(MercadoIgnisUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}