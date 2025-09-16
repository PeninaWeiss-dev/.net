
using System.Xml.Linq;

namespace DalXml;
internal class Config
{
    const string PATH = @"..\xml\data-config.xml";
    static XElement xElement = XElement.Load(PATH);
    public static int ProductIndex
    {
        get
        {
            int productIndex;
            if (!int.TryParse(xElement.Element("productIndex").Value, out productIndex))
                productIndex = 100;
            xElement.Element("productIndex").SetValue(productIndex + 1);
            xElement.Save(PATH);
            return productIndex;
        }
    }
    public static int SaleIndex
    {
        get
        {
            int saleIndex;
            if (!int.TryParse(xElement.Element("saleIndex").Value, out saleIndex))
                saleIndex = 200;
            xElement.Element("saleIndex").SetValue(saleIndex + 1);
            xElement.Save(PATH);
            return saleIndex;
        }
    }
}
