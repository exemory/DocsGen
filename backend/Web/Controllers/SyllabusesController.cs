using Core.DTOs;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DocsGen.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SyllabusesController : ControllerBase
    {
        private readonly ISyllabusService _syllabusService;

        public SyllabusesController(ISyllabusService syllabusService)
        {
            _syllabusService = syllabusService;
        }

        /// <summary>
        /// Gets all syllabuses
        /// </summary>
        /// <returns>An array of syllabuses</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SyllabusDTO>>> GetSyllabuses()
        {
            var syllabuses = await _syllabusService.GetAll();

            return syllabuses.ToList();
        }

        /// <summary>
        /// Gets a specific syllabus
        /// </summary>
        /// <param name="id">Syllabus id</param>
        /// <returns>A syllabus</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SyllabusDTO>> GetSyllabus(int id)
        {
            try
            {
                return await _syllabusService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a syllabus
        /// </summary>
        /// <param name="syllabus">Syllabus</param>
        /// <returns>A newly created syllabus</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SyllabusDTO>> AddSyllabus([FromBody, Required]SyllabusDTO syllabus)
        {
            syllabus = await _syllabusService.Add(syllabus);

            return CreatedAtAction(nameof(GetSyllabus), new { id = syllabus.Id }, syllabus);
        }

        /// <summary>
        /// Updates a specific syllabus
        /// </summary>
        /// <param name="id">Syllabus id</param>
        /// <param name="syllabus">Syllabus</param>
        /// <returns></returns>
        /// <response code="204">Item has been updated</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="404">Item not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSyllabus(int id, [FromBody, Required]SyllabusDTO syllabus)
        {
            if (id != syllabus.Id)
            {
                return BadRequest();
            }

            try
            {
                await _syllabusService.Update(syllabus);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific syllabus
        /// </summary>
        /// <param name="id">Syllabus id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSyllabus(int id)
        {
            try
            {
                await _syllabusService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
