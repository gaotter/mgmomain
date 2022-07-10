using MgmoTableStorageBase;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgmoTableStorageBase
{
    public class TableStorageBase
    {
        protected ConnectionInfo _connectionInfo;
        protected CloudStorageAccount storageAccount;
        protected CloudTableClient tableClinet;
        public TableStorageBase(ConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;

            storageAccount = CloudStorageAccount.Parse(connectionInfo.ConnectionString);
            tableClinet = storageAccount.CreateCloudTableClient();
        }
    }
}
