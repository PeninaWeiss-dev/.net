
using DalApi;
using DO;
using System.Xml.Serialization;

internal class CustomerImplementation:ICustomer
{
    const string PATH = @"..\xml\customers.xml";

    public int Create(Customer item)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        List<Customer> customers;
        using (StreamReader sr = new StreamReader(PATH))
        {
            customers = serializer.Deserialize(sr) as List<Customer>;
        }
        customers.Add(item);
        using (StreamWriter sw = new StreamWriter(PATH))
        {
            serializer.Serialize(sw, customers);
        }
        return item.Tz;
    }
    public Customer? Read(Func<Customer, bool> filter)
    { 
        XmlSerializer serializer=new XmlSerializer(typeof(List<Customer>));
        List<Customer> customers;
        using(StreamReader sr = new StreamReader(PATH))
        {
            customers=serializer.Deserialize(sr) as List<Customer>;
        }
        return customers.FirstOrDefault(c=>filter(c));
    }

    public Customer? ReadById(int id)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        List<Customer> customers;
        using (StreamReader sr = new StreamReader(PATH))
        {
            customers = serializer.Deserialize(sr) as List<Customer>;
        }
        return customers.FirstOrDefault(c => c.Tz==id);
    }
    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        List<Customer> customers;
        using (StreamReader sr = new StreamReader(PATH))
        {
            customers = serializer.Deserialize(sr) as List<Customer>;
        }
        if (filter != null)
            return customers?.Where(filter!).ToList() ?? throw new Exception();
        return customers;
        //return customers.Where(c=>filter(c)).ToList();
    }
    public void Update(Customer item)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        List<Customer> customers;
        using (StreamReader sr = new StreamReader(PATH))
        {
            customers = serializer.Deserialize(sr) as List<Customer>;
        }
        Delete(item.Tz);
        customers.Add(item);
        using(StreamWriter sw = new StreamWriter(PATH))
        {
            serializer.Serialize(sw, customers);
        }
    }
    public void Delete(int id)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        List<Customer> customers;
        using (StreamReader sr = new StreamReader(PATH))
        {
            customers = serializer.Deserialize(sr) as List<Customer>;
        }
        Customer item=customers.FirstOrDefault(c=>c.Tz==id);
        customers.Remove(item);
    }
}
