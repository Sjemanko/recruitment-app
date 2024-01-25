using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.DTOs.QuestionDTOs;
using recruitment_app.Models;

namespace recruitment_app.Repositories.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddQuestion(Question entity)
        {
            _context.Questions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Question> DeleteQuestion(Guid uuid)
        {
            var question = await GetQuestionById(uuid);
            _context.Remove(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> GetQuestionById(Guid uuid)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Uuid == uuid) ?? throw new Exception("Question not found");
            return question;
        }

        public async Task<Question> GetQuestionByIdWithLanguages(Guid uuid)
        {
            var questionWithLanguages = await _context.Questions.Include(l => l.Languages).FirstOrDefaultAsync(q => q.Uuid == uuid) ?? throw new Exception("Question not found");
            return questionWithLanguages;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;
        }

        public async Task UpdateQuestion(Question question, CreateQuestionDto updatedQuestion)
        {
            _context.Entry(question).CurrentValues.SetValues(updatedQuestion);
            await _context.SaveChangesAsync();
        }
    }
}
