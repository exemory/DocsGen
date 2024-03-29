﻿using Core.DTOs;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templates;

        public TemplatesController(ITemplateService templates)
        {
            _templates = templates;
        }

        /// <summary>
        /// Uploads a template file
        /// </summary>
        /// <param name="file">Template file in docx format</param>
        /// <returns>Template id</returns>
        /// <response code="200">Returns the id of uploaded template</response>
        /// <response code="400">Validation error</response>
        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TemplateDTO>> Upload(IFormFile file)
        {
            try
            {
                return await _templates.Save(file);
            }
            catch (TemplateException ex)
            {
                ModelState.AddModelError(file.Name, ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
