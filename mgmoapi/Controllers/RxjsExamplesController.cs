using mgmoexampleinterface.Rxjs;
using mgmoexampleinterface.Rxjs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgmoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RxjsExamplesController : ControllerBase
    {
        private readonly IRxJsExample rxJsExample;

        public RxjsExamplesController(IRxJsExample rxJsExample)
        {
            this.rxJsExample = rxJsExample;
        }

        [HttpGet()]
        public ActionResult<RxJsExampleData> Get(string message = "none")
        {
            return rxJsExample.GetExampleData(message);
        }
    }
}
