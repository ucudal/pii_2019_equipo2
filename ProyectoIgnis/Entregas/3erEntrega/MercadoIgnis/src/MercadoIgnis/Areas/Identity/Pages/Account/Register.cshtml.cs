using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Models;








namespace MercadoIgnis.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
               
        
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            this.RolesList = new List<SelectListItem>();
            for (int i = 0; i < IdentityData.NonAdminRoleNames.Length; i++)
            {
                this.RolesList.Add(new SelectListItem { Value = i.ToString(), Text = IdentityData.NonAdminRoleNames[i] });
            }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        [BindProperty]
        public int Role { get; set; }
        [BindProperty]
        public List<SelectListItem> RolesList { get; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime DOB { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            //public static string[] NonAdminRoleNames = new string[] { "Cliente", "Técnico" };
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
               
                var user = new ApplicationUser {
                    Name = Input.Name,
                    DOB = Input.DOB,
                    UserName = Input.Email,
                    Email = Input.Email,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                var roleToAdd = await _roleManager.FindByNameAsync(IdentityData.NonAdminRoleNames[this.Role]);
                _userManager.AddToRoleAsync(user, roleToAdd.Name).Wait();

                user.AssignRole(_userManager, roleToAdd.Name);

                await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //Creamos la relacion entre Cliente/Tecnico y el ApplicationUser con la data del usuario en funcion del rol
                    
                    if (Role == 0) //Cliente
                    {
                        
                        var cliente = new Cliente
                        {
                            ApplicationUserId = user.Id
                           
                        };
                        
                        ContextoSingleton.Instance.Contexto.Cliente.Add(cliente);
                        
                        
                        await ContextoSingleton.Instance.Contexto.SaveChangesAsync();

                    }
                    else if (Role == 1) //Tecnico
                    {
                        
                        var tecnico = new Tecnico
                        {
                            ApplicationUserId = user.Id
                           
                        };
                        
                        ContextoSingleton.Instance.Contexto.Tecnico.Add(tecnico);
                        
                        
                        await ContextoSingleton.Instance.Contexto.SaveChangesAsync();

                    }
                    else
                    {
                        //Throw exception
                    }


                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
