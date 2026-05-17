using Microsoft.AspNetCore.Mvc;
using PcManager.DTOs;
using PcManager.Services;

namespace PcManager.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    // GET api/pcs
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PcListDto>>> GetAll()
    {
        var pcs = await _pcService.GetAllAsync();
        return Ok(pcs);
    }

    // GET api/pcs/{id}/components
    [HttpGet("{id}/components")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PcWithComponentsDto>> GetByIdWithComponents(int id)
    {
        var pc = await _pcService.GetByIdWithComponentsAsync(id);
        if (pc is null)
            return NotFound($"PC with id {id} not found.");

        return Ok(pc);
    }

    // POST api/pcs
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PcListDto>> Create([FromBody] CreatePcDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _pcService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByIdWithComponents), new { id = created.Id }, created);
    }

    // PUT api/pcs/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PcListDto>> Update(int id, [FromBody] UpdatePcDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _pcService.UpdateAsync(id, dto);
        if (updated is null)
            return NotFound($"PC with id {id} not found.");

        return Ok(updated);
    }

    // DELETE api/pcs/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _pcService.DeleteAsync(id);
        if (!deleted)
            return NotFound($"PC with id {id} not found.");

        return NoContent();
    }
}
