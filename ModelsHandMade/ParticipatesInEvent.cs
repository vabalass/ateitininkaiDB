namespace ateitiesDB.Models
{
    public class ParticipatesInEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public string Position { get; set; }

        public Person? Person { get; set; }
        public Event Event { get; set; }
    }
}
