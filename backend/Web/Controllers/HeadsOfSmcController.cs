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
    public class HeadsOfSmcController : ControllerBase
    {
        private readonly IHeadOfSmcService _headOfSmcService;

        public HeadsOfSmcController(IHeadOfSmcService headOfSmcService)
        {
            _headOfSmcService = headOfSmcService;
        }

        /// <summary>
        /// Gets all heads of SMC
        /// </summary>
        /// <returns>An array of heads of SMC</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HeadOfSmcDTO>>> GetHeadsOfSmc()
        {
            var headsOfSmc = await _headOfSmcService.GetAll();

            return headsOfSmc.ToList();
        }

        /// <summary>
        /// Gets a specific head of SMC
        /// </summary>
        /// <param name="id">Head of SMC id</param>
        /// <returns>A head of SMC</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HeadOfSmcDTO>> GetHeadOfSmc(int id)
        {
            try
            {
                return await _headOfSmcService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a head of SMC
        /// </summary>
        /// <param name="headOfSmc">HeadOfSmc</param>
        /// <returns>A newly created head of SMC</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HeadOfSmcDTO>> AddHeadOfSmc([FromBody, Required]HeadOfSmcDTO headOfSmc)
        {
            headOfSmc = await _headOfSmcService.Add(headOfSmc);

            return CreatedAtAction(nameof(GetHeadOfSmc), new { id = headOfSmc.Id }, headOfSmc);
        }

        /// <summary>
        /// Updates a specific head of SMC
        /// </summary>
        /// <param name="id">Head of SMC id</param>
        /// <param name="headOfSmc">HeadOfSmc</param>
        /// <returns></returns>
        /// <response code="204">Item has been updated</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="404">Item not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateHeadOfSmc(int id, [FromBody, Required]HeadOfSmcDTO headOfSmc)
        {
            if (id != headOfSmc.Id)
            {
                return BadRequest();
            }

            try
            {
                await _headOfSmcService.Update(headOfSmc);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific head of SMC
        /// </summary>
        /// <param name="id">Head of SMC id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHeadOfSmc(int id)
        {
            try
            {
                await _headOfSmcService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
