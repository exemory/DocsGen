using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Service.Models;

namespace Service.Services
{
    public class TemplateService : EntityService<Template, TemplateDTO>, ITemplateService
    {
        private readonly IConfiguration _config;

        private string ValidExtension => _config["Template:ValidExtension"];

        public TemplateService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
            : base(unitOfWork, mapper)
        {
            _config = config;
        }

        public async Task<TemplateDTO> Save(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (file.Length == 0)
            {
                throw new TemplateException("File is empty");
            }

            if (fileExtension != ValidExtension)
            {
                throw new TemplateException($"File extension must be '{ValidExtension}'");
            }

            Template template;

            await using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                WordTemplate.CheckTemplateFile(stream);

                template = new Template
                {
                    UploadDate = DateTime.UtcNow,
                    Content = stream.ToArray()
                };
            }

            UnitOfWork.Templates.Add(template);
            await UnitOfWork.Save();

            var dto = MapToDTO(template);
            return dto;
        }
    }
}