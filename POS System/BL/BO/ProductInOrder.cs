
namespace BO;

public class ProductInOrder
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int QuanityInOrder { get; set; }
    public List<SaleInProduct> SaleList { get; set; }
    public double TotalPrice { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }

}
