using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoUIApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace KendoUIApp1.API
{
    public class RouteController : ApiController
    {
        private LowTemperatureEntities db = new LowTemperatureEntities();

        [HttpGet]       
        public DataSourceResult Route_Get([System.Web.Http.ModelBinding.ModelBinder(
                        typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            return db.Route.ToDataSourceResult(request);
           
        }
        

        [HttpPost]
        public void Create(Route route)
        {
            var CreateLt = new Route
            {
                RouteID = route.RouteID,
                CustomerID = route.CustomerID,
                RouteName = route.RouteName,
                FixedPrice = route.FixedPrice,
                KgPrice = route.KgPrice,
                PalletPrice = route.PalletPrice,
            };
            db.Route.Add(CreateLt);
            db.SaveChanges();
        }
    }
}
