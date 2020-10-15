using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoexampleinterface.ResponsivPattern
{
    public interface IObserver
    {
        public void SendData<T>(T data);

        public void Error<T>(T data);

        public void Done<T>(T data);

    }
}
