using Azure.Data.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mgmo.Main.Article.Infratructure.Interfaces.Stores
{
    public interface IArticleStore
    {
        Task<TableItem> GetArticleTable();
    }
}
