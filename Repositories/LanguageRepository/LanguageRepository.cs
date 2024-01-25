using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.Models;

namespace recruitment_app.Repositories.LanguageRepository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _context;
        public LanguageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddLanguage(Language entity)
        {
            _context.Languages.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Language> DeleteLanguage(Guid uuid)
        {
            var language = await GetLanguageById(uuid);
            _context.Remove(language);
            await _context.SaveChangesAsync();
            return language;
        }

        public async Task<Language> GetLanguageById(Guid uuid)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(l => l.Uuid == uuid) ?? throw new Exception("Language not found");
            return language;
        }

        public async Task<List<Language>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task UpdateLanguage(Language language, string updatedEntity)
        {
            language.Name = updatedEntity;
            await _context.SaveChangesAsync();
        }

        public async Task<Language?> GetLanguageByName(string name)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(l => l.Name == name) ?? throw new Exception("Language not found");
            return language;
        }
    }
}