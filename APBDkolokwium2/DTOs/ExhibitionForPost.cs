using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace grF.DTOs;

public class ExhibitionForPost
{
    [Required] [MaxLength(100)]public String Title { get; set; }
    [Required] [MaxLength(50)]public String Gallery { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime? EndDate { get; set; }
    [Required] public ICollection<ArtworkForPost> Artworks { get; set; }
}

public class ArtworkForPost
{
    [Required] public int ArtworkId { get; set; }
    [Required][Precision(10,2)] public Decimal insuranceValue { get; set; }
}