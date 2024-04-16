﻿namespace P238MovieApp.Entities
{
    public class Movie: BaseEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
        public double CostPrice { get; set; }
        public Genre Genre { get; set; }
    }
}
