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

namespace MercadoIgnis.Pages.Puestos
{
    public class CreateModel : PageModel
    {
        //Create Model: en esta pagina de Puestos, crea los mismos
        private readonly IdentityContext _context;

        public CreateModel(IdentityContext context)
        {
            _context = context;
        }
        public int ID{get;set;}

        public IActionResult OnGet(int id)
        {
            ID=id;
            ViewData["EspecialidadID"] = new SelectList(_context.Especialidad, "ID", "Area");
           
            return Page();
        }


        [BindProperty]
        public Puesto Puesto { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Puesto.ProyectoIgnisID = id;
            Console.WriteLine($"El valor de id onpost:{Puesto.ProyectoIgnisID}");
            _context.Puesto.Add(Puesto);
            await _context.SaveChangesAsync();

            return RedirectToPage("../ProyectosIgnis/Index",new{id=Puesto.ProyectoIgnisID});
        }
    }
}