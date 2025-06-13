using apbd_kolowium2.Exceptions;
using APBDkolokwium2.DTOs;
using APBDkolokwium2.Models;
using grF.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBDkolokwium2.Services;

public class ExhibitionService : IExhibitionService
{
    
    
    private readonly DatabaseContext _context;

    public ExhibitionService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task PostExhibition(ExhibitionForPost exhibitionForPost)
    {
        
        using var transaction  = await _context.Database.BeginTransactionAsync();

        try
        {

            if (exhibitionForPost.Title == null || exhibitionForPost.Gallery == null || exhibitionForPost.StartDate == null)
            {
                throw new ConflictException("Nieprawidłowe Dane");
            }
            
            
            
            var gallery =  _context.Galleries
                .FirstOrDefault(g => g.Name.Equals(exhibitionForPost.Gallery));

            if (gallery == null)
            {
                throw new NotFoundException("Gallery not found");
            }

            var newExhibition = new Exhibition()
            {

                GalleryId = gallery.GalleryId,
                Ttile = exhibitionForPost.Title,
                StartDate = exhibitionForPost.StartDate,
                EndDate = exhibitionForPost.EndDate,
                NumberOfArtworks = exhibitionForPost.Artworks.Count,
                
            };
            
            await _context.Exhibitions.AddAsync(newExhibition);
            await _context.SaveChangesAsync();


            foreach (var a in exhibitionForPost.Artworks)
            {
                var artwork = _context.Artworks
                    .FirstOrDefault(ar => ar.ArtworkId == a.ArtworkId);
               
                if (artwork == null)
                {
                    throw new NotFoundException("Artwork o takim id nie istnieje");
                }

                var newExhibtionArtwork = new ExhibitionArtwork()
                {
                    
                    ExhibitionId = newExhibition.ExhibitionId,
                    ArtworkId = artwork.ArtworkId,
                    InsuranceValue = a.insuranceValue
                    
                };
                
                await _context.ExhibitionArtworks.AddAsync(newExhibtionArtwork);
                await _context.SaveChangesAsync();

            }
            
            
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
        
        
        
    }
}