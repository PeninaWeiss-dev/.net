using BlApi;

namespace BlImplementation;

internal class Bl : IBl
{
    public ICustomer iCustomer => new CustomerImplementation();

    public BlApi.ISale iSale => new SaleImplementation();

    public BlApi.IProduct iProduct => new ProductImplementation();

    public IOrder iOrder => new OrderImplementation();

    
}
