using System;
using System.Collections.Generic;
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
    private readonly KeepsService _keepsService;
    private readonly VaultsService _vaultsService;

    public ProfilesController(ProfilesService profilesService, KeepsService keepsService, VaultsService vaultsService)
    {
      _profilesService = profilesService;
      _keepsService = keepsService;
      _vaultsService = vaultsService;
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

    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByProfileId(string id)
    {
      try
      {
        return Ok(_keepsService.GetKeepsByProfileId(id));
      }
      catch (Exception err)
      {

        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}/vaults")]
    public ActionResult<IEnumerable<Vault>> GetVaultsByProfileId(string id)
    {
      try
      {
        return Ok(_vaultsService.GetVaultsByProfileId(id));
      }
      catch (Exception err)
      {

        return BadRequest(err.Message);
      }
    }
  }
}