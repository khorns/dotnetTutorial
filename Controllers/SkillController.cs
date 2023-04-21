using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace tutorial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{

    // private readonly ICharacterService _characterService;

    // public CharacterController(ICharacterService characterService)
    // {
    //     _characterService = characterService;
    // }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<Skill>>>> Get() {
        var serviceResponse = new ServiceResponse<List<Skill>>();

        var sampleData = new List<Skill> {
            new Skill {Id = 0, Name = "Skill 01", Class = RpgClass.Mage},
            new Skill {Id = 1, Name = "Skill 02"}
        };

        serviceResponse.Data = sampleData;

        return Ok(serviceResponse);
    }
}