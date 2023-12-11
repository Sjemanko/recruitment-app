using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using recruitment_app.DTOs;
using recruitment_app.DTOs.LanguageDTOs;
using recruitment_app.Models;
using recruitment_app.Repositories.LanguageRepository;

namespace recruitment_app.Services.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _repository;
        private readonly IMapper _mapper;
        public LanguageService(ILanguageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetLanguageDto>> CreateLanguage(CreateLanguageDto request)
        {
            var serviceResponse = new ServiceResponse<GetLanguageDto>();
            try
            {
                var language = await _repository.GetLanguageByName(request.Name);

                if (language == null)
                {
                    var newLanguage = new Language
                    {
                        Name = request.Name
                    };

                    await _repository.AddLanguage(newLanguage);
                    serviceResponse.Data = _mapper.Map<GetLanguageDto>(newLanguage);
                    serviceResponse.Message = "Language has been created successfully";
                }
                else
                {
                    throw new Exception("Language is already created.");
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLanguageDto>> DeleteLanguage(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetLanguageDto>();
            try
            {
                var deletedLanguage = await _repository.DeleteLanguage(id);
                serviceResponse.Data = _mapper.Map<GetLanguageDto>(deletedLanguage);
                serviceResponse.Message = $"Language has been deleted.";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLanguageDto>> GetLanguage(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetLanguageDto>();
            try
            {
                var language = await _repository.GetLanguageById(id);
                serviceResponse.Data = _mapper.Map<GetLanguageDto>(language);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLanguageDto>>> GetLanguages()
        {
            var serviceResponse = new ServiceResponse<List<GetLanguageDto>>();
            try
            {
                var languages = await _repository.GetLanguages();
                serviceResponse.Data = languages.Select(l => _mapper.Map<GetLanguageDto>(l)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLanguageDto>> UpdateLanguage(Guid id, string updatedLanguage)
        {
            var serviceResponse = new ServiceResponse<GetLanguageDto>();
            try
            {
                var language = await _repository.GetLanguageById(id);
                await _repository.UpdateLanguage(language, updatedLanguage);
                serviceResponse.Data = _mapper.Map<GetLanguageDto>(await _repository.GetLanguageById(language.Uuid));
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