namespace FiyiStackWeb.ConnectionStrings
{
    public static class ConnectionStrings
    {
        public static string Production()
        {
            return "Password=O$6j5f5b4;Persist Security Info=True;User ID=fiyistac_FiyiStackWebAdmin;Initial Catalog=fiyistac_FiyiStackWeb;Data Source=192.168.28.14;TrustServerCertificate=True";
        }

        public static string Development()
        {
            return "data source =.; initial catalog = fiyistack_FiyiStackWeb; Integrated Security = SSPI; MultipleActiveResultSets=True;Pooling=false;Persist Security Info=True;App=EntityFramework;TrustServerCertificate=True";
        }

        public static string FiyiStackAppProduction()
        {
            return "Password=2Mr4h$t00;Persist Security Info=True;User ID=fiyistac_FiyiStackAppAdmin;Initial Catalog=fiyistac_FiyiStackApp;Data Source=192.168.28.14;TrustServerCertificate=True";
    }
    }
}
