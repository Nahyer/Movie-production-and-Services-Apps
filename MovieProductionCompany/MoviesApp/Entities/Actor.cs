namespace MoviesApp.Entities
{
    public class Actor
    {
        // PK:
        public int ActorId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        // Casting nav'g prop:
        public ICollection<Casting>? Castings { get; set; }
    }
}
