using System;

namespace A2ZPortal.Helper.Extension
{
    public static class CommonCrudHelper
    {
        public static T CommonCreateCode<T>(T entity, int userId)
        {
            var modelType = entity.GetType();
            var pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
            {
                if (prop.Name == "CreatedDate")
                    prop.SetValue(entity, DateTime.Now.Date, null);
                if (prop.Name == "IsDeleted")
                    prop.SetValue(entity, false, null);
                else if (prop.Name == "IsActive")
                    prop.SetValue(entity, true, null);
            }


            return entity;
        }

        public static T CommonDeleteCode<T>(T entity, int userId)
        {
            var modelType = entity.GetType();
            var pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
                if (prop.Name == "IsDeleted")
                    prop.SetValue(entity, true, null);
                else if (prop.Name == "IsActive")
                    prop.SetValue(entity, false, null);
                else if (prop.Name == "UpdatedBy")
                    prop.SetValue(entity, userId, null);
                else if (prop.Name == "UpdatedDate") prop.SetValue(entity, DateTime.Now.Date, null);
            return entity;
        }

        public static T CommonUpdateCode<T>(T entity, int userId)
        {
            var modelType = entity.GetType();
            var pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
            {
                if (prop.Name == "UpdatedBy")
                    prop.SetValue(entity, userId, null);
                if (prop.Name == "IsDeleted")
                    prop.SetValue(entity, false, null);
                else if (prop.Name == "IsActive")
                    prop.SetValue(entity, true, null);
                else if (prop.Name == "UpdatedDate") prop.SetValue(entity, DateTime.Now.Date, null);
            }


            return entity;
        }
    }
}