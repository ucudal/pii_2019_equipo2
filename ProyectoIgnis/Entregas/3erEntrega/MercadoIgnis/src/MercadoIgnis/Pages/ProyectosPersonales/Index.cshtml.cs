using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static MercadoIgnis.Models.ProyectoPersonal;

namespace MercadoIgnis.Pages.ProyectosPersonales
{
    public class IndexModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
        public IList<ProyectoPersonal> ProyectoPersonal { get; set; }
        [BindProperty(SupportsGet = true)]

        public string busquedaPorTipo { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Tipo { get; set; }
        [BindProperty(SupportsGet = true)]

        public string FechadeComienzo { get; set; }
        public EnumTipoProyectoPersonal Tipos { get; set; }

        public async Task OnGetAsync()
        {
            // // Use LINQ to get list of Proyectos Personales.
            IQueryable<string> TipoQuery = from m in _context.ProyectoPersonal
                                            orderby m.Tipos.ToString()
                                            select m.Tipos.ToString();

            ProyectoPersonal = await _context.ProyectoPersonal.ToListAsync();

            var ProyectosPersonales = from m in _context.ProyectoPersonal
                                      select m;

            //Si Recibo algo no nulo del campo de texto
            if (!string.IsNullOrEmpty(busquedaPorTipo))
            {
                ProyectosPersonales = ProyectosPersonales.Where(s => s.Tipos.ToString().Contains(busquedaPorTipo));
            }
            DateTime date;
            //Si recibo algo no nulo del option box con los niveles
            if (!string.IsNullOrEmpty(FechadeComienzo))
            {
                if (DateTime.TryParse(FechadeComienzo, out date))
                {
                    ProyectosPersonales = ProyectosPersonales.Where(x => x.FechaComienzo >= DateTime.Parse(FechadeComienzo));
                }

            }
            Tipo = new SelectList(await TipoQuery.Distinct().ToListAsync());
            ProyectoPersonal = await ProyectosPersonales.ToListAsync();

        }
    }
}
