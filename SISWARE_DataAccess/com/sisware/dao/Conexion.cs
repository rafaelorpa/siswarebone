using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.dao
{
    public  sealed class Conexion
    {
        public static string LeerCC
        {
            get { return "Server=localhost; Port=3306; User Id=root; password=; Persist Security Info=True; database=swbone"; }
        }
    }
}
