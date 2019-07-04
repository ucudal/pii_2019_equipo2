using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.TecnicoSolicitudesPuesto
{
    public class IndexModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<TecnicoSolicitudPuesto> TecnicoSolicitudPuesto { get;set; }

        public async Task OnGetAsync()
        {
            TecnicoSolicitudPuesto = await _context.TecnicoSolicitudPuesto
                .Include(t => t.Puesto)
                .Include(t => t.Tecnico).ToListAsync();
        }
    }
}
