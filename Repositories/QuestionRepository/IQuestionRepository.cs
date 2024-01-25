using recruitment_app.DTOs.QuestionDTOs;
using recruitment_app.Models;

namespace recruitment_app.Repositories.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<Question> GetQuestionById(Guid uuid);
        Task AddQuestion(Question entity);
        Task UpdateQuestion(Question question, CreateQuestionDto updatedQuestion);
        Task<Question> DeleteQuestion(Guid uuid);
        Task<List<Question>> GetQuestions();
        Task<Question> GetQuestionByIdWithLanguages(Guid uuid);
    }
}
