
namespace DO;

public record Sale(
int SaleId,
int ProductId,
int CountForSale,
int SumSale,
bool ForAllCustomers,
DateTime BeginDate,
DateTime EndDate
)
{
    public Sale() : this(0, 0, 0, 0, false, DateTime.Now, DateTime.Now)
    {

    }
}
