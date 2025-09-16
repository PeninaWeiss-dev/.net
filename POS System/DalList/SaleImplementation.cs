using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class SaleImplementation:ISale
{
    public int Create(Sale item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Sale s = item with { SaleId = DataSource.Config.SaleCode };
        DataSource.Sales.Add(s);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return item.SaleId;
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Sale? sale = DataSource.Sales.FirstOrDefault(filter);
        if (sale == null)
        {
            throw new DalNoExistingIdException("sale no found");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return sale;
    }

    public Sale? ReadById(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Sale? sale = DataSource.Sales.FirstOrDefault(i => i.SaleId == id);
        if (sale == null)
        {
            throw new DalNoExistingIdException("There is no sale with this id");

        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return sale;
    }
    public List<Sale> ReadAll()
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return new List<Sale>(DataSource.Sales);
    }
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        List<Sale> l;
        if (filter == null)
        {
            l = new List<Sale>(DataSource.Sales);
        }
        else
        {
            l = DataSource.Sales.Where(filter).ToList();
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return l;
    }
    public void Update(Sale item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Sale? sale = DataSource.Sales.FirstOrDefault(i => i.SaleId == item.SaleId);
        if (sale == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
            throw new DalNoExistingIdException("sale is not found");
        }
        Delete(item.SaleId);
        DataSource.Sales.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
    }
    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Sale? sale = DataSource.Sales.FirstOrDefault(i => i.SaleId == id);
        if (sale == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
            throw new DalNoExistingIdException("sale is not found");
        }
        DataSource.Sales.Remove(sale);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
    }

}
