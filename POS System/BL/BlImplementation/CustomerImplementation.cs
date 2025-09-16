using BlApi;

using BO;
using DO;
namespace BlImplementation;
internal class CustomerImplementation : ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Customer customer)
    {
        try
        {
            return _dal.Customer.Create(customer.convert());
        }
        catch (Exception ex)
        {
            throw new Exception("");
        }
    }
    public BO.Customer? Read(Func<BO.Customer, bool> filter)
    {
        Func<DO.Customer, bool> Filter = Customer => filter(Customer.convert());
        return _dal.Customer.Read(Filter).convert();
    }
    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        return _dal.Customer.ReadAll().Select(c => c.convert()).ToList();
    }
    public void Update(BO.Customer customer)
    {
        _dal.Customer.Update(customer.convert());
    }
    public void Delete(int id)
    {
        _dal.Customer.Delete(id);
    }
    public bool IsExists(int id)
    {
        return Read(i => i.Tz == id) != null;
    }
}
