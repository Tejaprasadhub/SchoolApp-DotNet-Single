using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.Core.DataAccess
{
    public class TableValueParameter
    {
        public DataTable Values { get; set; }
        public string DatabaseTypeName { get; set; }
    }
}
