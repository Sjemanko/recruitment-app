using recruitment_app.DTOs;
using recruitment_app.DTOs.LanguageDTOs;
using recruitment_app.Models;

namespace recruitment_app.Services.LanguageServices
{
    public interface ILanguageService
    {
        Task<ServiceResponse<List<GetLanguageDto>>> GetLanguages();
        Task<ServiceResponse<GetLanguageDto>> GetLanguage(Guid id);
        Task<ServiceResponse<GetLanguageDto>> UpdateLanguage(Guid id, string updatedLanguage);
        Task<ServiceResponse<GetLanguageDto>> DeleteLanguage(Guid id);
        Task<ServiceResponse<GetLanguageDto>> CreateLanguage(CreateLanguageDto request);
    }
}