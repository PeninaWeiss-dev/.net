
using DO;
using DalApi;
namespace UI;

public partial class ViewAll : Form
{
    public ViewAll(string type)
    {
        InitializeComponent();
        List<Customer> list=Factory.Get.Customer.ReadAll();
        //switch (type)
        //{
        //    case "Customers":
        //        list = Factory.Get.Customer.ReadAll();
        //        break;
        //    //case "Products":
        //    //    list=new List<Product>();
        //    //    break;
        //    //case "Sales":
        //    //    list=new List<Sale>();
        //    //    break;
        //}
        dataGridView1.DataSource = list;
    }
}
