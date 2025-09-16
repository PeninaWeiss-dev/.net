
namespace Dal;
using DalApi;

internal sealed class DalXml : IDal
{
    private DalXml() { }
    private static readonly DalXml instance = new DalXml();
    public static DalXml Instance
    {
        get
        {
            return instance;
        }
    }
    public IProduct Product => new ProductImplementation();

    public ICustomer Customer => new CustomerImplementation();

    public ISale Sale => new SaleImplementation();
}
