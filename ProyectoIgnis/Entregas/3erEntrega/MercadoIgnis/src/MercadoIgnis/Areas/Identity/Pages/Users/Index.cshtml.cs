using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace MercadoIgnis.Areas.Identity.Pages.Users
{
    [Authorize(Roles = IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class IndexModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get; set; }

        public async Task OnGetAsync()
        {
            // Filtra el administador para que no aparezca en la lista
            var users = from m in _context.Users
                        select m;

            ApplicationUser = await users.ToListAsync();
        }
    }
}
