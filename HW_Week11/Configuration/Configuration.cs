
namespace HW_Week11.Configuration
{
    public static class Configuration
    {
        public static string ConnectionString { get; set; }


        static Configuration()
        {
            ConnectionString = " Data Source =ELAMIR\\SQLEXPRESS; Initial Catalog = ShopDb; User id = sa; Password =123456 ; TrustServerCertificate=True; Encrypt=True; Integrated Security=True;";
        }
    }
}
