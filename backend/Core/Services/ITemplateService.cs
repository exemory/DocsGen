using Core.DTOs;
using Microsoft.AspNetCore.Http;

namespace Core.Services
{
    public interface ITemplateService
    {
        Task<TemplateDTO> SaveTemplate(IFormFile file);
    }
}
