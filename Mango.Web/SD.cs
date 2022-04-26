namespace Mango.Web
{
    public static class SD
    {
        #region Properties

        public static string ProductAPIBase { get; set; }

        public enum ApiType
        {
            Get,
            Post,
            Put,
            Delete
        }

        #endregion
    }
}
