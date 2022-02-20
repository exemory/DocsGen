using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Service.Services
{
    public class TemplateService : EntityService<Template, TemplateDTO>, ITemplateService
    {
        private readonly IConfiguration _config;

        private string _validExtension => _config["Template:ValidExtension"];

        public TemplateService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
            : base(unitOfWork, mapper)
        {
            _config = config;
        }

        public async Task<TemplateDTO> SaveTemplate(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (file.Length == 0)
            {
                throw new TemplateException("File is empty");
            }

            if (fileExtension != _validExtension)
            {
                throw new TemplateException($"File extension must be '{_validExtension}'");
            }

            Template template;

            await using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                template = new Template
                {
                    UploadDate = DateTime.UtcNow,
                    Content = stream.ToArray()
                };
            }

            _unitOfWork.Templates.Add(template);
            await _unitOfWork.Save();

            var dto = MapToDTO(template);
            return dto;
        }
    }
}