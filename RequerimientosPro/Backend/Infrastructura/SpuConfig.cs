using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructura
{
    public class SpuConfig
    {
     
        public string Query { get; set; }
        public SqlParameterCollection Paramms { get; set; }
    }
}
