namespace MoviesApp.Entities
{
    public class Casting
    {
        // Comp PK made of the 2 FKs:
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public string? Role { get; set; }

        // nav'n props:
        public Movie? Movie { get; set; }

        public Actor? Actor { get; set; }
    }
}
