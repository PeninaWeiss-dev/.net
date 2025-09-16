
namespace BO;

public class Sale
{
    public int SaleId { get; init; }
    public int ProductId { get; set; }
    public int CountForSale { get; set; }
    public int SumSale { get; set; }
    public bool ForAllCustomers { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }


    public Sale(int saleId, int productId, int countForSale, int sumSale, bool forAllCustomers, DateTime beginDate, DateTime endDate)
    {
        SaleId = saleId;
        ProductId = productId;
        CountForSale = countForSale;
        SumSale = sumSale;
        ForAllCustomers = forAllCustomers;
        BeginDate = beginDate;
        EndDate = endDate;
    }

    public override string ToString()
    {
        return "";
    }
}
