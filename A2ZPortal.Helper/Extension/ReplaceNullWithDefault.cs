using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Helper.Extension
{
    public static class ReplaceNullWithDefault
    {
        public static T ReplaceWithDefault<T>(T typeModel)
        {
            Type modelType = typeModel.GetType();
            PropertyInfo[] pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
            {
                if (prop.PropertyType.Name == "string" && prop.GetValue(modelType,null)==null)
                {
                    prop.SetValue(typeModel,string.Empty);
                }

            }
            return typeModel;
        }
    }
}
