using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P238MovieApp.Entities;

namespace P238MovieApp.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(80);
            builder.Property(m => m.Desc).HasMaxLength(250).IsRequired();
            builder.Property(m => m.CostPrice).IsRequired();
            builder.Property(m => m.Price).IsRequired();


            builder.HasOne(m => m.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(m => m.GenreId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
