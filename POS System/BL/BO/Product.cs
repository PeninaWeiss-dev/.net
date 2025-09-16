
namespace BO;

public class Product
{
    public int ProductId { get; init; }
    public string ProductName { get; set; }
    public Categories Category { get; set; }
    public  double Price { get; set; }
    public int Quanity { get; set; }

    public List<SaleInProduct> SaleInProduct { get; set; }

    public Product(int productId, string productName, Categories category, double price, int quanity)
    {
        ProductId = productId;
        ProductName = productName;
        Category = category;
        Price = price;
        Quanity = quanity;
        SaleInProduct = new List<SaleInProduct>();
    }

    public override string ToString()
    {
        return "";
    }


}
