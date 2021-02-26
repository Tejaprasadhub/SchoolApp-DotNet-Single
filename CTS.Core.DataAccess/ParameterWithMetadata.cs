using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CTS.Core.DataAccess
{
    public class ParameterWithMetadata
    {
        public DbType Type { get; set; }
        public int Size { get; set; }
        public object Value { get; set; }
        public ParameterDirection Direction { get; set; }
    }
}
