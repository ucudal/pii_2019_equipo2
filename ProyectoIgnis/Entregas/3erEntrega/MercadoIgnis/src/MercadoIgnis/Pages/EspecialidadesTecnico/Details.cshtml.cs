using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.EspecialidadesTecnico
{
    public class DetailsModel : PageModel
    {
        //Details Model: en esta pagina de Especialidades de tecnicos, ve los detalles las mismas
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public EspecialidadesTecnicos EspecialidadesTecnicos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EspecialidadesTecnicos = await _context.EspecialidadesTecnicos
                .Include(e => e.Especialidad)
                .Include(e => e.Tecnico).FirstOrDefaultAsync(m => m.ID == id);

            if (EspecialidadesTecnicos == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
