
using BO;

namespace BlApi;

public interface IProduct
{
    int Create(Product product);
    Product? Read(Func<Product, bool> filter);
    List<Product?> ReadAll(Func<Product, bool>? filter = null);
    void Update(Product product);
    void Delete(int id);
    List<BO.Sale> GetSales(int productId, bool preferredCustomer);
}
