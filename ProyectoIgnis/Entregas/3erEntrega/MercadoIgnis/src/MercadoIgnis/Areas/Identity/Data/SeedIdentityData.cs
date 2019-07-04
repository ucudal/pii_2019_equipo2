using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MercadoIgnis.Models;


namespace MercadoIgnis.Areas.Identity.Data
{
    /// <summary>
    /// Inicializa en la base de datos de identidad los usuarios y roles necesarios para el funcionamiento de la aplicaci�n
    /// la primera vez que se ejecuta.
    /// </summary>
    public static class SeedIdentityData
    {
        
        /// <summary>
        /// Crea los usuarios y roles necesarios para el funcionamiento de la aplicaci�n si ya no existente.
        /// </summary>
        /// <param name="serviceProvider">El <see cref="IServiceProvider"/> al que se han injectado previamente un
        /// <see cref="UserManager<T>"/> y un <see cref="RoleManager<T>"/>.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void CrearUsuario(UserManager<ApplicationUser> userManager, string name, string userName, System.DateTime dob, string role, string password)
        {
            // Crea el primer y único administrador si no existe. Primero crea un usuario y luego se asigna el rol de adminstrador.
            if (userManager.FindByNameAsync(userName).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = name;
                user.UserName = userName;
                user.Email = userName;
                user.DOB = dob;
                // Es necesario tener acceso a RoleManager para poder buscar el rol de este usuario; se asigna aquí para poder
                // buscar por rol después cuando no hay acceso a RoleManager.
                user.AssignRole(userManager, role);

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    IdentityResult addRoleResult = userManager.AddToRoleAsync(user, role).Result;
                    if (!addRoleResult.Succeeded)
                    {
                        throw new InvalidOperationException(
                            $"Unexpected error ocurred adding role '{role}' to user '{name}'.");
                    }
                     if (role == IdentityData.ClienteRoleName) //Cliente
                    {
                        
                        var cliente = new Cliente
                        {
                            ApplicationUserId = user.Id
                           
                        };
                        
                        ContextoSingleton.Instance.Contexto.Cliente.Add(cliente);
                        
                        
                        ContextoSingleton.Instance.Contexto.SaveChanges();

                    }
                    else if (role == IdentityData.TecnicoRoleName) //Tecnico
                    {
                        
                        var tecnico = new Tecnico
                        {
                            ApplicationUserId = user.Id
                           
                        };
                        
                        ContextoSingleton.Instance.Contexto.Tecnico.Add(tecnico);
                        
                        
                        ContextoSingleton.Instance.Contexto.SaveChanges();

                    }
                    else
                    {
                        //Throw exception
                    }




                }
                else
                {
                    throw new InvalidOperationException($"Unexpected error ocurred creating user '{name}'.");
                }
            
            
            
            }
            
                   
            


        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
           
            //Creamos el admin
            CrearUsuario(userManager,IdentityData.AdminName, IdentityData.AdminUserName, IdentityData.AdminDOB, IdentityData.AdminRoleName, IdentityData.AdminPassword);
            //Creamos Tecnicos
            CrearUsuario(userManager,"Tecnico 1", "Tecnico1@ignis.com" , new System.DateTime().AddYears(1990).AddMonths(5).AddDays(8), IdentityData.TecnicoRoleName,IdentityData.AdminPassword);
            CrearUsuario(userManager,"Tecnico 2", "Tecnico2@ignis.com" , new System.DateTime().AddYears(1972).AddMonths(1).AddDays(27), IdentityData.TecnicoRoleName,IdentityData.AdminPassword);
            CrearUsuario(userManager,"Tecnico 3", "Tecnico3@ignis.com" , new System.DateTime().AddYears(1979).AddMonths(10).AddDays(21), IdentityData.TecnicoRoleName,IdentityData.AdminPassword);
            //Creamos Clientes
            CrearUsuario(userManager,"Cliente 1", "Cliente1@ignis.com" , new System.DateTime().AddYears(1998).AddMonths(4).AddDays(2), IdentityData.ClienteRoleName,IdentityData.AdminPassword);
            CrearUsuario(userManager,"Cliente 2", "Cliente2@ignis.com" , new System.DateTime().AddYears(1975).AddMonths(2).AddDays(15), IdentityData.ClienteRoleName,IdentityData.AdminPassword);
            CrearUsuario(userManager,"Cliente 3", "Cliente3@ignis.com" , new System.DateTime().AddYears(1960).AddMonths(6).AddDays(7), IdentityData.ClienteRoleName,IdentityData.AdminPassword);



        }

        private static void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            // Crea un rol si no existe.
            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                IdentityRole role = new IdentityRole(roleName);
                IdentityResult createRoleResult = roleManager.CreateAsync(role).Result;
                if (!createRoleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error ocurred creating role '{role}'.");
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Crea el rol de administrador si no existe
            CreateRole(roleManager, IdentityData.AdminRoleName);

            foreach (var roleName in IdentityData.NonAdminRoleNames)
            {
                CreateRole(roleManager, roleName);
            }
        }
    }
}