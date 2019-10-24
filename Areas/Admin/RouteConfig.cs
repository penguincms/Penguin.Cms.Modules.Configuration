using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Penguin.Web.Abstractions.Interfaces;

namespace Penguin.Cms.Modules.Configuration.Areas.Admin
{
    public class RouteConfig : IRouteConfig
    {
        //the throwaway values are because ASP.NET tried to route anything where the last section of the URL contained a period
        //to a static file. I havent double checked to see if ASP.NET core does the same thing. They might be vestigial
        public void RegisterRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                "Admin_Edit_Configuration",
                "Admin/Configuration/EditByName/{Name?}",
                new { area = "admin", controller = "Configuration", action = "EditByName", knowncontroller = "true" }

            );
        }
    }
}