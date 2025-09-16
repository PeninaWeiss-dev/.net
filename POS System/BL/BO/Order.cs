
namespace BO;

public class Order
{
    public int OrderId { get; init; }
    public bool? PreferredCustomer { get; set; }
    public List<ProductInOrder> ProductList { get; set; }
    public double TotalSum { get; set; }

    //public Order(int orderId, bool? preferredCustomer, List<ProductInOrder> productList, double totalSum)
    //{
    //    OrderId = orderId;
    //    PreferredCustomer = preferredCustomer;
    //    ProductList = productList;
    //    TotalSum = totalSum;
    //}

    //public override string ToString()
    //{
    //    return "";
    //}

}
