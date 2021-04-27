using mgmofrontpageinterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmofrontpageinterfaces.LandingPage
{
    public interface IFrontPost
    {
        public IEnumerable<FrontPageRecord> GetAllFrontPageRecords();


            
    }
}
