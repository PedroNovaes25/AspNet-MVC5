using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly); // Define qual conjunto contém os controladores do meu aplicativo = (Global) (MvcApplication = Nome da classe do Global)
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly); // Define qual conjunto contém os controladores do meu aplicativo = (Global) (MvcApplication = Nome da classe do Global)
            builder.RegisterType<InMemoryRestaurantData>() //Registra um 'tipo especifico' <InMemoryRestaurantData>
                .As<IRestaurantData>() // Toda as vezes que for solicitado um objeto que implemente <IRestaurantData>, a classe definida como tipo será usada
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);  //Configuração da API


        }
    }
}