using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.RegularExpressions;

namespace Web.Conventions
{
    public class ControllerDocumentationConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var originalName = controller.ControllerName;

            var newName = Regex.Replace(originalName, "([a-z])([A-Z])", "$1-$2").ToLower();

            controller.ControllerName = newName;
        }
    }
}
