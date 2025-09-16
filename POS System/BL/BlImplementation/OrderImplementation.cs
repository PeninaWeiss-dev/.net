using BlApi;
using BO;
namespace BlImplementation;
internal class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    //public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int quanityForOrder)
    //{
    //    BO.Product product=_dal.Product.ReadById(productId).convert();
    //    BO.ProductInOrder p =order.ProductList.Find(i=>i.ProductId==productId);
        
    //    if (p!=null)
    //    {
    //        if(p.QuanityInOrder+quanityForOrder > _dal.Product.Read(i => i.ProductId == productId).Quanity)
    //        {
    //            throw new Exception();//אם אין מספיק במלאי
    //        }
    //        else
    //        {
    //            order.ProductList.Find(i => i.ProductId == productId).QuanityInOrder = p.QuanityInOrder + quanityForOrder;
    //        }
    //    }
    //    else
    //    {
    //        SearchSaleForProduct(product, order.PreferredCustomer??false);
    //    }
    //}
    public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int amount)
    {
        var product = _dal.Product.ReadById(productId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        var foundProductInOrder = order.ProductList.FirstOrDefault(p => p.ProductId == productId);
        if (foundProductInOrder != null)
        {
            if (foundProductInOrder.QuanityInOrder + amount > product.Quanity)
            {
                throw new Exception("Not enough in stock");
            }
            foundProductInOrder.QuanityInOrder += amount;
        }
        else
        {
            if (amount > product.Quanity)
            {
                throw new Exception("Not enough in stock");
            }
            var newProductInOrder = new BO.ProductInOrder
            {
                ProductId = product.ProductId,
                QuanityInOrder = amount,
                Price = product.Price,
                ProductName = product.ProductName,
            };
            order.ProductList.Add(newProductInOrder);
            foundProductInOrder = newProductInOrder;
        }
        SearchSaleForProduct(foundProductInOrder, false);
        CalcTotalPriceForProduct(foundProductInOrder);
        CalcTotalPrice(order);
        return foundProductInOrder.SaleList;
    }
    //public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
    //{
    //    List<SaleInProduct> sales = new List<SaleInProduct>();
    //    int count = productInOrder.QuanityInOrder;
    //    foreach(SaleInProduct s in productInOrder.SaleList)
    //    {
    //        if (count == 0)
    //            break;
    //        if (count < s.QuanityForSale)
    //            continue;
    //        else
    //        {
    //            int sum = count / s.QuanityForSale * s.Price;
    //            count= count% s.QuanityForSale;
    //            productInOrder.TotalPrice += sum;
    //            sales.Add(s);
    //        }
    //    }
    //    productInOrder.TotalPrice += count * productInOrder.Price;
    //}

    public void CalcTotalPriceForProduct(BO.ProductInOrder product)
    {
        double totalPrice = product.Price * product.QuanityInOrder;


        foreach (var sale in product.SaleList)
        {
            if (product.QuanityInOrder >= sale.QuanityForSale)
            {
                totalPrice -= sale.Price;
                product.QuanityInOrder -= sale.QuanityForSale;
            }
            if (product.QuanityInOrder == 0) break;
        }

        product.TotalPrice = totalPrice;
    }
    public void CalcTotalPrice(BO.Order order)
    {
        foreach(ProductInOrder p  in order.ProductList)
        {
            CalcTotalPriceForProduct(p);
            order.TotalSum += p.TotalPrice;

        }
           
    }
    public void DoOrder(BO.Order order)
    {
        foreach (ProductInOrder p in order.ProductList)
        {
            BO.Product product = _dal.Product.ReadById(p.ProductId).convert();
            product.Quanity-=p.QuanityInOrder;
            _dal.Product.Update(product.convert());
        }
    }
    //public void SearchSaleForProduct(ProductInOrder product, bool preferredCustomer)
    //{
        
    //    if (preferredCustomer)
    //    {
            
    //        product.SaleList = (List<SaleInProduct>)_dal.Sale.ReadAll(i => i.ProductId == product.ProductId 
    //        && i.BeginDate <= DateTime.Now 
    //        && i.EndDate >= DateTime.Now 
    //        && product.QuanityInOrder >= i.CountForSale)
    //            .Select(i=>new BO.SaleInProduct() {SaleId= i.ProductId,QuanityForSale= i.CountForSale,Price=12,ForAllCustomers= i.ForAllCustomers });
    //    }
    //    product.SaleList=_dal.Sale.ReadAll(i=>i.ProductId==product.ProductId&&i.BeginDate<=DateTime.Now&&i.EndDate>=DateTime.Now&&product.QuanityInOrder>=i.CountForSale&&).
    //}


    public void SearchSaleForProduct(BO.ProductInOrder product, bool isPreferred)
    {
        try
        {
            product.SaleList = _dal.Sale.ReadAll(s => s.ProductId == product.ProductId
            && s.BeginDate <= DateTime.Now && s.EndDate >= DateTime.Now
            && product.QuanityInOrder >= s.CountForSale
            && (isPreferred || s.ForAllCustomers))

                .Select(s => new BO.SaleInProduct() { SaleId = s.ProductId, QuanityForSale = s.CountForSale, ForAllCustomers = s.ForAllCustomers, Price = s.SumSale })
                .OrderBy(s => s.Price)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);


        }
    }
}
