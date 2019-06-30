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
    public class IndexModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<EspecialidadesTecnicos> EspecialidadesTecnicos { get;set; }

        public async Task OnGetAsync()
        {
            if(User.IsInRole("Técnico"))
            {
                //Si soy tecnico muestro solo mis Especialidades
                EspecialidadesTecnicos = await _context.EspecialidadesTecnicos
                    .Include(e => e.Especialidad)
                    .Include(e => e.Tecnico)
                    .Where(t=>t.TecnicoID==ContextoSingleton.Instance.userManager.GetUserId(User))
                    .ToListAsync();
            }
            else if(User.IsInRole("Administrador"))
            {
                //Si soy administrador muestro todos los tecnicos con sus especialidades
                EspecialidadesTecnicos = await _context.EspecialidadesTecnicos
                    .Include(e => e.Especialidad)
                    .Include(e => e.Tecnico)                    
                    .ToListAsync();
            }else
            {
                //Throw Exception
            }
        }
    }
}
