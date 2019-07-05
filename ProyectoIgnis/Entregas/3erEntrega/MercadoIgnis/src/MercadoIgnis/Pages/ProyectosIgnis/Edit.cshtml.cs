using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
using static MercadoIgnis.Models.ProyectoIgnis;
//Patron Expert
//Patron Creator
//EditModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectoIgnis -por lo que EditModel es un experto conrespecto a crear ProyectoIgnis-.
namespace MercadoIgnis.Pages.ProyectosIgnis
{
    //Edit Model: en esta pagina de Proyetos Ignis, edita las mismas
    public class EditModel : PageModel
    {
        private readonly IdentityContext _context;

        public EditModel(IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProyectoIgnis ProyectoIgnis { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ProyectosEstado = new List<SelectListItem>();

            ProyectosEstado.Add(new SelectListItem
            {
                Value = ((int)EnumEstadoProyecto.EnSeleccion).ToString(),
                Text = EnumEstadoProyecto.EnSeleccion.ToString()
            });
            ProyectosEstado.Add(new SelectListItem
            {
                Value = ((int)EnumEstadoProyecto.EnProceso).ToString(),
                Text = EnumEstadoProyecto.EnProceso.ToString()
            });
            ProyectosEstado.Add(new SelectListItem
            {
                Value = ((int)EnumEstadoProyecto.Finalizado).ToString(),
                Text = EnumEstadoProyecto.Finalizado.ToString()
            });
            ProyectosEstado.Add(new SelectListItem
            {
                Value = ((int)EnumEstadoProyecto.Cancelado).ToString(),
                Text = EnumEstadoProyecto.Cancelado.ToString()
            });
            if (id == null)
            {
                return NotFound();
            }

            ProyectoIgnis = await _context.ProyectoIgnis.FirstOrDefaultAsync(m => m.ID == id);

            if (ProyectoIgnis == null)
            {
                return NotFound();
            }
            return Page();
        }
        public EnumEstadoProyecto Estado { get; set; }
        public List<SelectListItem> ProyectosEstado { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProyectoIgnis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoIgnisExists(ProyectoIgnis.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProyectoIgnisExists(int id)
        {
            return _context.ProyectoIgnis.Any(e => e.ID == id);
        }
    }
}
