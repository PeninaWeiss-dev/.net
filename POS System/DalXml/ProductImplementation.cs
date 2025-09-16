namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Xml.Serialization;

internal class ProductImplementation : IProduct
{
    const string PATH = @"..\xml\products.xml";
    public int Create(DO.Product item)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        List<Product> products;
        using (StreamReader sr = new StreamReader(PATH))
        {
            products = serializer.Deserialize(sr) as List<Product>;
        }
        products.Add(item);
        using (StreamWriter sw = new StreamWriter(PATH))
        {
            serializer.Serialize(sw, products);
        }
        return item.ProductId;
    }
    public DO.Product? Read(Func<DO.Product, bool> filter)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        List<Product> products;
        using (StreamReader sr = new StreamReader(PATH))
        {
            products = serializer.Deserialize(sr) as List<Product>;
        }
        return products.FirstOrDefault(c => filter(c));
    }

    public DO.Product? ReadById(int id)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        List<Product> products;
        using (StreamReader sr = new StreamReader(PATH))
        {
            products = serializer.Deserialize(sr) as List<Product>;
        }
        return products.FirstOrDefault(c => c.ProductId == id);
    }
    public List<DO.Product?> ReadAll(Func<DO.Product, bool>? filter = null)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        List<Product> products;
        using (StreamReader sr = new StreamReader(PATH))
        {
            products = serializer.Deserialize(sr) as List<Product>;
        }
        if (filter != null)
            return products?.Where(filter!).ToList() ?? throw new Exception();
        return products;
        //return products.Where(c => filter(c)).ToList();
    }
    public void Update(DO.Product item)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        List<Product> products;
        using (StreamReader sr = new StreamReader(PATH))
        {
            products = serializer.Deserialize(sr) as List<Product>;
        }
        Delete(item.ProductId);
        products.Add(item);
        using (StreamWriter sw = new StreamWriter(PATH))
        {
            serializer.Serialize(sw, products);
        }
    }
    public void Delete(int id)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        List<Product> products;
        using (StreamReader sr = new StreamReader(PATH))
        {
            products = serializer.Deserialize(sr) as List<Product>;
        }
        Product item = products.FirstOrDefault(c => c.ProductId == id);
        products.Remove(item);
    }
}
