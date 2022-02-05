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
    public class GuarantorsController : ControllerBase
    {
        private readonly IGuarantorService _guarantorService;

        public GuarantorsController(IGuarantorService guarantorService)
        {
            _guarantorService = guarantorService;
        }

        /// <summary>
        /// Gets all guarantors
        /// </summary>
        /// <returns>An array of guarantors</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GuarantorDTO>>> GetGuarantors()
        {
            var guarantors = await _guarantorService.GetAll();

            return guarantors.ToList();
        }

        /// <summary>
        /// Gets a specific guarantor
        /// </summary>
        /// <param name="id">Guarantor id</param>
        /// <returns>A guarantor</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GuarantorDTO>> GetGuarantor(int id)
        {
            try
            {
                return await _guarantorService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a guarantor
        /// </summary>
        /// <param name="guarantor">Guarantor</param>
        /// <returns>A newly created guarantor</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GuarantorDTO>> AddGuarantor([FromBody, Required]GuarantorDTO guarantor)
        {
            guarantor = await _guarantorService.Add(guarantor);

            return CreatedAtAction(nameof(GetGuarantor), new { id = guarantor.Id }, guarantor);
        }

        /// <summary>
        /// Updates a specific guarantor
        /// </summary>
        /// <param name="id">Guarantor id</param>
        /// <param name="guarantor">Guarantor</param>
        /// <returns></returns>
        /// <response code="204">Item has been updated</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="404">Item not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGuarantor(int id, [FromBody, Required]GuarantorDTO guarantor)
        {
            if (id != guarantor.Id)
            {
                return BadRequest();
            }

            try
            {
                await _guarantorService.Update(guarantor);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific guarantor
        /// </summary>
        /// <param name="id">Guarantor id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGuarantor(int id)
        {
            try
            {
                await _guarantorService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
