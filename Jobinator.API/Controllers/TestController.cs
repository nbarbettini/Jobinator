using Jobinator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jobinator.API.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test/1
        public TestModel Get(int id)
        {
            if (id == 1)
            {
                return new TestModel
                {
                    Id = Guid.Empty,
                    IntegerId = 1,
                    Data = "foo"
                };
            }
            else
            {
                return null;
            }
        }
    }
}
