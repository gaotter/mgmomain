using mgmofrontpageinterfaces.LandingPage;
using mgmofrontpageinterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmofrontpageblo.LandingPage
{
    public class FrontPageHandler : IFrontPageHandler
    {
        private readonly IFrontPost frontPost;

        public FrontPageHandler(IFrontPost frontPost)
        {
            this.frontPost = frontPost;
        }
        public IEnumerable<FrontPageRecord> GetAllFrontPageRecords()
        {
            return frontPost.GetAllFrontPageRecords();
        }
    }
}
