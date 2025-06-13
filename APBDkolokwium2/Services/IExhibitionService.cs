using APBDkolokwium2.DTOs;
using grF.DTOs;

namespace APBDkolokwium2.Services;

public interface IExhibitionService
{
    
    Task PostExhibition(ExhibitionForPost exhibitionForPost);
    
}