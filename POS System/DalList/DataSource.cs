
using DO;

namespace Dal;

internal static class DataSource
{
   internal static List<Customer?> Customers = new List<Customer?>();
   internal static List<Product> Products = new List<Product>();
   internal static List<Sale> Sales = new List<Sale>();

    internal static class Config
    {
        internal const int ProductMinCode = 100;
        internal const int SaleMinCode = 200;

        private static int ProductIndex = ProductMinCode;
        private static int SaleIndex = SaleMinCode;

        public static int ProductCode=>ProductIndex+=10;
       
        public static int SaleCode=>SaleIndex+=10;
      
    }

}

