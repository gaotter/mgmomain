using mgmofrontpageinterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmofrontpageblo.LandingPage
{
    public interface IFrontPageHandler
    {
        public IEnumerable<FrontPageRecord> GetAllFrontPageRecords();
    }
}
