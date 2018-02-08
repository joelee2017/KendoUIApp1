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
    public class JoinAPIController : ApiController
    {
        private SQLLabEntities db = new SQLLabEntities();

        [HttpGet]
        public IEnumerable<test1> GetAll()
        {
            return db.test1;
        }

        [HttpGet]
        public IEnumerable<test1> CreateAll( string name, string dept)
        {
            test1 t1 = new test1();

            t1.name = name;
            t1.dept = dept;

            db.test1.Add(t1);
            db.SaveChanges();

            return db.test1;
        }

        [HttpGet]
        public IEnumerable<test1>EditAll(int id)
        {
            test1 t1 = db.test1.Find(id);

            t1.name = "wait10";
            t1.dept = "wait10";
            
            db.SaveChanges();

            return db.test1;            
        }

        [HttpGet]
        public IEnumerable<test1>DeleteAll(int id)
        {
            test1 t1 = db.test1.Find(id);

            db.test1.Remove(t1);
            db.SaveChanges();

            return db.test1;
        }

        [HttpGet] //以下方法只為了將資料放到Kendo之中
        public DataSourceResult Test_GetAll([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            return db.test1.ToDataSourceResult(request);
        }

        [HttpPost]
        public void Create(test1 Test)
        {
            var entity = new test1
            {
                ID = Test.ID,
                name = Test.name,
                dept = Test.dept
            };
            db.test1.Add(entity);
            db.SaveChanges();
        }

    }
}
