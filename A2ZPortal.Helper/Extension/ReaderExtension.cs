using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Helper.Extension
{
    public static class ReaderExtension
    {
        public static T DefaultIfNull<T>(this SqlDataReader reader, string entityPropName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(entityPropName)))
                return (T)reader.GetValue(reader.GetOrdinal(entityPropName));
            return default(T);
        }
    }
}
