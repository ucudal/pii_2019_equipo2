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
        //Index Model: en esta pagina de Especialidades de tecnicos, te carga la vista principal
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<EspecialidadesTecnicos> EspecialidadesTecnicos { get; set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Técnico"))
            {
                //Obtengo el id Tecnico usando el Id de logueo (ApplicationUserId)
                int IdTecnico = await new OperacionesUsuario().IdDeTecnicoConIdApplicationUser(ContextoSingleton.Instance.userManager.GetUserId(User));

                //Si soy tecnico muestro solo mis Especialidades
                EspecialidadesTecnicos = await _context.EspecialidadesTecnicos
                    .Include(e => e.Especialidad)
                    .Include(e => e.Tecnico)
                    .ThenInclude(a => a.ApplicationUser)
                    .Where(t => t.TecnicoID == IdTecnico)
                    .ToListAsync();



            }
            else if (User.IsInRole("Administrador"))
            {
                //Si soy administrador muestro todos los tecnicos con sus especialidades
                EspecialidadesTecnicos = await _context.EspecialidadesTecnicos
                   .Include(e => e.Especialidad)
                   .Include(e => e.Tecnico)
                   .ThenInclude(a => a.ApplicationUser)
                   .ToListAsync();
            }
            else
            {
                //Throw Exception
            }
        }
    }
}
