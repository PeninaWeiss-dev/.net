

namespace BO;

public class Customer
{
    public int Tz { get; init; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public string? Phone { get; set; }

    public Customer(int tz, string? name, string? adress, string? phone)
    {
        Tz = tz;
        Name = name;
        Adress = adress;
        Phone = phone;
    }


    public override string ToString()
    {
        return "";
    }


}
