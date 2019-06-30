using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
//Patron Expert
//Patron Creator
//CreateModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectoIgnis -por lo que CreateModel es un experto conrespecto a crear ProyectoIgnis-.
namespace MercadoIgnis.Pages.ProyectosIgnis
{
    public class CreateModel : PageModel
    {
        private readonly IdentityContext _context;

       

        public CreateModel(IdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
             
            return Page();
        }

        [BindProperty]
        public ProyectoIgnis ProyectoIgnis { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
             
        
            //Solo puede hacerse como cliente, manejar excepciones!
            _context.ProyectoIgnis.Add(ProyectoIgnis); //Agrego el proyectoignis nuevo
            _context.ProyectosIgnisClientes.Add(new ProyectosIgnisClientes(ContextoSingleton.Instance.userManager.GetUserId(User),ProyectoIgnis.ID)); //Agrego en la relación el cliente logueado, con el id del proyecto ignis recien creado
            await _context.SaveChangesAsync();//guardo en bd

            return RedirectToPage("./Index");
        }


        


    }
}