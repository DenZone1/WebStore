
using System.Reflection;

using Microsoft.AspNetCore.Mvc.ApplicationModels;

using WebStore.Controllers;

namespace WebStore.Imfrastructure.Conventions;

public class TestConventions : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerName == "Home")
        {
           // controller.Actions.Add(new ActionModel(typeof(HomeController).GetMethod("TestMethod"), Array.Empty<object>));
        }
    }
}
