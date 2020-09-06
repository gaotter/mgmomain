using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mgmoapi.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class PingController : ControllerBase
    {
        public object Get(string data)
        {
            return new { message = "from server " + data };
        }
    }
}
