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
    public class KnowledgeBranchesController : ControllerBase
    {
        private readonly IKnowledgeBranchService _knowledgeBranchService;

        public KnowledgeBranchesController(IKnowledgeBranchService knowledgeBranchService)
        {
            _knowledgeBranchService = knowledgeBranchService;
        }

        /// <summary>
        /// Gets all knowledge branches
        /// </summary>
        /// <returns>An array of knowledge branches</returns>
        /// <response code="200">Returns an array of items</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<KnowledgeBranchDTO>>> GetKnowledgeBranches()
        {
            var knowledgeBranches = await _knowledgeBranchService.GetAll();

            return knowledgeBranches.ToList();
        }

        /// <summary>
        /// Gets a specific knowledge branch
        /// </summary>
        /// <param name="id">Knowledge branch id</param>
        /// <returns>A knowledge branch</returns>
        /// <response code="200">Returns the specified item</response>
        /// <response code="404">Item not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KnowledgeBranchDTO>> GetKnowledgeBranch(int id)
        {
            try
            {
                return await _knowledgeBranchService.GetById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a knowledge branch
        /// </summary>
        /// <param name="knowledgeBranch">KnowledgeBranch</param>
        /// <returns>A newly created knowledge branch</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Data is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<KnowledgeBranchDTO>> AddKnowledgeBranch([FromBody, Required]KnowledgeBranchDTO knowledgeBranch)
        {
            knowledgeBranch = await _knowledgeBranchService.Add(knowledgeBranch);

            return CreatedAtAction(nameof(GetKnowledgeBranch), new { id = knowledgeBranch.Id }, knowledgeBranch);
        }

        /// <summary>
        /// Updates a specific knowledge branch
        /// </summary>
        /// <param name="id">Knowledge branch id</param>
        /// <param name="knowledgeBranch">KnowledgeBranch</param>
        /// <returns></returns>
        /// <response code="204">Item has been updated</response>
        /// <response code="400">Data is not valid</response>
        /// <response code="404">Item not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateKnowledgeBranch(int id, [FromBody, Required]KnowledgeBranchDTO knowledgeBranch)
        {
            if (id != knowledgeBranch.Id)
            {
                return BadRequest();
            }

            try
            {
                await _knowledgeBranchService.Update(knowledgeBranch);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific knowledge branch
        /// </summary>
        /// <param name="id">Knowledge branch id</param>
        /// <returns></returns>
        /// <response code="204">Item has been deleted</response>
        /// <response code="404">Item not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteKnowledgeBranch(int id)
        {
            try
            {
                await _knowledgeBranchService.Delete(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
