﻿namespace MoviesApp.Entities
{
    public class Genre
    {
        // Note: because we are using a string for PK it will NOT
        // be auto-generated by the DB - i.e. we will have to specify ourselves.
        public string GenreId { get; set; }
        public string Name { get; set; }
    }
}
