﻿namespace ateitiesDB.Models
{
    public class GroupHM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<BelongsToGroupHM> BelongsToGroup { get; set;}
    }
}
