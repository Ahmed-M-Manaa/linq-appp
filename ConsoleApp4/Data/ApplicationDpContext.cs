using ConsoleApp4.Data;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDpContext _context = new ApplicationDpContext();


            var customers = _context.Customers
    .Select(c => new { c.FirstName, c.LastName, c.Email })
    .ToList();
            var orders = _context.Orders
    .Where(o => o.StaffId == 3)
    .ToList();
            var products = _context.Products
    .Where(p => p.Category.CategoryName == "Mountain Bikes")
    .ToList();
            var ordersPerStore = _context.Orders
    .GroupBy(o => o.StoreId)
    .Select(g => new { StoreId = g.Key, TotalOrders = g.Count() })
    .ToList();
            var unshippedOrders = _context.Orders
    .Where(o => o.ShippedDate == null)
    .ToList();
            var customerOrders = _context.Customers
    .Select(c => new {
        FullName = c.FirstName + " " + c.LastName,
        TotalOrders = c.Orders.Count()
    })
    .ToList();
            var unboughtProducts = _context.Products
    .Where(p => !p.OrderItems.Any())
    .ToList();
            var lowStockProducts = _context.Stocks
    .Where(s => s.Quantity < 5)
    .Select(s => s.Product)
    .Distinct()
    .ToList();
            var firstProduct = _context.Products
    .FirstOrDefault();
            var productsByYear = _context.Products
    .Where(p => p.ModelYear == 2024)
    .ToList();
            var productOrderCounts = _context.Products
    .Select(p => new {
        p.ProductName,
        OrderCount = p.OrderItems.Count()
    })
    .ToList();
            var productCount = _context.Products
    .Count(p => p.CategoryId == 1);
            var averagePrice = _context.Products
    .Average(p => p.ListPrice);
            var product = _context.Products
    .FirstOrDefault(p => p.ProductId == 10);
            // Or simply: var product = _context.Products.Find(10);
            var bulkyOrderProducts = _context.OrderItems
    .Where(oi => oi.Quantity > 3)
    .Select(oi => oi.Product)
    .Distinct()
    .ToList();
            var staffOrderSummary = _context.Staff
    .Select(s => new {
        StaffName = s.FirstName + " " + s.LastName,
        TotalOrders = s.Orders.Count()
    })
    .ToList();
            var staffOrderSummary = _context.Staff
    .Select(s => new {
        StaffName = s.FirstName + " " + s.LastName,
        TotalOrders = s.Orders.Count()
    })
    .ToList();
            var activeStaff = _context.Staff
    .Where(s => s.Active == 1) // Use s.Active == true if it's a bool
    .Select(s => new { s.FirstName, s.LastName, s.Phone })
    .ToList();
            var productDetails = _context.Products
    .Select(p => new {
        p.ProductName,
        BrandName = p.Brand.BrandName,
        CategoryName = p.Category.CategoryName
    })
    .ToList();
            var completedOrders = _context.Orders
    .Where(o => o.OrderStatus == 4)
    .ToList();
            var productSales = _context.Products
    .Select(p => new {
        p.ProductName,
        TotalQuantitySold = p.OrderItems.Sum(oi => (int?)oi.Quantity) ?? 0
    })
    .ToList();

        }
    }
}