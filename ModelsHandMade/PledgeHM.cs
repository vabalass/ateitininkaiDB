namespace ateitiesDB.Models
{
    public class PledgeHM
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Association { get; set; }
        public DateTime BadgeDate { get; set; }
        public int? EventId { get; set; }

        public PersonHM Person { get; set; }
        public EventHM Event { get; set; }
    }
}
