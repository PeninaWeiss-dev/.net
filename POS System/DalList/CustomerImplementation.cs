using DalApi;
using DO;
using Tools;
using System.Reflection;

namespace Dal;
internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        bool exists = DataSource.Customers.Any(i => i.Tz == item.Tz);
        if (exists)
        {
            throw new DalAlreadyExistingIdException("The Tz is already exists");
        }
        DataSource.Customers.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return item.Tz;
    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Customer? customer = DataSource.Customers.FirstOrDefault(filter);
        if (customer == null) 
        {
            throw new DalNoExistingIdException("Customer not found");

        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return customer;
    }

    public Customer? ReadById(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        Customer? customer = DataSource.Customers.FirstOrDefault(i=>i.Tz==id);
        if (customer == null)
        {
            throw new DalNoExistingIdException("There is no customer with this Tz");

        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return customer;
    }

    public List<Customer> ReadAll(Func<Customer,bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        List<Customer> l;
        if (filter == null)
        {
            l = new List<Customer>(DataSource.Customers);
        }
        else
        {
            l = DataSource.Customers.Where(filter).ToList();
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
        return l;
    }
    public void Update(Customer item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        bool f=false;
        Customer? customer = DataSource.Customers.FirstOrDefault(i => i.Tz == item.Tz);
        if (customer == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
            throw new DalNoExistingIdException("There is no customer with this Tz");
        }
        Delete(item.Tz);
        DataSource.Customers.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
    }
    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start ");
        bool f = false;
        Customer? customer = DataSource.Customers.FirstOrDefault(i =>i.Tz == id);
        if (customer == null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
            throw new DalNoExistingIdException("customer is not found");
        }
        DataSource.Customers.Remove(customer);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end ");
    }

}
