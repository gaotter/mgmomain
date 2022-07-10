using System;

namespace mgmoexampleinterface.Rxjs.Models
{
    public class RxJsExampleData
    {
        public string Message { get; set; }

        public long Tick => DateTime.Now.Ticks;
    }
}
