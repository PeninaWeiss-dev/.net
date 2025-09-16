
namespace BO;

internal static class Tools
{
    public static BO.Product convert( this DO.Product product)
    {
        return new BO.Product(product.ProductId, product.ProductName, (BO.Categories)product.Category, product.Price, product.Quanity);        
    }
    public static DO.Product convert(this BO.Product product)
    {
        return new DO.Product(product.ProductId, product.ProductName, (DO.Categories)product.Category, product.Price, product.Quanity);
    }
    public static BO.Customer convert(this DO.Customer customer)
    {
        return new BO.Customer(customer.Tz, customer.Name, customer.Adress, customer.Phone);
    }
    public static DO.Customer convert(this BO.Customer customer)
    {
        return new DO.Customer(customer.Tz, customer.Name, customer.Adress, customer.Phone);
    }
    public static BO.Sale convert(this DO.Sale sale)
    {
        return new BO.Sale(sale.SaleId,sale.ProductId,sale.CountForSale,sale.SumSale,sale.ForAllCustomers,sale.BeginDate,sale.EndDate);
    }
    public static DO.Sale convert(this BO.Sale sale)
    {
        return new DO.Sale(sale.SaleId, sale.ProductId, sale.CountForSale, sale.SumSale, sale.ForAllCustomers, sale.BeginDate, sale.EndDate);
    }

    
}
