using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Models;
using Steam.Repositories;

namespace WebSteam.Controllers;
// http://localhost:5241/api/v1/developers
// É uma boa prática versionar a API (v1, v2, vn)
[ApiController]
[Route("api/v1/developers")]
public class DevelopersController : ControllerBase
{

    private readonly ILogger<DevelopersController> _logger;
    private readonly IDeveloperRepository _repo;

    public DevelopersController(ILogger<DevelopersController> logger,
     IDeveloperRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }
    // GET developers
    // POST developers
    [HttpPost(Name = "NewDeveloper")] // annotation
    [Authorize]
    public IActionResult NewDeveloper
                ([FromBody] NewDeveloperDTO newDev)
    {
        // de-para: do DTO para o Model
        var dev = new Developer
        {
            Name = newDev.Name
        };

        _repo.Save(dev);
        return Ok("Developer Saved");
    }

    [HttpGet(Name = "GetAllDevelopers")]
    [Authorize(Roles = "USER")] // autorizar
    public ActionResult<IEnumerable<Developer>> GetAll()
    {
        return Ok(_repo.GetAll());
    }
}

// não é model, representa o payload (aquilo que vem pela API, pelo form) DTO: Data Transfer Object, View Model
// NewDeveloperDTO // conteúdo do JSON que vem da requisição
public record class NewDeveloperDTO(string Name);