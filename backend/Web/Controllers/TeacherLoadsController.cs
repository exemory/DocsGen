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
    public class TeacherLoadsController : ControllerBase
    {
        private readonly ITeacherLoadService _teacherLoadService;

        public TeacherLoadsController(ITeacherLoadService teacherLoadService)
        {
            _teacherLoadService = teacherLoadService;
        }

        /// <summary>
        /// Gets all teacher loads
        /// </summary>
        /// <returns>An array of teacher loads</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TeacherLoadDTO>>> GetTeacherLoads()
        {
            var teacherLoads = await _teacherLoadService.GetAll();

            return teacherLoads.ToList();
        }

        /// <summary>
        /// Gets a specific teacher load
        /// </summary>
        /// <param name="id">Teacher load id</param>
        /// <returns>A teacher load</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeacherLoadDTO>> GetTeacherLoad(int id)
        {
            try
            {
                return await _teacherLoadService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a teacher load
        /// </summary>
        /// <param name="teacherLoad">TeacherLoad</param>
        /// <returns>A newly created teacher load</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="409">Unique constraint or key relation violation</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<TeacherLoadDTO>> AddTeacherLoad([FromBody, Required]TeacherLoadDTO teacherLoad)
        {
            try
            {
                teacherLoad = await _teacherLoadService.Add(teacherLoad);
            }
            catch (EntityConflictException)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetTeacherLoad), new { id = teacherLoad.Id }, teacherLoad);
        }

        /// <summary>
        /// Updates a specific teacher load
        /// </summary>
        /// <param name="id">Teacher load id</param>
        /// <param name="teacherLoad">TeacherLoad</param>
        /// <returns></returns>
        /// <response code="204">Item has been updated</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="404">Item not found</response>
        /// <response code="409">Unique constraint or key relation violation</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateTeacherLoad(int id, [FromBody, Required]TeacherLoadDTO teacherLoad)
        {
            if (id != teacherLoad.Id)
            {
                return BadRequest();
            }

            try
            {
                await _teacherLoadService.Update(teacherLoad);
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
        /// Deletes a specific teacher load
        /// </summary>
        /// <param name="id">Teacher load id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTeacherLoad(int id)
        {
            try
            {
                await _teacherLoadService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
