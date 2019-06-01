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
    public class IndexModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext _context;

        public IndexModel(MercadoIgnis.Areas.Identity.Data.MercadoIgnisIdentityDbContext context)
        {
            _context = context;
        }

        public IList<MercadoIgnisUser> MercadoIgnisUser { get;set; }

        public async Task OnGetAsync()
        {
            MercadoIgnisUser = await _context.Users.ToListAsync();
        }
    }
}
