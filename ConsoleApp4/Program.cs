using ConsoleApp4.Data;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDpContext _Context = new ApplicationDpContext();


            //var cusstomers = _Context.Customers.AsQueryable();
            //  var customers = _Context.Customers.AsQueryable();
            //customers = customers.Where(c => c.CustomerId ==1);



            //foreach (var customer in customers)
            //{
            //    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
            //}


            var Orders = _Context.Orders.Join(
                _Context.Customers,
                o => o.CustomerId,
                 c => c.CustomerId,
                (o, c) => new
                {


                    o,
                    c

                    //o.OrderId,
                    //c.FirstName,
                    //c.LastName,
                    //o.OrderDate,
                    //o.
                }).Join(
                _Context.Stores,
                oc => oc.o.StoreId,
                s => s.StoreId,
                (oc, s) => new
                {
                    oc.o.OrderId,
                 customername=    oc.c.FirstName,
                 customerlastname =   oc.c.LastName,
                 oc.o.OrderDate,
                    s.StoreName,
                }

                );
                
                
            foreach(var items in Orders)
            {
                Console.WriteLine($"orderid={items.OrderId}, Customer: {items.customername } {items.customerlastname}, Order Date: {items.OrderDate}, Store: {items.StoreName}");
            }




        }
    }
}
