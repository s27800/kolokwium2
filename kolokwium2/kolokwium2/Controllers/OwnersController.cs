using kolokwium2.Models.DTOs;
using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnersController : ControllerBase
{
    private readonly IDbService _dbService;

    public OwnersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOwners()
    {
        var owners = await _dbService.GetAllOwnersData();
        return Ok(owners);
    }

    [HttpPost]
    public async Task<IActionResult> AddOwner(AddOwner addOwner)
    {
        var ownerId = await _dbService.AddOwner(addOwner);

        if (!await _dbService.ObjectsExist(addOwner.OwnerObjects))
            return BadRequest();
        
        await _dbService.AddObjectOwner(ownerId, addOwner.OwnerObjects);

        return Created();
    }
}