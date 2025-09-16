using DalApi;

namespace Dal;

internal sealed class DalList:IDal
{
    public static DalList Instance { get;  }=new DalList();
    private DalList() { }
    public ICustomer Customer => new CustomerImplementation();
    public IProduct Product=>new ProductsImplementation();
    public ISale Sale => new SaleImplementation();

}
