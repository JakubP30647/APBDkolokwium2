using APBDkolokwium2.Models;

namespace APBDkolokwium2;

using Microsoft.EntityFrameworkCore;



using Microsoft.EntityFrameworkCore;



public class DatabaseContext: DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    
    
    public DatabaseContext(){}
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Artist>().HasData(new List<Artist>()
        {
            new Artist() {ArtistId = 1, FirstName = "James", LastName = "Bond", BirthDate = DateTime.Parse("1989-05-25")},
          
        });

        modelBuilder.Entity<Artwork>().HasData(new List<Artwork>()
        {
            
            new Artwork() {ArtworkId = 1, ArtistId = 1, Title = "Guernica", YearCreated = 1937}
            
            
        });

        modelBuilder.Entity<Exhibition>().HasData(new List<Exhibition>()
        {

            new Exhibition(){ExhibitionId = 1, GalleryId = 1, Ttile = "FAJNY TYTUL", StartDate = DateTime.Parse("1938-09-09"), EndDate = DateTime.Parse("1999-09-09"), NumberOfArtworks = 2}
            
        });

        modelBuilder.Entity<ExhibitionArtwork>().HasData(new List<ExhibitionArtwork>()
        {
            
            new ExhibitionArtwork(){ExhibitionId = 1, ArtworkId = 1, InsuranceValue = 10000.21m}
            
        });

        modelBuilder.Entity<Gallery>().HasData(new List<Gallery>()
        {
            new Gallery() { GalleryId = 1, Name = "modern one", EstablishedDate = DateTime.Parse("1900-08-08") }
        });



    }
}