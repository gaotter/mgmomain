using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmofrontpageinterfaces.Models
{
    public record FrontPageRecord
    {
        public string PostType;

        public string Title;

        public DateTime Created;

        public string Content;
    }
}
