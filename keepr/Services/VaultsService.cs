using System;
using System.Collections.Generic;
using System.Linq;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {
    private VaultsRepository _vaultsRepo;

    public VaultsService(VaultsRepository vaultsRepo)
    {
      _vaultsRepo = vaultsRepo;
    }

    internal Vault GetById(int id)
    {
      Vault vault = _vaultsRepo.GetById(id);
      if (vault == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vault.IsPrivate == true)
      {
        throw new Exception("Access Denied: This vault is private");
      }
      return vault;
    }
    internal IEnumerable<Vault> GetVaultsByProfileId(string profileId)
    {
      return _vaultsRepo.GetVaultsByProfileId(profileId).ToList().FindAll(vault => vault.IsPrivate == false);
    }

    internal Vault Create(Vault newVault)
    {
      newVault.Id = _vaultsRepo.Create(newVault);
      return newVault;
    }

    internal Vault Edit(string userId, Vault editedVault)
    {
      Vault original = _vaultsRepo.GetById(editedVault.Id);
      if (original.CreatorId != userId)
      {
        throw new Exception("Access Denied: Cannot edit a keep you did not create");
      }

      editedVault.CreatorId = original.CreatorId;
      editedVault.Name = editedVault.Name == null ? original.Name : editedVault.Name;
      editedVault.Description = editedVault.Description == null ? original.Description : editedVault.Description;

      return _vaultsRepo.Edit(editedVault);
    }

    internal string Delete(string userId, int id)
    {
      Vault vault = _vaultsRepo.GetById(id);
      if (vault == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vault.CreatorId != userId)
      {
        throw new Exception("Access Denied: Cannot edit a keep you did not create");
      }
      _vaultsRepo.Delete(id);
      return "Successfully Deleted";
    }
  }
}