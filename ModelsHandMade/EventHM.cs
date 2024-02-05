namespace ateitiesDB.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Pledge>? Pledges { get; set; }
        public ICollection<ParticipatesInEvent> ParticipatesInEvent { get; set;}
    }
}
