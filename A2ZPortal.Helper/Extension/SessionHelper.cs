using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Text;


namespace A2ZPortal.Helper.Extension
{
    public static class SessionHelper
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }


        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static void SetBoolean(this ISession session, string key, bool value) => session.Set(key, BitConverter.GetBytes(value));

        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static void SetDouble(this ISession session, string key, double value) => session.Set(key, BitConverter.GetBytes(value));


        public static double? GetDouble(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToDouble(data, 0);
        }
        public static byte[] Get(this ISession session, string key)
        {
            byte[] numArray = (byte[])null;
            session.TryGetValue(key, out numArray);
            return numArray;
        }

        public static void SetString(this ISession session, string key, string value) => session.Set(key, Encoding.UTF8.GetBytes(value));

        public static string GetString(this ISession session, string key)
        {
            byte[] bytes = session.Get(key);
            return bytes == null ? (string)null : Encoding.UTF8.GetString(bytes);
        }

    }
}