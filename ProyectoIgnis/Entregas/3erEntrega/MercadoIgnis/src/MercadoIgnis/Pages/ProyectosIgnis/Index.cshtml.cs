using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
//Patron Expert
//Patron Creator
//IndexModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectoIgnis -por lo que IndexModel es un experto conrespecto a crear ProyectoIgnis-.
namespace MercadoIgnis.Pages.ProyectosIgnis
{
    public class IndexModel : PageModel
    {
        private readonly IdentityContext _context;

        public IndexModel(IdentityContext context)
        {
            _context = context;
        }

        public IList<ProyectoIgnis> ProyectoIgnis { get;set; }

        public async Task OnGetAsync()
        {
            ProyectoIgnis = await _context.ProyectoIgnis.ToListAsync();
        }
    }
}
