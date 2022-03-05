using System.ComponentModel.DataAnnotations;
using Core.DTOs;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Services;

namespace Web.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;
    
    public DocumentsController(IDocumentService documentService)
    {
        _documentService = documentService;
    }
    
    /// <summary>
    /// Generates curricula files and compresses them to zip archive
    /// </summary>
    /// <param name="genDocsData">Data for generation curricula</param>
    /// <returns>Zip archive of curricula</returns>
    /// <response code="200">Returns the zip archive of curricula</response>
    /// <response code="400">Data in not valid</response>
    [HttpPost("generate/curricula")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Generate([FromBody, Required]GenerateCurriculaDTO genDocsData)
    {
        try
        {
            var curriculaArchive = await _documentService.GenerateCurriculaArchive(genDocsData);
            return File(curriculaArchive, "application/octet-stream", "Навчальні_програми.zip");
        }
        catch (TemplateException ex)
        {
            ModelState.AddModelError("template", ex.Message);
            return BadRequest(ModelState);
        }
    }
}