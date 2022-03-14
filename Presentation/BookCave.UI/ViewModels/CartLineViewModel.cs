namespace BookCave.UI.ViewModels
{
    public class CartLineViewModel
    {
        public int CartLineId { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUri { get; set; }
        public string AuthorName { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}