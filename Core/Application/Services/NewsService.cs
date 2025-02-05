using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using DTOs;
using DTOs.News;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NewsService> _logger;

        public NewsService(
         INewsRepository newsRepository,
         IMapper mapper,
         ILogger<NewsService> logger)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<List<GetNewsDto>>> GetNews()
        {
            var serviceResponse = new ServiceResponse<List<GetNewsDto>>();

            try
            {
                serviceResponse.Data = await _newsRepository.GetNews();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> AddNews(UpdateNewsDto obj, int authorityId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var newObj = _mapper.Map<News>(obj);
                newObj.AuthorityId = authorityId;
                newObj.CreationDate = DateOnly.FromDateTime(DateTime.Today);
                await _newsRepository.AddAsync(newObj);
                await _newsRepository.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Message = "Success.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNewsDto?>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetNewsDto?>();

            try
            {
                serviceResponse.Data = await _newsRepository.GetById(id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> UpdateNews(UpdateNewsDto obj, int objId, int authorityId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var dbObj = await _newsRepository.GetByIdAsync(objId, authorityId);

                if (dbObj == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"News with id {objId} is not available to update.";
                    return serviceResponse;
                }

                _mapper.Map(obj, dbObj);
                await _newsRepository.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Message = "Success";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteNews(int id, int authorityId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                bool result = await _newsRepository.DeleteNews(id, authorityId);

                if (!result)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"News with id {id} is not available to delete,";
                    return serviceResponse;
                }

                await _newsRepository.SaveChangesAsync();
                serviceResponse.Data = true;
                serviceResponse.Message = "Success";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }
    }
}
