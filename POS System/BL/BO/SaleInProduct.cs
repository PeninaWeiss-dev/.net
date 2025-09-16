
namespace BO;

public class SaleInProduct
{
    public int SaleId { get; set; }
    public int QuanityForSale { get; set; }
    public double Price { get; set; }
    public bool ForAllCustomers { get; set; }

    //public SaleInProduct(int saleId, int quanityForSale, double price, bool forAllCustomers) { 
    //    SaleId = saleId;
    //    QuanityForSale = quanityForSale;
    //    Price = price;
    //    ForAllCustomers = forAllCustomers;
    //}

    //public override string ToString()
    //{
    //    return base.ToString();
    //}
}
