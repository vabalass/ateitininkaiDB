namespace ateitiesDB.Models
{
    public class Pledge
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Association { get; set; }
        public DateTime BadgeDate { get; set; }
        public int? EventId { get; set; }

        public Person Person { get; set; }
        public Event Event { get; set; }
    }
}
