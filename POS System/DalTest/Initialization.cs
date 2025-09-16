using DO;
using DalApi;

namespace DalTest;

public static class Initialization
{
    private static IDal? s_dal;
    public static void Intialize()
    {
        s_dal = DalApi.Factory.Get;
        createCustomer();
        createProducts();
        createSale();
    }
    private static void createCustomer()
    {
        s_dal.Customer.Create(new Customer(215658974, "Sari Lev", "Exodus", "0527645814"));
        s_dal.Customer.Create(new Customer(125478996, "Shevi Peles", "Herzel", "0548457412"));
        s_dal.Customer.Create(new Customer(102365447, "Zipi Levi", "Yafo", "0583265489"));
        s_dal.Customer.Create(new Customer(225468596, "Noa Gold", "Maharil", "0556748541"));
        s_dal.Customer.Create(new Customer(123521458, "Michal Atia", "Rashi", "0528425687"));
    }
    private static void createProducts()
    {
        s_dal.Product.Create(new Product(0, "21 בבית אחד", Categories.childrenBooks, 60, 12));
        s_dal.Product.Create(new Product(1, "מהמטבח היהודי", Categories.recipeBooks, 100, 5));
        s_dal.Product.Create(new Product(2, "הדופליקטים", Categories.adultBooks, 80, 27));
        s_dal.Product.Create(new Product(3, "אור מתוך העמק", Categories.biographyBooks, 90, 8));
        s_dal.Product.Create(new Product(4, "קריסטל מול האור", Categories.theoreticalBooks, 75, 15));
    }
    private static void createSale()
    {
        s_dal.Sale.Create(new Sale(0, 3, 2, 150, true, new DateTime(), new DateTime()));
        s_dal.Sale.Create(new Sale(1, 1, 3, 230, false, new DateTime(), new DateTime()));
        s_dal.Sale.Create(new Sale(2, 2, 1, 60, false, new DateTime(), new DateTime()));
        s_dal.Sale.Create(new Sale(3, 1, 2, 200, true, new DateTime(), new DateTime()));
        s_dal.Sale.Create(new Sale(4, 0, 3, 300, true, new DateTime(), new DateTime()));
    }
}
