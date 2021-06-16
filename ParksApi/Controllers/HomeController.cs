using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksApi.Controllers
{

    public class HomeController : ControllerBase
    {

        [HttpGet("")]
        public ActionResult Get()
        {
            return Ok("Api");
        }
    }
}
