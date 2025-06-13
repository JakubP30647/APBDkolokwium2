using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDkolokwium2.Models;

[Table("Artwork")]
public class Artwork
{
    [Key] public int ArtworkId { get; set; }
    [ForeignKey(nameof(ArtistId))] public int ArtistId { get; set; }
    [MaxLength(100)] public string Title { get; set; }
    public int YearCreated { get; set; }
    
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public Artist Artist { get; set; }
}