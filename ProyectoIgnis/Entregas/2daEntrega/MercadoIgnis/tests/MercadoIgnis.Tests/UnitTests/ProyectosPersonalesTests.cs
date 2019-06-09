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
using MercadoIgnis.Pages.ProyectosPersonales; //Para usar la clase CreateModel/DeleteModel/EditModel de ProyectosPersonales
using Microsoft.Extensions.DependencyInjection;


namespace MercadoIgnis.Tests.UnitTests
{
    public class ProyectosPersonalesTests
    {
            
        [Fact]
        public async Task OnPostCreateProyectosPersonales_VerSiRealmenteCrea()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<MercadoIgnisContext>()
                .UseInMemoryDatabase("InMemoryDb");
            
            MercadoIgnisContext TestMercadoIgnisContext = new MercadoIgnisContext(OptionsBuilder.Options);
            
            //Creamos un Proyecto Personal Esperado
            ProyectoPersonal ProyectoPersonalEsperado = new ProyectoPersonal(){ID=1,Descripcion="Book",FechaComienzo=DateTime.Parse("2019/02/12"), FechaFinalizacion= DateTime.Parse("2019/02/12"),TipoDeProyecto = "Foto"};
           
            // Act
            //Creamos una pagina de tipo CreateModel (de ProyectosPersonales), la cual es la que se encarga de la logica 
            //de crear Proyectos Personales en bd.
            CreateModel PageCreateModel = new CreateModel(TestMercadoIgnisContext);
                      
          
            //Introducimos un Proyecto Personal en el modelo de la pagina que creamos, a mano Seteamos los valores del 
            // Proyecto Personal de esa página
            PageCreateModel.ProyectoPersonal = new ProyectoPersonal(){ID=1,Descripcion="Book",FechaComienzo=DateTime.Parse("2019/02/12"), FechaFinalizacion= DateTime.Parse("2019/02/12"),TipoDeProyecto = "Foto"};
            
           
            //Simulamos un post que envíe el formulario de la pagina y por ende guarde en bd, el Proyecto Personal que ingresamos en esa pagina
            await PageCreateModel.OnPostAsync();

            // Assert
            //Buscamos usando el contexto del Proyecto Personal recien creada por id
            ProyectoPersonal ProyectoPersonalRecibida = await TestMercadoIgnisContext.ProyectoPersonal.FindAsync(1);
            
            //Comparamos que la que creamos en el modelo de la pagina y por ende mandamos a crear en bd, 
            //y el Proyecto Personal que recibimos de bd con id 1, tengan igual Descripcion, FechaComienzo, FechaFinalizada, Tipo de proyecto
            Assert.Equal(
                ProyectoPersonalEsperado.Descripcion.ToString(), 
                ProyectoPersonalRecibida.Descripcion.ToString());
             Assert.Equal(
                ProyectoPersonalEsperado.FechaComienzo.ToString(), 
                ProyectoPersonalRecibida.FechaComienzo.ToString());
            Assert.Equal(
                ProyectoPersonalEsperado.FechaFinalizacion.ToString(), 
                ProyectoPersonalRecibida.FechaFinalizacion.ToString());
            Assert.Equal(
                ProyectoPersonalEsperado.TipoDeProyecto.ToString(), 
                ProyectoPersonalRecibida.TipoDeProyecto.ToString());
            
            //Si esto no falla, concluimos que la pagina de Proyectos Personales (de tener bien seteado el modelo), 
            //guarda sin problemas un Proyecto Personal en bd cuando no hay nada ingresado   
        }


        [Fact]
        public async Task OnPostDeleteProyectosPersonales_VerSiRealmenteBorra()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<MercadoIgnisContext>()
                .UseInMemoryDatabase("InMemoryDb");
            
            MercadoIgnisContext TestMercadoIgnisContext = new MercadoIgnisContext(OptionsBuilder.Options);
            ProyectoPersonal ProyectoPersonal= new ProyectoPersonal(){ID=45,Descripcion="Book",FechaComienzo=DateTime.Parse("2019/02/12"), FechaFinalizacion= DateTime.Parse("2019/02/12"),TipoDeProyecto = "Foto"};
            
            //Guardamos un Proyecto Personal en bd
            TestMercadoIgnisContext.ProyectoPersonal.Add(ProyectoPersonal);
            await TestMercadoIgnisContext.SaveChangesAsync();
            
           
            // Act
            //Creamos una pagina de tipo DeleteModel (de Proyectos Personales), la cual es la que se encarga de la logica 
            //de borrar Proyectos Personales en bd.
            DeleteModel PageDeleteModel = new DeleteModel(TestMercadoIgnisContext);
         
            //Simulamos un post que envíe el formulario de la pagina y por ende borre en bd, el Proyecto Personal que ingresamos en bd anteriormente
            await PageDeleteModel.OnPostAsync(ProyectoPersonal.ID);

            // Assert
            //Buscamos si aún esta en bd el Proyecto Personal que debió haber sido borrada por la pagina
            ProyectoPersonal ProyectoPersonalRecibida = await TestMercadoIgnisContext.ProyectoPersonal.FindAsync(ProyectoPersonal.ID);
            
            
            Assert.Null(ProyectoPersonalRecibida);
            //Si es Null significa que la pagina lo borro correctamente    
         
           
        }

        [Fact]
        public async Task OnPostEditProyectosPersonales_VerSiRealmenteEdita()
        {
            // Arrange
            //Preparamos un contexto que guarde la base de datos en memoria ram.
            var OptionsBuilder = new DbContextOptionsBuilder<MercadoIgnisContext>()
                .UseInMemoryDatabase("InMemoryDb");
            
            MercadoIgnisContext TestMercadoIgnisContext = new MercadoIgnisContext(OptionsBuilder.Options);
            ProyectoPersonal ProyectoPersonal= new ProyectoPersonal(){ID=4,Descripcion="Book",FechaComienzo=DateTime.Parse("2019/02/12"), FechaFinalizacion= DateTime.Parse("2019/02/12"),TipoDeProyecto = "Foto"};
            
            //Guardamos un Proyecto Personal en bd
            TestMercadoIgnisContext.ProyectoPersonal.Add(ProyectoPersonal);
            TestMercadoIgnisContext.SaveChanges();
            
            //Creo una instancia de Proyecto Personal para comparar más adelante
            ProyectoPersonal ProyectoPersonalEsperado= new ProyectoPersonal(){ID=4,Descripcion="Camara",FechaComienzo=DateTime.Parse("2019/03/12"), FechaFinalizacion= DateTime.Parse("2019/04/12"),TipoDeProyecto = "camara"};
            
            // Act
            //Creamos una pagina de tipo EditModel (de Proyectos Personales), la cual es la que se encarga de la logica 
            //de editar Proyectos Personales en bd. 
            EditModel PageEditModel = new EditModel(TestMercadoIgnisContext);

            //Simulamos haber hecho el edit en un Proyectos Personales con el id
            await PageEditModel.OnGetAsync(ProyectoPersonal.ID);

            //Modificamos los valores de los atributos de la instancia "ProyectoPersonal" de Proyecto Personal
            PageEditModel.ProyectoPersonal.Descripcion=ProyectoPersonalEsperado.Descripcion;
            PageEditModel.ProyectoPersonal.FechaComienzo=ProyectoPersonalEsperado.FechaComienzo;
            PageEditModel.ProyectoPersonal.FechaFinalizacion= ProyectoPersonalEsperado.FechaFinalizacion;
            PageEditModel.ProyectoPersonal.TipoDeProyecto= ProyectoPersonalEsperado.TipoDeProyecto;
         
            //Simulamos un post que envíe el formulario de la pagina y por ende guarda los cambios de la edicion
            await PageEditModel.OnPostAsync();

            // Assert
            //Buscamos si aún esta en bd el Proyecto Personal que debió haber sido editada por la pagina
            ProyectoPersonal ProyectoPersonalRecibida = await TestMercadoIgnisContext.ProyectoPersonal.FindAsync(ProyectoPersonal.ID);
            
            
             Assert.Equal(
                ProyectoPersonalEsperado.Descripcion.ToString(), 
                ProyectoPersonalRecibida.Descripcion.ToString());
             Assert.Equal(
                ProyectoPersonalEsperado.FechaComienzo.ToString(), 
                ProyectoPersonalRecibida.FechaComienzo.ToString());
            Assert.Equal(
                ProyectoPersonalEsperado.FechaFinalizacion.ToString(), 
                ProyectoPersonalRecibida.FechaFinalizacion.ToString());
            Assert.Equal(
                ProyectoPersonalEsperado.TipoDeProyecto.ToString(), 
                ProyectoPersonalRecibida.TipoDeProyecto.ToString());
            //Si se ejecuta correctamente, significa que el programa modifica correctamente Proyectos Personales  

        }
    }
}