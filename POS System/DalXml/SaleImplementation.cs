namespace Dal;
using DalApi;
using DO;
using global::DalXml;
using System.Xml.Linq;
internal class SaleImplementation : ISale
{
    static Sale sale;
    const string PATH = @"..\xml\sales.xml";
    const string SALE = "sale";
    const string SALES = "sales";
    const string SALEID = "SaleId";
    const string PRODUCTID = "ProductId";
    const string COUNTFORSALE = "CountForSale";
    const string SUMSALE = "SumSale";
    const string FORALLCUSTOMERS = "ForAllCustomers";
    const string BEGINDATE = "BeginDate";
    const string ENDDATE = "EndDate";

    public int Create(Sale sale)
    {
        XElement saleXml = XElement.Load(PATH);
        int nextId = Config.SaleIndex;
        var arrayOfSale = saleXml.Element("ArrayOfSale");
        if (arrayOfSale == null)
        {
            arrayOfSale = new XElement("ArrayOfSale");
            saleXml.Add(arrayOfSale);
        }
        arrayOfSale.Add(new XElement(SALE,
            new XElement(SALEID, nextId),
            new XElement(PRODUCTID, sale.ProductId),
            new XElement(COUNTFORSALE, sale.CountForSale),
            new XElement(SUMSALE, sale.SumSale),
            new XElement(FORALLCUSTOMERS, sale.ForAllCustomers),
            new XElement(BEGINDATE, sale.BeginDate),
            new XElement(ENDDATE, sale.EndDate)));
        saleXml.Save(PATH);
        return nextId;
    }

    public Sale? ReadById(int id)
    {
        XElement saleXml = XElement.Load(PATH);
        XElement xml = saleXml.Descendants(SALEID).First(s => int.Parse(s.Value) == id).Parent;
        Sale sale = new Sale(int.Parse(xml.Element(SALEID).Value),
                                int.Parse(xml.Element(PRODUCTID).Value),
                                int.Parse(xml.Element(COUNTFORSALE).Value),
                                int.Parse(xml.Element(SUMSALE).Value),
                                bool.Parse(xml.Element(FORALLCUSTOMERS).Value),
                                DateTime.Parse(xml.Element(BEGINDATE).Value),
                                DateTime.Parse(xml.Element(ENDDATE).Value));
        return sale;
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        XElement saleXml = XElement.Load(PATH);
        var sales = saleXml.Descendants(SALE)
                        .Select(s => new Sale(
                                int.Parse(s.Element(SALEID).Value),
                                int.Parse(s.Element(PRODUCTID).Value),
                                int.Parse(s.Element(COUNTFORSALE).Value),
                                int.Parse(s.Element(SUMSALE).Value),
                                bool.Parse(s.Element(FORALLCUSTOMERS).Value),
                                DateTime.Parse(s.Element(BEGINDATE).Value),
                                DateTime.Parse(s.Element(ENDDATE).Value)));

        return sales.FirstOrDefault(filter);
    }

    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        XElement saleXml = XElement.Load(PATH);
        var sales = saleXml.Descendants("sale")
            .Select(s => new Sale(
                                int.Parse(s.Element(SALEID).Value),
                                int.Parse(s.Element(PRODUCTID).Value),
                                int.Parse(s.Element(COUNTFORSALE).Value),
                                int.Parse(s.Element(SUMSALE).Value),
                                bool.Parse(s.Element(FORALLCUSTOMERS).Value),
                                DateTime.Parse(s.Element(BEGINDATE).Value),
                                DateTime.Parse(s.Element(ENDDATE).Value))).ToList();

        return filter != null ? sales.Where(filter).ToList() : sales;
    }

    public void Update(Sale sale)
    {
        XElement saleXml = XElement.Load(PATH);
        XElement s = saleXml.Descendants("SaleId").First(id => int.Parse(id.Value) == sale.SaleId).Parent;
        s.Element(PRODUCTID).SetValue(sale.ProductId);
        s.Element(COUNTFORSALE).SetValue(sale.CountForSale);
        s.Element(SUMSALE).SetValue(sale.SumSale);
        s.Element(FORALLCUSTOMERS).SetValue(sale.ForAllCustomers);
        s.Element(BEGINDATE).SetValue(sale.BeginDate);
        s.Element(ENDDATE).SetValue(sale.EndDate);
        saleXml.Save(PATH);
    }
    public void Delete(int id)
    {
        XElement saleXml = XElement.Load(PATH);
        saleXml.Descendants(SALEID).First(s => int.Parse(s.Value) == id).Parent.Remove();
        saleXml.Save(PATH);
    }
    
}
