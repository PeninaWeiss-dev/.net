using BlApi;
using BO;

namespace BlImplementation;
internal class SaleImplementation:ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Sale sale)
    {
        try
        {
            return _dal.Sale.Create(sale.convert());
        }
        catch (Exception ex)
        {
            throw new Exception("");
        }
    }
    public BO.Sale? Read(Func<BO.Sale, bool> filter)
    {
        Func<DO.Sale, bool> Filter = Sale => filter(Sale.convert());
        return _dal.Sale.Read(Filter).convert();
    }
    public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
    {
        return _dal.Sale.ReadAll().Select(c => c.convert()).ToList();
    }
    public void Update(BO.Sale sale)
    {
        _dal.Sale.Update(sale.convert());
    }
    public void Delete(int id)
    {
        _dal.Sale.Delete(id);
    }
}
