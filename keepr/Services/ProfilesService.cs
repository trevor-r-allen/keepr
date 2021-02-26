using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _profilesRepo;

    public ProfilesService(ProfilesRepository profilesRepo)
    {
      _profilesRepo = profilesRepo;
    }

    internal Profile GetOrCreateUserInfo(Profile userInfo)
    {
      Profile profile = _profilesRepo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _profilesRepo.Create(userInfo);
      }
      return profile;
    }
  }
}