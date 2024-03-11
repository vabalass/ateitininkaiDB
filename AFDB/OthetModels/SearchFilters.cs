namespace AFDB.OthetModels
{
    public class SearchFilters
    {
        public string? SearchField { get; set; }

        public string? MembershipStatus { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
    }
}
