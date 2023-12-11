using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitment_app.DTOs;
using recruitment_app.DTOs.LanguageDTOs;
using recruitment_app.Models;
using recruitment_app.Services.LanguageServices;

namespace recruitment_app.Controllers.LangaugesControllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> CreateLanguage(CreateLanguageDto request)
        {
            var serviceResponse = await _languageService.CreateLanguage(request);
            if (serviceResponse.Success == false)
            {
                return Conflict(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetLanguageDto>>>> GetLanguages()
        {
            var serviceResponse = await _languageService.GetLanguages();
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> GetLanguage(Guid id)
        {
            var serviceResponse = await _languageService.GetLanguage(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> DeleteLanguage(Guid id)
        {
            var serviceResponse = await _languageService.DeleteLanguage(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> UpdateLanguage(Guid id, string updatedLanguage)
        {
            var serviceResponse = await _languageService.UpdateLanguage(id, updatedLanguage);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}