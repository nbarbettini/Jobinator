using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jobinator.API.Controllers
{
    public class TitleController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            return Ok();
        }

    }
}
