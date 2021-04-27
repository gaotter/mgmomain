using mgmofrontpageinterfaces.LandingPage;
using mgmofrontpageinterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmofrontpagedata.FrontPage
{
    public class FrontPageData : IFrontPost
    {
        public IEnumerable<FrontPageRecord> GetAllFrontPageRecords()
        {
            throw new NotImplementedException();
        }
    }
}
