using Microsoft.AspNetCore.Mvc;
using recruitment_app.DTOs;
using recruitment_app.DTOs.QuestionDTOs;
using recruitment_app.Models;
using recruitment_app.Services.QuestionServices;

namespace recruitment_app.Controllers.LangaugesControllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionsService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionsService = questionService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> CreateQuestion(CreateQuestionDto request)
        {
            var serviceResponse = await _questionsService.CreateQuestion(request);
            if (serviceResponse.Success == false)
            {
                return Conflict(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetQuestionDto>>>> GetQuestions()
        {
            var serviceResponse = await _questionsService.GetQuestions();
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetQuestionDto>>> GetQuestion(Guid id)
        {
            var serviceResponse = await _questionsService.GetQuestion(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetQuestionDto>>> DeleteQuestion(Guid id)
        {
            var serviceResponse = await _questionsService.DeleteQuestion(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetQuestionDto>>> UpdateQuestion(Guid id, CreateQuestionDto updatedLanguage)
        {
            var serviceResponse = await _questionsService.UpdateQuestion(id, updatedLanguage);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}