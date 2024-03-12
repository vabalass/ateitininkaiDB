namespace AFDB.OthetModels
{
    public class SearchFilters
    {
        public SearchFilters() 
        {
            DateFrom = new DateOnly(1950, 1, 1);
            DateTo = DateOnly.FromDateTime(DateTime.Today);
        }
        public string? SearchField { get; set; }
        public string? MembershipStatus { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
    }
}
