using Core.DTOs;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DocsGen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// Gets all teachers
        /// </summary>
        /// <returns>An array of teachers</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetTeachers()
        {
            var teachers = await _teacherService.GetAll();

            return teachers.ToList();
        }

        /// <summary>
        /// Gets a specific teacher
        /// </summary>
        /// <param name="id">Teacher id</param>
        /// <returns>A teacher</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeacherDTO>> GetTeacher(int id)
        {
            try
            {
                return await _teacherService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a teacher
        /// </summary>
        /// <param name="teacher">Teacher</param>
        /// <returns>A newly created teacher</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TeacherDTO>> AddTeacher([FromBody, Required]TeacherDTO teacher)
        {
            teacher = await _teacherService.Add(teacher);

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
        }

        /// <summary>
        /// Updates a specific teacher
        /// </summary>
        /// <param name="id">Teacher id</param>
        /// <param name="teacher">Teacher</param>
        /// <returns></returns>
        /// <response code="204">Item has been updated</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="404">Item not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody, Required]TeacherDTO teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            try
            {
                await _teacherService.Update(teacher);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific teacher
        /// </summary>
        /// <param name="id">Teacher id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            try
            {
                await _teacherService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
