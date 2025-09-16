
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace DalTest;

class Program
{
    
    private static IDal s_dal =  DalApi.Factory.Get;
    private static void s_create<T>(ICrud<T> crud, T obj)
    {
        crud.Create(obj);
        Console.WriteLine($"{typeof(T).Name} added.");
    }  
    private static void MainMenu()
    {
        try
        {
            Console.WriteLine("choose an entity");
            Console.WriteLine("for customers, press 1");
            Console.WriteLine("for products, press 2");
            Console.WriteLine("for sale, press 3");
            Console.WriteLine("for cleaning old folders press 9");
            Console.WriteLine("for exit press 0");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    funcMenu("customer");
                    break;
                case 2:
                    funcMenu("product");
                    break;
                case 3:
                    funcMenu("sale");
                    break;
                case 9:
                    LogManager.CleanOldDir();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Error!!");
                    break;

            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }

    private static void funcMenu(string entity)
    {
        try
        {
            Console.WriteLine("choose an action");
            Console.WriteLine($"for createing a {entity} press 1");
            Console.WriteLine($"for reading a {entity} press 2");
            Console.WriteLine($"for reading all a {entity}s press 3");
            Console.WriteLine($"for updating a {entity} press 4");
            Console.WriteLine($"for deleting a {entity} press 5");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    creteItems(entity);
                    break;
                case 2:
                    ReadItem(entity);
                    break;
                case 3:
                    ReadAllItems(entity);
                    break;
                case 4:
                    Update(entity);
                    break;
                case 5:
                    Delete(entity);
                    break;
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }

    private static void creteItems(string entity)
    {
        try
        {
            switch (entity)
            {
                case "customer":
                    Console.WriteLine("enter TZ");
                    int Tz = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter name");
                    string? Name = Console.ReadLine();
                    Console.WriteLine("enter adress");
                    string? Adress = Console.ReadLine();
                    Console.WriteLine("enter phone number");
                    string? Phone = Console.ReadLine();
                    DO.Customer customer = new DO.Customer(Tz, Name, Adress, Phone);
                    //s_dal.Customer.Create(customer);
                    s_create(s_dal.Customer, customer);
                    break;
                case "product":
                    Console.WriteLine("enter productId");
                    int ProductId = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter product name");
                    string ProductName = Console.ReadLine();
                    Console.WriteLine("enter category");
                    string input = Console.ReadLine();
                    Enum.TryParse(input, true, out Categories selectedCategory);
                    Console.WriteLine("enter price");
                    double Price = double.Parse(Console.ReadLine());
                    Console.WriteLine("enter quanity");
                    int Quanity = int.Parse(Console.ReadLine());
                    DO.Product product = new DO.Product(ProductId, ProductName, selectedCategory, Price, Quanity);
                    s_create(s_dal.Product, product);
                    break;
                case "Sale":
                    Console.WriteLine("enter saleId");
                    int SaleId = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter productId");
                    int ProductId2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter count fo sale");
                    int CountForSale = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter sum sale");
                    int SumSale = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter if for all customers");
                    string input2 = Console.ReadLine();
                    bool.TryParse(input2, out bool ForAllCustomers);
                    Console.WriteLine("enter begin date");
                    input2 = Console.ReadLine();
                    DateTime.TryParse(input2, out DateTime BeginDate);
                    Console.WriteLine();
                    input2 = Console.ReadLine();
                    DateTime.TryParse(input2, out DateTime EndDate);
                    DO.Sale sale = new DO.Sale(SaleId, ProductId2, CountForSale, SumSale, ForAllCustomers, BeginDate, EndDate);
                    s_create(s_dal.Sale, sale);
                    break;
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private static void ReadItem(string entity)
    {
        Console.WriteLine("enter id");
        int id=int.Parse(Console.ReadLine());
        try
        {
            switch (entity)
            {
                case "customer":
                    s_dal.Customer.Read(i=>i.Tz==id);
                    break;
                case "product":
                    s_dal.Product.Read(i => i.ProductId == id);
                    break;
                case "sale":
                    s_dal.Sale.Read(i => i.SaleId == id);
                    break;
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private static void ReadAllItems(string entity)
    {
        try
        {
            switch (entity)
            {
                case "customer":
                    Console.WriteLine(string.Join("\n",s_dal.Customer.ReadAll()));
                    break;
                case "product":
                    Console.WriteLine(string.Join("\n", s_dal.Product.ReadAll()));
                    break;
                case "sale":
                    Console.WriteLine(string.Join("\n", s_dal.Sale.ReadAll()));
                    break;
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private static void Update(string entity)
    {
        try
        {
            switch (entity)
            {
                case "customer":
                    Console.WriteLine("enter TZ");
                    int Tz = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter name");
                    string? Name = Console.ReadLine();
                    Console.WriteLine("enter adress");
                    string? Adress = Console.ReadLine();
                    Console.WriteLine("enter phone number");
                    string? Phone = Console.ReadLine();
                    DO.Customer customer = new DO.Customer(Tz, Name, Adress, Phone);
                    //s_dal.Customer.Create(customer);
                    s_dal.Customer.Update(customer);
                    break;
                case "product":
                    Console.WriteLine("enter productId");
                    int ProductId = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter product name");
                    string ProductName = Console.ReadLine();
                    Console.WriteLine("enter category");
                    string input = Console.ReadLine();
                    Enum.TryParse(input, true, out Categories selectedCategory);
                    Console.WriteLine("enter price");
                    double Price = double.Parse(Console.ReadLine());
                    Console.WriteLine("enter quanity");
                    int Quanity = int.Parse(Console.ReadLine());
                    DO.Product product = new DO.Product(ProductId, ProductName, selectedCategory, Price, Quanity);
                    s_dal.Product.Update(product);
                    break;
                case "Sale":
                    Console.WriteLine("enter saleId");
                    int SaleId = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter productId");
                    int ProductId2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter count fo sale");
                    int CountForSale = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter sum sale");
                    int SumSale = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter if for all customers");
                    string input2 = Console.ReadLine();
                    bool.TryParse(input2, out bool ForAllCustomers);
                    Console.WriteLine("enter begin date");
                    input2 = Console.ReadLine();
                    DateTime.TryParse(input2, out DateTime BeginDate);
                    Console.WriteLine();
                    input2 = Console.ReadLine();
                    DateTime.TryParse(input2, out DateTime EndDate);
                    DO.Sale sale = new DO.Sale(SaleId, ProductId2, CountForSale, SumSale, ForAllCustomers, BeginDate, EndDate);
                    s_dal.Sale.Update(sale);
                    break;
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    private static void Delete(string entity)
    {
        try
        {
            int id = int.Parse(Console.ReadLine());
            switch (entity)
            {
                case "customer":
                    s_dal.Customer.Delete(id);
                    break;
                case "product":
                    s_dal.Product.Delete(id);
                    break;
                case "sale":
                    s_dal.Sale.Delete(id);
                    break;
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Error: {ex.Message}");
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("do yoy want to initialize data?");
        string res=Console.ReadLine();  
        if(res=="yes")
            Initialization.Intialize();
        while (true)
        {
            MainMenu();
        }
    } 
}