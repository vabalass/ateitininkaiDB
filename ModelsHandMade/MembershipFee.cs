namespace ateitiesDB.Models
{
    public class MembershipFee
    {
        public int PaymentId { get; set; }
        public int PersonId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Person Person { get; set; }
    }
}
