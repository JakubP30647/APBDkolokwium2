using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grF.Models;
[Table("Exhibition")]
public class Exhibition
{
    
    [Key] public int ExhibitionId { get; set; }
    [ForeignKey(nameof(GalleryId))] public int GalleryId { get; set; }
    [MaxLength(100)]public string Ttile { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    
    ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    
}