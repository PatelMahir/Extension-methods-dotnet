// ExtensionMethods.cs
namespace WebApi.Extensions
{
    public static class ExtensionMethods
    {
        // Extension method to filter a collection based on a search term
        public static IQueryable<T> FilterBySearchTerm<T>(
            this IQueryable<T> query,
            string searchTerm,
            Func<T, string> propertySelector)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return query;

            return query.Where(item => propertySelector(item)
                .Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        // Extension method to paginate results
        public static IQueryable<T> Paginate<T>(
            this IQueryable<T> query,
            int page,
            int pageSize)
        {
            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        // Extension method to convert string to title case
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
