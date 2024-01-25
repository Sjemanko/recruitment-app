using recruitment_app.DTOs.QuestionDTOs;
using recruitment_app.Models;

namespace recruitment_app.Services.QuestionServices
{
    public interface IQuestionService
    {
        Task<ServiceResponse<List<GetQuestionDto>>> GetQuestions();
        Task<ServiceResponse<GetQuestionDto>> GetQuestion(Guid id);
        Task<ServiceResponse<GetQuestionDto>> UpdateQuestion(Guid id, CreateQuestionDto updatedQuestion);
        Task<ServiceResponse<GetQuestionDto>> DeleteQuestion(Guid id);
        Task<ServiceResponse<GetQuestionDto>> CreateQuestion(CreateQuestionDto request);
    }
}
