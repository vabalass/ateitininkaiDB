namespace ateitiesDB.Models
{
    public class BelongsToGroup
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Person? Person { get; set; }
        public Group Group { get; set; }
    }
}
