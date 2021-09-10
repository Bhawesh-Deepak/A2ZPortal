using System;
using System.Reflection;

namespace A2ZPortal.Helper.Extension
{

    /// <summary>
    /// This class is used to replace the null value with default value of the class property.
    /// So that if there must not be any exception during saving the data in sql server.
    /// </summary>
    public static class ReplaceNullWithDefault
    {
        public static T ReplaceWithDefault<T>(T typeModel)
        {
            Type modelType = typeModel.GetType();
            PropertyInfo[] pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
            {
                switch (prop.PropertyType.Name)
                {
                    case "String" when prop.GetValue(modelType, null) == null:
                        prop.SetValue(typeModel, string.Empty);
                        break;
                    case "Decimal" when prop.GetValue(modelType, null) == null:
                        prop.SetValue(typeModel, default(decimal));
                        break;
                    case "Int32" when prop.GetValue(modelType, null) == null:
                        prop.SetValue(typeModel, default(Int32));
                        break;
                    case "Float" when prop.GetValue(modelType, null) == null:
                        prop.SetValue(typeModel, default(float));
                        break;
                    default:
                        break;
                }

            }
            return typeModel;
        }
    }
}
