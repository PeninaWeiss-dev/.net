using BlApi;
using BO;
using DO;
namespace BlImplementation;
internal class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Product product)
    {
        try
        {
            return _dal.Product.Create(product.convert());
        }
        catch (Exception ex)
        {
            throw new Exception("");
        }
    }
    public BO.Product? Read(Func<BO.Product, bool> filter)
    {
        Func<DO.Product, bool> Filter = Product => filter(Product.convert());
        return _dal.Product.Read(Filter).convert();
    }
    public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        return _dal.Product.ReadAll().Select(c => c.convert()).ToList();
    }
    public void Update(BO.Product product)
    {
        _dal.Product.Update(product.convert());
    }
    public void Delete(int id)
    {
        _dal.Product.Delete(id);
    }
    public List<BO.Sale> GetSales(int productId, bool preferredCustomer)
    {
        List<BO.Sale>l= _dal.Sale.ReadAll().Select(i=>i.convert()).Where(i => i.ProductId == productId && i.BeginDate <= DateTime.Now && i.EndDate >= DateTime.Now).ToList();
        if(!preferredCustomer)
            l.Select(i=>i).Where(i=>i.ForAllCustomers==true).ToList();
        return l;
    }
}
