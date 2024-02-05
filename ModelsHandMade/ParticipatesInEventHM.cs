namespace ateitiesDB.Models
{
    public class ParticipatesInEventHM
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public string Position { get; set; }

        public PersonHM? Person { get; set; }
        public EventHM Event { get; set; }
    }
}
