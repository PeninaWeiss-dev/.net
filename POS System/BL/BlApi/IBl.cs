
namespace BlApi;

public interface IBl
{
    public ICustomer iCustomer { get; }
    public IOrder iOrder { get; }
    public IProduct iProduct { get; }
    public ISale iSale { get; }
}
