using AutoMapper;
using Microsoft.Extensions.Logging;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<TagService> _logger;
        public TagService(ITagRepository tagRepository, IMapper mapper, IUoW unitOfWork, ILogger<TagService> logger)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            try
            {
                var tags = await _tagRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<TagDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Tag>, List<TagDTO>>(tags));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> Save(TagDTO tagDTO, CancellationToken cancellationToken)
        {
            try
            {
                var tag = _mapper.Map<Tag>(tagDTO);

                var obj = await _tagRepository.AddAsync(tag, cancellationToken);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<TagDTO>((int)HttpStatusCode.Created, _mapper.Map<TagDTO>(obj));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "An error occurred in the tag registration flow", ex, ex.StackTrace ?? "");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _tagRepository.DeleteAsync(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(TagDTO tag, CancellationToken cancellationToken)
        {
            try
            {
                await _tagRepository.UpdateAsync(_mapper.Map<TagDTO, Tag>(tag), cancellationToken);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<ResponseBase> GetEntity(Guid id, CancellationToken cancellationToken)
        {
            var categoy = await _tagRepository.GetByIdAsync(id, cancellationToken);

            if (categoy is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<TagDTO>((int)HttpStatusCode.OK, _mapper.Map<TagDTO>(categoy));
        }
    }
}
