using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOFWork.Core.models
{
    public class books
    {
        public int id { get; set; }
        public string titel { get; set; }

        public author author { get; set; }
        public int authorid { get; set; }
    }
}
