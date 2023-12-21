namespace ateitiesDB.DtoModels
{
    public class PersonDto
    { 
        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Country { get; set; }

        public string? Description { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? House { get; set; }

        public string? Apartment { get; set; }
    }
}
