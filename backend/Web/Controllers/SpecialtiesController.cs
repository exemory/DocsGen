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
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtiesController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        /// <summary>
        /// Gets all specialties
        /// </summary>
        /// <param name="branchId">Filter specialties by specified knowledge branch id</param>
        /// <returns>An array of specialties</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SpecialtyDTO>>> GetSpecialties([FromQuery(Name = "branch-id")]int? branchId)
        {
            IEnumerable<SpecialtyDTO> specialties;

            if (branchId == null)
            {
                specialties = await _specialtyService.GetAll();
            }
            else
            {
                specialties = await _specialtyService.GetAllByBranch(branchId.Value);
            }

            return specialties.ToList();
        }

        /// <summary>
        /// Gets a specific specialty
        /// </summary>
        /// <param name="id">Specialty id</param>
        /// <returns>A specialty</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SpecialtyDTO>> GetSpecialty(int id)
        {
            try
            {
                return await _specialtyService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a specialty
        /// </summary>
        /// <param name="specialty">Specialty</param>
        /// <returns>A newly created specialty</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="409">Unique constraint or key relation violation</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<SpecialtyDTO>> AddSpecialty([FromBody, Required]SpecialtyDTO specialty)
        {
            try
            {
                specialty = await _specialtyService.Add(specialty);
            }
            catch (EntityConflictException)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetSpecialty), new { id = specialty.Id }, specialty);
        }

        /// <summary>
        /// Updates a specific specialty
        /// </summary>
        /// <param name="id">Specialty id</param>
        /// <param name="specialty">Specialty</param>
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
        public async Task<IActionResult> UpdateSpecialty(int id, [FromBody, Required]SpecialtyDTO specialty)
        {
            if (id != specialty.Id)
            {
                return BadRequest();
            }

            try
            {
                await _specialtyService.Update(specialty);
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
        /// Deletes a specific specialty
        /// </summary>
        /// <param name="id">Specialty id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            try
            {
                await _specialtyService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
