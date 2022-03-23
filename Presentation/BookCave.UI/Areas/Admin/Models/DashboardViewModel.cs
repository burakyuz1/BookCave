namespace BookCave.UI.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int TotalUser { get; set; }
        public int TotalBookCount { get; set; }
        public decimal TotalIncome { get; set; }
        public int TotalAuthor { get; set; }
        public int TotaLPublisher { get; set; }
        public int TotalCategory { get; set; }
        public int TotalOrder { get; set; }
        public int TotalOrderToday { get; set; }
    }
}
