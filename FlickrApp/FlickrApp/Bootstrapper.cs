using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity.Mvc4;

namespace FlickrApp
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
        // Load the unity Config section defined in web.config
        var container = new UnityContainer().LoadConfiguration();

        // Registering Dependencies can be done via C# code as below instead of configs as well
        //var container = new UnityContainer();
        //container.RegisterType<IRepository, FlickrCacheableRepository>();
        //container.RegisterType<IRepository, FlickrRepository>();
        //container.RegisterType<IController, HomeController>("Home");

        return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}