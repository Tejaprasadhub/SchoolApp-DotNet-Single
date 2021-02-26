using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model
{
   public class GridParameters
    {
        public int PageNo { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }

        public string Filter { get; set; }

        public string sorts { get; set; }

        public string idValue { get; set; }

        public int queryType { get; set; }
        public string tablecode { get; set; }
    }
}
