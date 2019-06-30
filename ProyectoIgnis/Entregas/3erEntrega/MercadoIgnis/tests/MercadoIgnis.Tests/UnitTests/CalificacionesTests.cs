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
using MercadoIgnis.Pages.Calificaciones; //Para usar la clase CreateModel/DeleteModel/EditModel de Calificaciones
using Microsoft.Extensions.DependencyInjection;
using MercadoIgnis.Areas.Identity.Data;


namespace MercadoIgnis.Tests.UnitTests
{
    public class CalificacionesTests
    {

        [Fact]
        public async Task OnPostCreateCalificaciones_VerSiRealmenteCrea()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<IdentityContext>()
                .UseInMemoryDatabase("InMemoryDb");

            IdentityContext TestIdentityContext = new IdentityContext(OptionsBuilder.Options);

            //Creamos una calificacion esperada
            Calificacion CalificacionEsperada = new Calificacion() { ID = 1, Nota = 5, Descripcion = "Descripcion de prueba" };

            // Act
            //Creamos una pagina de tipo CreateModel (de Calificaciones), la cual es la que se encarga de la logica 
            //de crear calificaciones en bd.
            CreateModel PageCreateModel = new CreateModel(TestIdentityContext);


            //Introducimos una calificacion en el modelo de la pagina que creamos, a mano Seteamos los valores de 
            //la calificacion de esa página
            PageCreateModel.Calificacion = new Calificacion() { ID = 1, Nota = 5, Descripcion = "Descripcion de prueba" };


            //Simulamos un post que envíe el formulario de la pagina y por ende guarde en bd la calificacion que ingresamos en esa pagina
            await PageCreateModel.OnPostAsync();

            // Assert
            //Buscamos usando el contexto la Calificacion recien creada por id
            Calificacion CalificacionRecibida = await TestIdentityContext.Calificacion.FindAsync(1);

            //Comparamos que la que creamos en el modelo de la pagina y por ende mandamos a crear en bd, 
            //y la calificacion que recibimos de bd con id 1, tengan igual descripcion y nota
            Assert.Equal(
                CalificacionEsperada.Descripcion.ToString(),
                CalificacionRecibida.Descripcion.ToString());
            Assert.Equal(
               CalificacionEsperada.Nota.ToString(),
               CalificacionRecibida.Nota.ToString());

            //Si esto no falla, concluimos que la pagina de calificaciones (de tener bien seteado el modelo), 
            //guarda sin problemas una calificacion en bd cuando no hay nada ingresado   


        }


        [Fact]
        public async Task OnPostDeleteCalificaciones_VerSiRealmenteBorra()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<IdentityContext>()
                .UseInMemoryDatabase("InMemoryDb");

            IdentityContext TestIdentityContext = new IdentityContext(OptionsBuilder.Options);
            Calificacion Calificacion = new Calificacion() { ID = 1, Nota = 5, Descripcion = "Descripcion de prueba" };

            //Guardamos una calificacion en bd
            TestIdentityContext.Calificacion.Add(Calificacion);
            await TestIdentityContext.SaveChangesAsync();


            // Act
            //Creamos una pagina de tipo DeleteModel (de Calificaciones), la cual es la que se encarga de la logica 
            //de borrar calificaciones en bd.
            DeleteModel pageDeleteModel = new DeleteModel(TestIdentityContext);

            //Simulamos un post que envíe el formulario de la pagina y por ende borre en bd la calificacion que ingresamos en bd anteriormente
            await pageDeleteModel.OnPostAsync(Calificacion.ID);

            // Assert
            //Buscamos si aún esta en bd la calificacion que debió haber sido borrada por la pagina
            Calificacion CalificacionRecibida = await TestIdentityContext.Calificacion.FindAsync(Calificacion.ID);


            Assert.Null(CalificacionRecibida);
            //Si es Null significa que la pagina lo borro correctamente    


        }

        [Fact]
        public async Task OnPostEditCalificaciones_VerSiRealmenteEdita()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<IdentityContext>()
                .UseInMemoryDatabase("InMemoryDb");

            IdentityContext TestIdentityContext = new IdentityContext(OptionsBuilder.Options);
            Calificacion Calificacion = new Calificacion() { ID = 2, Nota = 5, Descripcion = "Descripcion de prueba" };

            //Guardamos una calificacion en bd
            TestIdentityContext.Calificacion.Add(Calificacion);
            TestIdentityContext.SaveChanges();

            //Creo una instancia de Calificacion para comparar más adelante
            Calificacion CalificacionEsperada = new Calificacion() { ID = 2, Nota = 1, Descripcion = "Nueva Descripcion" };

            // Act
            //Creamos una pagina de tipo EditModel (de Calificaciones), la cual es la que se encarga de la logica 
            //de editar calificaciones en bd. 
            EditModel PageEditModel = new EditModel(TestIdentityContext);

            //Simulamos haber hecho el edit en una calificaion con el id
            await PageEditModel.OnGetAsync(Calificacion.ID);

            //Modificamos los valores de los atributos de la instancia "calificacion" de Calificacion
            PageEditModel.Calificacion.Descripcion = CalificacionEsperada.Descripcion;
            PageEditModel.Calificacion.Nota = CalificacionEsperada.Nota;

            //Simulamos un post que envíe el formulario de la pagina y por ende guarda los cambios de la edicion
            await PageEditModel.OnPostAsync();

            // Assert
            //Buscamos si aún esta en bd la calificacion que debió haber sido editada por la pagina
            Calificacion CalificacionRecibida = await TestIdentityContext.Calificacion.FindAsync(Calificacion.ID);


            Assert.Equal(
                CalificacionEsperada.Descripcion.ToString(),
                CalificacionRecibida.Descripcion.ToString());
            Assert.Equal(
               CalificacionEsperada.Nota.ToString(),
               CalificacionRecibida.Nota.ToString());
            //Si se ejecuta correctamente, significa que el programa modifica correctamente calificaciones  


        }


    }
}