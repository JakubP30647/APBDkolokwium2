using apbd_kolowium2.Exceptions;
using APBDkolokwium2.DTOs;
using APBDkolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDkolokwium2.Services;

public class GalleryService : IGalleryService
{
    private readonly DatabaseContext _context;

    public GalleryService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task<GalleryForGet> GetGalleries(int id)
    {
        var gallery = await _context.Galleries.Where(g => g.GalleryId == id).Select(g => new GalleryForGet
        {
            GalleryId = g.GalleryId,
            Name = g.Name,
            EstablishedDate = g.EstablishedDate,
            Exhibitions = _context.Exhibitions.Where(ex => ex.GalleryId == g.GalleryId)
                .Select(ex => new ExhibitionForGet()
                {
                    Title = ex.Ttile,
                    StartDate = ex.StartDate,
                    EndDate = ex.EndDate,
                    NumberOfArtworks = ex.NumberOfArtworks,
                    Artworks = _context.ExhibitionArtworks.Where(ea => ea.ExhibitionId == ex.ExhibitionId)
                        .Select(ea => new ArtworkForGet()
                        {
                            Title = ea.Artwork.Title,

                            YearCreated = ea.Artwork.YearCreated,

                            InsuranceValue = ea.InsuranceValue,

                            Artist = new ArtistForGet()
                            {
                                FirstName = ea.Artwork.Artist.FirstName,
                                LastName = ea.Artwork.Artist.LastName,
                                BirthDate = ea.Artwork.Artist.BirthDate,
                            },
                        }).ToList()
                }).ToList(),
        }).FirstOrDefaultAsync();



        if (gallery == null)
        {
            throw new NotFoundException("Gallery not found");
        }
        

        return gallery;
    }
}