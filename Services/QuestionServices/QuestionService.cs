using AutoMapper;
using Microsoft.EntityFrameworkCore;
using recruitment_app.Data;
using recruitment_app.DTOs.QuestionDTOs;
using recruitment_app.Models;
using recruitment_app.Repositories.LanguageRepository;
using recruitment_app.Repositories.QuestionRepository;

namespace recruitment_app.Services.QuestionServices
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _repository;
        private readonly ILanguageRepository _langRepo;
        private readonly AppDbContext _context;
        public QuestionService(IMapper mapper, IQuestionRepository repository, ILanguageRepository langRepo, AppDbContext context)
        {
            _mapper = mapper;
            _repository = repository;
            _langRepo = langRepo;
            _context = context;
        }
        public async Task<ServiceResponse<GetQuestionDto>> CreateQuestion(CreateQuestionDto request)
        {
            var serviceResponse = new ServiceResponse<GetQuestionDto>();
            try
            {
                var newQuestion = new Question
                {
                    Contents = request.Contents,
                };
                foreach (var language in request.Languages)
                {
                    var existingLanguage = await _langRepo.GetLanguageByName(language.Name);
                    newQuestion.Languages.Add(existingLanguage);
                }

                await _repository.AddQuestion(newQuestion);

                serviceResponse.Data = _mapper.Map<GetQuestionDto>(await _repository.GetQuestionById(newQuestion.Uuid));
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetQuestionDto>> DeleteQuestion(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetQuestionDto>();
            try
            {
                var deletedQuestion = await _repository.DeleteQuestion(id);
                serviceResponse.Data = _mapper.Map<GetQuestionDto>(deletedQuestion);
            }
            catch (ArgumentNullException ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetQuestionDto>> GetQuestion(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetQuestionDto>();
            try
            {
                var question = await _repository.GetQuestionByIdWithLanguages(id);
                serviceResponse.Data = _mapper.Map<GetQuestionDto>(question);
            }
            catch (ArgumentNullException ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetQuestionDto>>> GetQuestions()
        {
            var serviceResponse = new ServiceResponse<List<GetQuestionDto>>
            {
                Data = await _context.Questions.Include(q => q.Languages).Select(q => _mapper.Map<GetQuestionDto>(q)).ToListAsync()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetQuestionDto>> UpdateQuestion(Guid uuid, CreateQuestionDto updatedQuestion)
        {
            var serviceResponse = new ServiceResponse<GetQuestionDto>();
            try
            {
                var existingQuestion = await _repository.GetQuestionByIdWithLanguages(uuid);

                existingQuestion.Languages.Clear();

                foreach (var languageDto in updatedQuestion.Languages)
                {
                    var language = _context.Languages.FirstOrDefault(l => l.Name == languageDto.Name) ?? throw new ArgumentNullException(null, "Language not found.");
                    existingQuestion.Languages.Add(language);
                }

                await _repository.UpdateQuestion(existingQuestion, updatedQuestion);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}
