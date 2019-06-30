using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;
using static MercadoIgnis.Models.ProyectoPersonal;

namespace MercadoIgnis.Pages.ProyectosPersonales
{
    public class CreateModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public CreateModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public EnumTipoProyectoPersonal Tipos { get; set; }
        public List<SelectListItem> ProyectosTipos { get; set; }
        public void OnGet()
        {
            ProyectosTipos = new List<SelectListItem>();

            ProyectosTipos.Add(new SelectListItem
            {
                Value = ((int)EnumTipoProyectoPersonal.Freelance).ToString(),
                Text = EnumTipoProyectoPersonal.Freelance.ToString()
            });
            ProyectosTipos.Add(new SelectListItem
            {
                Value = ((int)EnumTipoProyectoPersonal.TrabajoDeClase).ToString(),
                Text = EnumTipoProyectoPersonal.TrabajoDeClase.ToString()
            });
            ProyectosTipos.Add(new SelectListItem
            {
                Value = ((int)EnumTipoProyectoPersonal.ProyectoDeFinDeCurso).ToString(),
                Text = EnumTipoProyectoPersonal.ProyectoDeFinDeCurso.ToString()
            });
            ProyectosTipos.Add(new SelectListItem
            {
                Value = ((int)EnumTipoProyectoPersonal.ProyectoDeGrado).ToString(),
                Text = EnumTipoProyectoPersonal.ProyectoDeGrado.ToString()
            });
            ProyectosTipos.Add(new SelectListItem
            {
                Value = ((int)EnumTipoProyectoPersonal.Hobby).ToString(),
                Text = EnumTipoProyectoPersonal.Hobby.ToString()
            });
        }

        [BindProperty]
        public ProyectoPersonal ProyectoPersonal { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProyectoPersonal.Add(ProyectoPersonal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}