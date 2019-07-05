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
//IndexModel tiene los datos que serán provistos al constructor para inicializar instancias de Calificacion -por lo que IndexModel es un experto conrespecto a crear Calificacion-.
namespace MercadoIgnis.Pages.Calificaciones
{
    public class IndexModel : PageModel
    {
        //Index Model: en esta pagina de Calificaciones, te carga la vista principal
        private readonly IdentityContext _context;

        public IndexModel(IdentityContext context)
        {
            _context = context;
        }

        public IList<Calificacion> Calificacion { get; set; }

        public async Task OnGetAsync()
        {
            Calificacion = await _context.Calificacion.ToListAsync();
        }
    }
}
