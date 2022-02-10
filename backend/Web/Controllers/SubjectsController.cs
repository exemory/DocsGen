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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// Gets all subjects
        /// </summary>
        /// <returns>An array of subjects</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetSubjects()
        {
            var subjects = await _subjectService.GetAll();

            return subjects.ToList();
        }

        /// <summary>
        /// Gets a specific subject
        /// </summary>
        /// <param name="id">Subject id</param>
        /// <returns>A subject</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubjectDTO>> GetSubject(int id)
        {
            try
            {
                return await _subjectService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a subject
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <returns>A newly created subject</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="409">Unique constraint violation</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<SubjectDTO>> AddSubject([FromBody, Required]SubjectDTO subject)
        {
            try
            {
                subject = await _subjectService.Add(subject);
            }
            catch (EntityConflictException)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subject);
        }

        /// <summary>
        /// Updates a specific subject
        /// </summary>
        /// <param name="id">Subject id</param>
        /// <param name="subject">Subject</param>
        /// <returns></returns>
        /// <response code="204">Item has been updated</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="404">Item not found</response>
        /// <response code="409">Unique constraint violation</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody, Required]SubjectDTO subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            try
            {
                await _subjectService.Update(subject);
            }
            catch (EntityConflictException)
            {
                return Conflict();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific subject
        /// </summary>
        /// <param name="id">Subject id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                await _subjectService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
