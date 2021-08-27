namespace A2ZPortal.Helper
{
    public sealed class ViewPageHelper
    {
        private static ViewPageHelper _instanceHelperObject = new();

        public static ViewPageHelper InstanceHelper => _instanceHelperObject ??= new ViewPageHelper();

        public string GetPathDetail(string folderName, string viewName)
        {
            return $"~/Views/{folderName}/{viewName}.cshtml";
        }
    }
}