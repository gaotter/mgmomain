using mgmoexampleinterface.Rxjs;
using mgmoexampleinterface.Rxjs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmoexampleblo.RxjsExample
{
    public class RxJsExample : IRxJsExample
    {
        public RxJsExampleData GetExampleData(string message)
        {
            return new RxJsExampleData { Message = message };
        }
    }
}
