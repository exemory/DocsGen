﻿using Core.DTOs;
using Microsoft.AspNetCore.Http;

namespace Core.Services
{
    public interface ITemplateService
    {
        Task<TemplateDTO> Save(IFormFile file);
    }
}
