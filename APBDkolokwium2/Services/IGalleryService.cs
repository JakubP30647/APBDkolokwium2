using APBDkolokwium2.DTOs;

namespace APBDkolokwium2.Services;

public interface IGalleryService
{
    Task<GalleryForGet> GetGalleries(int id);
}