using System.ComponentModel.DataAnnotations;

namespace grF.DTOs;

public class ExhibitionForPost
{
    [Required] public String Title { get; set; }
    [Required] public String Gallery { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
    [Required] public ICollection<ArtworkForPost> Artworks { get; set; }
}

public class ArtworkForPost
{
    [Required] public int ArtworkId { get; set; }
    [Required] public Decimal insuranceValue { get; set; }
}