// Example usage in controller or service
var products = _context.Products
    .FilterBySearchTerm("phone", p => p.Name)
    .Paginate(1, 10)
    .ToList();

string category = "electronics".ToTitleCase(); // Returns "Electronics"
