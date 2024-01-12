using Microsoft.EntityFrameworkCore;
using Semaine_3__LINQ___Entity_Framework.Models;
using static System.Console;

/*
//1
WriteLine("Enter the city: ");
string? ville = ReadLine();
if (ville != null)
{
    using (NorthwindContext c = new NorthwindContext())
    {
        var customers = from Customer client in c.Customers
                        where client.City == ville
                        select new
                        {
                            client.CustomerId,
                            client.ContactName
                        };

        foreach (var customer in customers)
        {
            Console.WriteLine("{0} : {1}", customer.CustomerId, customer.ContactName);
        }

    }
}
*/

//2

// LAZY LOADING retarde le chargement des données associées à une entité GRACE AU PROXIES QU IL FAUT INSTALLER
/*using (NorthwindContext c = new NorthwindContext())
{

    IQueryable<Category> categories = from Category ca in c.Categories
                                      where ca.CategoryName != null &&
                                         (ca.CategoryName == "Beverages"
                                         || ca.CategoryName == "Condiments")
                                      select ca;

    foreach (var cat in categories)
    {
        WriteLine("Catégorie "+cat.CategoryName);
        foreach(Product product in cat.Products)
        {
            WriteLine(product.ProductName);
        }
    }

}*/
//3
/*WriteLine("EAGER LOADING -- consiste à charger les données associées à une entité en une seule requête");

using (NorthwindContext context = new NorthwindContext())
{
    IQueryable<Category> categories = from Category c in context.Categories.Include("Products")
                                      where c.CategoryName == "Beverages" || c.CategoryName == "Condiments"
                                      select c;
    foreach (Category category in categories)
    {
        WriteLine("Catégorie : " + category.CategoryName);
        foreach (Product p in category.Products)
        {
            WriteLine(p.ProductName);
        }
    }
}*/

//4
/*Write("Enter custumer name: ");
string customer = ReadLine();

if (customer != null)
{
    using (NorthwindContext c = new NorthwindContext())
    {
        var orders = from Order o in c.Orders
                     where (o.CustomerId == customer && o.ShippedDate != null)
                     orderby o.OrderDate descending
                     select new
                     {
                         CustomerId = o.CustomerId,
                         OrderDate = o.OrderDate,
                         ShippedDate = o.ShippedDate,
                     };

        foreach(var o in orders)
        {
            WriteLine(o);
        }

    }
}
*/


//5

/*using (NorthwindContext c = new NorthwindContext())
{
    var totalSells = from OrderDetail o in c.OrderDetails.AsEnumerable()
                     orderby o.ProductId
                     group o by o.OrderId;

    foreach (IGrouping<int, OrderDetail> orderDetails in totalSells)
    {
        WriteLine(orderDetails.Key + "---->" + orderDetails.Sum(o => o.UnitPrice * o.Quantity));
    };
}*/

//6

/*using (NorthwindContext n = new NorthwindContext())
{
    var employees = from Employee e in n.Employees
                    where e.Territories.Any(t => t.Region.RegionDescription.Equals("Western"))
                    select new
                    {
                        FullName = e.FirstName + " " + e.LastName,
                    };

    foreach (var e in employees)
    {
        WriteLine(e.FullName);
    }
}*/

//7
/*using (NorthwindContext n = new NorthwindContext())
{
    var territories = (from Employee e in n.Employees
                       where e.LastName.Equals("Suyama") &&
                       e.FirstName == "Michael"
                       select e.ReportsToNavigation.Territories).SingleOrDefault();

    foreach (Territory t in territories)
    {
        WriteLine(t.TerritoryDescription);
    }
};*/

//MAJUSCULE
/*WriteLine("Majuscule");

using (NorthwindContext context = new NorthwindContext())
{
    IQueryable<Customer> custom = from Customer c in context.Customers
                                  select c;

    foreach (Customer customer in custom)
    {
        customer.ContactName = customer.ContactName.ToUpper();
    }
    try
    {
        context.SaveChanges();
    }
    catch (Exception e)
    {
        WriteLine("Erreur {0}", e.Message);
    }
    WriteLine("Done");
}

//INSERT
WriteLine("INSERT CATEGORY: ");
string? category = ReadLine();
try
{

    using (NorthwindContext context = new NorthwindContext())
    {
        Category? cat = (from c in context.Categories
                         where c.CategoryName == category
                         select c).SingleOrDefault<Category>();


        if (cat == null && category != null)
        {
            cat = new Category { CategoryName = category, Description="BEAUTIFULLLLLLL" };
            context.Categories.Add(cat);
            context.SaveChanges();
            WriteLine("Done");
        }
        else
        {
            WriteLine("Cette catégorie existe déjà");
        }
    }
}
catch (Exception e)
{
    WriteLine(e);
}*/

// DELETE
WriteLine("DELETE");

try
{
    using (NorthwindContext context = new NorthwindContext())
    {
        WriteLine("Catégorie à supprimer : ");
        string? category = ReadLine();

        Category cat = (from c in context.Categories
                        where c.CategoryName == category
                        select c).First<Category>();

        context.Categories.Remove(cat);
        context.SaveChanges();
        WriteLine("Done");

    }
}
catch (Exception e)
{
    WriteLine(e);
}

