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
    public class DetailsModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext _context;

        public DetailsModel(MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext context)
        {
            _context = context;
        }

        public MercadoIgnisUser MercadoIgnisUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MercadoIgnisUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (MercadoIgnisUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
