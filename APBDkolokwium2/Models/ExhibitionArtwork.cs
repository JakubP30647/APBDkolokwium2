using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBDkolokwium2.Models;

[Table("Exhibition_Artwork")]
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
public class ExhibitionArtwork
{
    [ForeignKey(nameof(ExhibitionId))] public int ExhibitionId { get; set; }
    [ForeignKey(nameof(ArtworkId))] public int ArtworkId { get; set; }
    [Precision(10, 2)] public decimal InsuranceValue { get; set; }
    
    public Exhibition Exhibition { get; set; }
    public Artwork Artwork { get; set; }
    
}