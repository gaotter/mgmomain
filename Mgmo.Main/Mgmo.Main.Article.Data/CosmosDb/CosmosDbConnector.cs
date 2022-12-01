using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace Mgmo.Main.Article.Data.CosmosDb
{
    public class CosmosDbConnector
    {
        TableClient tableClient;

        private TableClient GetTableClient()
        {
            var tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));
        }
    }
}
