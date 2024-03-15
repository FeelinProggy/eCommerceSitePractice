namespace eCommerceSitePractice.Models
{
    public class CatalogViewModel
    {
        public CatalogViewModel(List<Product> products, int lastPageNumber, int currentPageNumber)
        {
            Products = products;
            LastPageNumber = lastPageNumber;
            CurrentPageNumber = currentPageNumber;
        }

        public List<Product> Products { get; private set; }

        // Last page of the catalog. Calculated by dividing the total
        // number of products by the page size and rounding up to ceiling.
        public int LastPageNumber { get; private set; }

        // Current page number of the being viewed
        public int CurrentPageNumber { get; private set; }
    }
}
