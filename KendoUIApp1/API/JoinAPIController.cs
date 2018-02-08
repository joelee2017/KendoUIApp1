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
    }
}
