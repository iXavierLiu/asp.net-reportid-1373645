using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Report
{
    // see https://learn.microsoft.com/zh-cn/dotnet/api/microsoft.aspnetcore.mvc.razor.iviewlocationexpander?view=aspnetcore-7.0
    public class NamespaceViewLocationExpander : IViewLocationExpander
    {
        private readonly string _placeholder;
        private readonly IEnumerable<string> _viewLocations;
        public NamespaceViewLocationExpander(IEnumerable<string> viewLocations, string placeholder)
        {
            _placeholder = placeholder;
            _viewLocations = viewLocations;
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            List<string> namespaceViewLocation = new List<string>();

            var actionDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
            // controller namespace
            var controllerNamespace = actionDescriptor?.ControllerTypeInfo.Namespace;
            // assembly Name
            var assemblyName = actionDescriptor?.ControllerTypeInfo.Assembly.GetName().Name;


            if (controllerNamespace is null || assemblyName is null)
                return viewLocations;

            if (!controllerNamespace.StartsWith(assemblyName += ".Controllers.") || controllerNamespace == assemblyName)
                return viewLocations;

            var placeReplace = controllerNamespace[assemblyName.Length..].Replace(".", "/");

            foreach (var viewLocation in _viewLocations)
            {
                namespaceViewLocation.Add(viewLocation.Replace(_placeholder, placeReplace));
            }

            return namespaceViewLocation.Union(viewLocations);
        }

        // see https://stackoverflow.com/questions/36802661/what-is-iviewlocationexpander-populatevalues-for-in-asp-net-core-mvc
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["FindViewByNamespace"] = (context.ActionContext.ActionDescriptor as ControllerActionDescriptor)?.ControllerTypeInfo.Namespace;
        }
    }
}
