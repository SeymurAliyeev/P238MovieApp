﻿using P238MovieApp.Entities;

namespace P238MovieApp.DTOs.MovieDTOs
{
    public class MovieGetAllDto
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
    }
}
