using System;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _profilesService;

    public ProfilesController(ProfilesService profilesService)
    {
      _profilesService = profilesService;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> GetById(string id)
    {
      try
      {
        return Ok(_profilesService.GetById(id));
      }
      catch (Exception err)
      {

        return BadRequest(err.Message);
      }
    }
  }
}