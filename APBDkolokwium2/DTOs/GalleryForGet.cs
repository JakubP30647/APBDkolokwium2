namespace APBDkolokwium2.DTOs;

public class GalleryForGet
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public ICollection<ExhibitionForGet> Exhibitions { get; set; }
}

public class ExhibitionForGet
{
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public ICollection<ArtworkForGet> Artworks { get; set; }
}

public class ArtworkForGet
{
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public Decimal InsuranceValue { get; set; }
    public ArtistForGet Artist { get; set; }
}

public class ArtistForGet
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
}