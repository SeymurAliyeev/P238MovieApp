namespace P238MovieApp.DTOs.MovieDTOs
{
    public class MovieCreateDto
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool IsDeleted { get; set; }
        public double CostPrice { get; set; }
        public double Price { get; set; }
    }
}
