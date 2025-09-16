using DalApi;
using DO;
using System.Reflection;
using Tools;


namespace Dal;

internal class ProductsImplementation : IProduct
{
    public int Create(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Product p = item with { ProductId = DataSource.Config.ProductCode };
        DataSource.Products.Add(p);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return p.ProductId;

    }
    public Product? Read(int id)
    {

        foreach (var item in DataSource.Products)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
            if (item.ProductId == id)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
                return item;
            }

        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        throw new DalNoExistingIdException("There is no product with this ID");
    }
    public Product? Read(Func<Product, bool> filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Product? product = DataSource.Products.FirstOrDefault(filter);
        if (product == null)
        {
            throw new DalNoExistingIdException("product no found");

        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return product;
    }

    public Product? ReadById(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Product? product = DataSource.Products.FirstOrDefault(i => i.ProductId == id);
        if (product == null)
        {
            throw new DalNoExistingIdException("There is no product with this id");

        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return product;
    }

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        List<Product> l;
        if (filter == null)
        {
            l = new List<Product>(DataSource.Products);
        }
        else
        {
            l = DataSource.Products.Where(filter).ToList();
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return l;
    }

  
    public void Update(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        bool f = false;
        Product? product = DataSource.Products.FirstOrDefault(i => i.ProductId == item.ProductId);
        if (product == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
            throw new DalNoExistingIdException("There is no product with this Tz");
        }
        Delete(item.ProductId);
        DataSource.Products.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
    }



    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        bool f = false; 
        Product? product = DataSource.Products.FirstOrDefault(i => i.ProductId == id);
        if (product == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
            throw new DalNoExistingIdException("product is not found");
        }
        DataSource.Products.Remove(product);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
    }

}
