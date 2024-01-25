using recruitment_app.Models;

namespace recruitment_app.Repositories.LanguageRepository
{
    public interface ILanguageRepository
    {
        Task<Language> GetLanguageById(Guid uuid);
        Task AddLanguage(Language entity);
        Task UpdateLanguage(Language language, string updatedEntity);
        Task<Language> DeleteLanguage(Guid uuid);
        Task<List<Language>> GetLanguages();
        Task<Language?> GetLanguageByName(string name);
    }
}