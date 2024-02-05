namespace ateitiesDB.Models
{
    public class BelongsToGroupHM
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PersonHM? Person { get; set; }
        public GroupHM Group { get; set; }
    }
}
