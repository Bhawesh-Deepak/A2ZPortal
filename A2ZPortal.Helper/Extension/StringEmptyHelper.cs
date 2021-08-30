using System;

namespace A2ZPortal.Helper.Extension
{
    public static  class StringEmptyHelper
    {
        public static T EmptyToDefault<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}