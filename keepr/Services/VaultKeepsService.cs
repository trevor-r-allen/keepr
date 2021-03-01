using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vaultKeepsRepo;
    private readonly VaultsRepository _vaultsRepo;
    private readonly KeepsRepository _keepsRepo;
    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepo, VaultsRepository vaultsRepo, KeepsRepository keepsRepo)
    {
      _vaultKeepsRepo = vaultKeepsRepo;
      _vaultsRepo = vaultsRepo;
      _keepsRepo = keepsRepo;

    }

    internal VaultKeep Create(string userId, VaultKeep newVaultKeep)
    {
      Vault vault = _vaultsRepo.GetById(newVaultKeep.VaultId);
      Keep keep = _keepsRepo.GetById(newVaultKeep.KeepId);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      if (keep == null)
      {
        throw new Exception("Invalid Keep Id");
      }
      if (vault.CreatorId != userId)
      {
        throw new Exception("Access Denied: Cannot edit a vault you did not create");
      }
      newVaultKeep.Id = _vaultKeepsRepo.Create(newVaultKeep);
      return newVaultKeep;
    }

    internal string Delete(string userId, int id)
    {
      VaultKeep vaultKeep = _vaultKeepsRepo.GetById(id);
      if (vaultKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vaultKeep.CreatorId != userId)
      {
        throw new Exception("Access Denied: Cannot edit a vault you did not create");
      }
      _vaultKeepsRepo.Delete(id);
      return "Successfully removed keep from vault";
    }
  }
}