using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanMyPham
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Payment Success", "{type}",
            new { controller = "Cart", action = "Success", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                            { "type", "hoan-thanh" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("Payment", "{type}",
            new { controller = "Cart", action = "Payment", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                            { "type", "thanh-toan" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("Cart", "{type}",
            new { controller = "Cart", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                            { "type", "gio-hang" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("Add Cart", "{type}",
            new { controller = "Cart", action = "AddItem", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                            { "type", "them-gio-hang" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("gioithieu", "{type}",
            new { controller = "Gioithieu", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                            { "type", "gioi-thieu" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("Detail_new", "{type}/{meta}/{id}",
            new { controller = "News", action = "Detail_new", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "tin-tuc" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("Contact", "{type}",
            new { controller = "Contact", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "lien-he" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("News", "{type}",
            new { controller = "News", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "tin-tuc" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("Product", "{type}/{meta}",
            new { controller = "Product", action = "Index", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "san-pham" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute("Detail", "{type}/{meta}/{id}",
            new { controller = "Product", action = "Detail", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "san-pham" }
            },
            namespaces: new[] { "WebBanMyPham.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } ,
                namespaces: new[] {"WebBanMyPham.Controllers"} 
            );
        }
    }
}
