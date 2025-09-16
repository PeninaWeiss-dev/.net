
using BO;

namespace BlApi;

public interface ICustomer
{
    int Create(Customer customer); 
    Customer? Read(Func<Customer, bool> filter); 
    List<Customer?> ReadAll(Func<Customer, bool>? filter = null);
    void Update(Customer customer); 
    void Delete(int id);
    bool IsExists(int id);
}
