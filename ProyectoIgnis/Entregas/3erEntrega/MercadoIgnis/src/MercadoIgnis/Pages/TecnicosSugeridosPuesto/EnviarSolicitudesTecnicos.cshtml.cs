using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.TecnicosSugeridosPuesto
{
    public class EnviarSolicitudesTecnicosModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public EnviarSolicitudesTecnicosModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Puesto Puesto { get; set; }

        public IEnumerable<Tecnico> Tecnico { get; set; }

        public List<Tecnico> TodosTecnicos { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, int? idEsp)
        {
            if ((id == null) || (idEsp == null))
            {
                return NotFound();
            }

            // Retrieve the first Puesto with ID equal to received id. Include the appeareances of Tecnicos in that
            // Puesto. Then include the Tecnicos in the appearences of the Puesto.
            Puesto = await _context.Puesto
                .Where(m => m.ID == id)
                .Include(c => c.TecnicosSolicitudesPuesto)
                    .ThenInclude(a => a.Tecnico)
                    .ThenInclude(t => t.ApplicationUser)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (Puesto == null)
            {
                return NotFound();
            }

            // Populate the list of Tecnicos in the viewmodel with the Tecnicos of the Puesto.
            this.Tecnico = Puesto.TecnicosSolicitudesPuesto
                .Select(a => a.Tecnico);



            // Populate the list of all other Tecnicos with all Tecnicos not included in the Puesto's Tecnicos 
            var Tecnicos = await _context.Tecnico
                .Include(e => e.EspecialidadesTecnicos)
                .Include(t => t.ApplicationUser)
                .Where(a => !Tecnico.Contains(a))
                .ToListAsync();

            TodosTecnicos = new List<Tecnico>();
            foreach (Tecnico t in Tecnicos)
            {
                _context.TecnicoSugeridoPuesto.Where(s => s.TecnicoID == t.ID).Load();
                if (t.TecnicosSugeridoPuesto != null)
                {
                    foreach (TecnicoSugeridoPuesto s in t.TecnicosSugeridoPuesto)
                    {

                        if (s.PuestoID == id)
                        {
                            TodosTecnicos.Add(t);
                        }


                    }
                }

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var PuestoToUpdate = await _context.Puesto
                .Include(a => a.TecnicosSolicitudesPuesto)
                    .ThenInclude(a => a.Tecnico)
                .FirstOrDefaultAsync(m => m.ID == id);
            {

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoExists(Puesto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteTecnicoAsync(int id, int TecnicoToDeleteID)
        {
            Puesto PuestoToUpdate = await _context.Puesto
                .Include(a => a.TecnicosSolicitudesPuesto)
                    .ThenInclude(a => a.Tecnico)
                .FirstOrDefaultAsync(m => m.ID == id);

            await TryUpdateModelAsync<Puesto>(PuestoToUpdate);

            var TecnicoToDelete = PuestoToUpdate.TecnicosSolicitudesPuesto.Where(a => a.TecnicoID == TecnicoToDeleteID).FirstOrDefault();
            if (TecnicoToDelete != null)
            {
                PuestoToUpdate.TecnicosSolicitudesPuesto.Remove(TecnicoToDelete);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(Puesto.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ControlarCambioEstado(Puesto.ID);
            return Redirect(Request.Path + $"?id={id}");
        }

        public async Task<IActionResult> OnPostAddTecnicoAsync(int? id, int? TecnicoToAddID)
        {
            Puesto PuestoToUpdate = await _context.Puesto
                .Include(a => a.TecnicosSolicitudesPuesto)
                    .ThenInclude(a => a.Tecnico)
                .FirstOrDefaultAsync(m => m.ID == Puesto.ID);

            await TryUpdateModelAsync<Puesto>(PuestoToUpdate);


            if (TecnicoToAddID != null)
            {
                Tecnico TecnicoToAdd = await _context.Tecnico.Where(a => a.ID == TecnicoToAddID).FirstOrDefaultAsync();
                if (TecnicoToAdd != null)
                {

                    var appereanceToAdd = new TecnicoSolicitudPuesto()
                    {
                        TecnicoID = TecnicoToAddID.Value,
                        Tecnico = TecnicoToAdd,
                        PuestoID = PuestoToUpdate.ID,
                        Puesto = PuestoToUpdate
                    };
                    PuestoToUpdate.TecnicosSolicitudesPuesto.Add(appereanceToAdd);

                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(Puesto.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ControlarCambioEstado(Puesto.ID);
            return Redirect(Request.Path + $"?id={id}");
        }

        public async void ControlarCambioEstado(int id)
        {
            Puesto PuestoToUpdate = await _context.Puesto
               .Where(m => m.ID == id)
               .Include(c => c.TecnicosSolicitudesPuesto)
               .FirstOrDefaultAsync();
            if (PuestoToUpdate.TecnicosSolicitudesPuesto.Any())
            {
                PuestoToUpdate.Estado = Puesto.EnumEstadoPuesto.ALaEsperaDeConfirmacion;
            }
            else
            {
                PuestoToUpdate.Estado = Puesto.EnumEstadoPuesto.ConTecnicosSugeridos;
            }

            await _context.SaveChangesAsync();
        }

        private bool PuestoExists(int id)
        {
            return _context.Puesto.Any(e => e.ID == id);
        }

    }
}
