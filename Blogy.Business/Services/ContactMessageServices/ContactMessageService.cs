using AutoMapper;
using Blogy.Business.DTOs.ContactMessageDtos;
using Blogy.DataAccess.Repositories.ContactMessageRepositories;
using Blogy.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.ContactMessageServices
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _contactMessageRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ContactMessage> _validator;

        public ContactMessageService(IContactMessageRepository contactMessageRepository, IMapper mapper, IValidator<ContactMessage> validator)
        {
            _contactMessageRepository = contactMessageRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task CreateAsync(CreateContactMessageDto createContactMessage)
        {
            var value = _mapper.Map<ContactMessage>(createContactMessage);
            var result = await _validator.ValidateAsync(value);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _contactMessageRepository.CreateAsync(value);
        }

        public async Task<List<ResultContactMessageDto>> GetAllAsync()
        {
           var values = await _contactMessageRepository.GetAllAsync();
            return _mapper.Map<List<ResultContactMessageDto>>(values);
        }
    }
}
