using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using MercadoIgnis.Models;
using MercadoIgnis.Pages.Especialidades; //Para usar la clase CreateModel/DeleteModel/EditModel de Especialidades
using Microsoft.Extensions.DependencyInjection;
using MercadoIgnis.Areas.Identity.Data;

namespace MercadoIgnis.Tests.UnitTests
{
    public class EspecialidadesTests
    {

        [Fact]
        public async Task OnPostCreateEspecialidades_VerSiRealmenteCrea()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<IdentityContext>()
                .UseInMemoryDatabase("InMemoryDb");

            IdentityContext TestIdentityContext = new IdentityContext(OptionsBuilder.Options);

            //Creamos una Especialidad esperada
            Especialidad EspecialidadEsperada = new Especialidad() { ID = 1, Area = "Foto Fija", Nivel = "Basico" };

            // Act
            //Creamos una pagina de tipo CreateModel (de Especialidades), la cual es la que se encarga de la logica 
            //de crear Especialidades en bd.
            CreateModel PageCreateModel = new CreateModel(TestIdentityContext);


            //Introducimos una Especialidad en el modelo de la pagina que creamos, a mano Seteamos los valores de 
            //la Especialidad de esa página
            PageCreateModel.Especialidad = new Especialidad() { ID = 1, Area = "Foto Fija", Nivel = "Basico" };


            //Simulamos un post que envíe el formulario de la pagina y por ende guarde en bd la Especialidad que ingresamos en esa pagina
            await PageCreateModel.OnPostAsync();

            // Assert
            //Buscamos usando el contexto la Especialidad recien creada por id
            Especialidad EspecialidadRecibida = await TestIdentityContext.Especialidad.FindAsync(1);

            //Comparamos que la que creamos en el modelo de la pagina y por ende mandamos a crear en bd, 
            //y la Especialidad que recibimos de bd con id 1, tengan igual Nivel y Area
            Assert.Equal(
                EspecialidadEsperada.Nivel.ToString(),
                EspecialidadRecibida.Nivel.ToString());
            Assert.Equal(
               EspecialidadEsperada.Area.ToString(),
               EspecialidadRecibida.Area.ToString());

            //Si esto no falla, concluimos que la pagina de Especialidades (de tener bien seteado el modelo), 
            //guarda sin problemas una Especialidad en bd cuando no hay nada ingresado   


        }


        [Fact]
        public async Task OnPostDeleteEspecialidades_VerSiRealmenteBorra()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<IdentityContext>()
                .UseInMemoryDatabase("InMemoryDb");

            IdentityContext TestIdentityContext = new IdentityContext(OptionsBuilder.Options);
            Especialidad Especialidad = new Especialidad() { ID = 1, Area = "Foto Fija", Nivel = "Basico" };

            //Guardamos una Especialidad en bd
            TestIdentityContext.Especialidad.Add(Especialidad);
            await TestIdentityContext.SaveChangesAsync();


            // Act
            //Creamos una pagina de tipo DeleteModel (de Especialidades), la cual es la que se encarga de la logica 
            //de borrar Especialidades en bd.
            DeleteModel PageDeleteModel = new DeleteModel(TestIdentityContext);

            //Simulamos un post que envíe el formulario de la pagina y por ende borre en bd la Especialidad que ingresamos en bd anteriormente
            await PageDeleteModel.OnPostAsync(Especialidad.ID);

            // Assert
            //Buscamos si aún esta en bd la Especialidad que debió haber sido borrada por la pagina
            Especialidad EspecialidadRecibida = await TestIdentityContext.Especialidad.FindAsync(Especialidad.ID);


            Assert.Null(EspecialidadRecibida);
            //Si es Null significa que la pagina lo borro correctamente    


        }

        [Fact]
        public async Task OnPostEditEspecialidades_VerSiRealmenteEdita()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<IdentityContext>()
                .UseInMemoryDatabase("InMemoryDb");

            IdentityContext TestIdentityContext = new IdentityContext(OptionsBuilder.Options);
            Especialidad Especialidad = new Especialidad() { ID = 2, Area = "Foto Fija", Nivel = "Basico" };

            //Guardamos una Especialidad en bd
            TestIdentityContext.Especialidad.Add(Especialidad);
            TestIdentityContext.SaveChanges();

            //Creo una instancia de Especialidad para comparar más adelante
            Especialidad EspecialidadEsperada = new Especialidad() { ID = 2, Area = "Animacion", Nivel = "Avanzado" };

            // Act
            //Creamos una pagina de tipo EditModel (de Especialidades), la cual es la que se encarga de la logica 
            //de editar Especialidades en bd. 
            EditModel PageEditModel = new EditModel(TestIdentityContext);

            //Simulamos haber hecho el edit en una especialidad con el id
            await PageEditModel.OnGetAsync(Especialidad.ID);

            //Modificamos los valores de los atributos de la instancia "Especialidad" de Especialidad
            PageEditModel.Especialidad.Nivel = EspecialidadEsperada.Nivel;
            PageEditModel.Especialidad.Area = EspecialidadEsperada.Area;

            //Simulamos un post que envíe el formulario de la pagina y por ende guarda los cambios de la edicion
            await PageEditModel.OnPostAsync();

            // Assert
            //Buscamos si aún esta en bd la Especialidad que debió haber sido editada por la pagina
            Especialidad EspecialidadRecibida = await TestIdentityContext.Especialidad.FindAsync(Especialidad.ID);


            Assert.Equal(
                EspecialidadEsperada.Nivel.ToString(),
                EspecialidadRecibida.Nivel.ToString());
            Assert.Equal(
               EspecialidadEsperada.Area.ToString(),
               EspecialidadRecibida.Area.ToString());
            //Si se ejecuta correctamente, significa que el programa modifica correctamente Especialidades  


        }


    }
}