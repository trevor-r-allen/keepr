using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _keepsRepo;
    private readonly VaultsRepository _vaultsRepo;
    public KeepsService(KeepsRepository keepsRepo, VaultsRepository vaultsRepo)
    {
      _keepsRepo = keepsRepo;
      _vaultsRepo = vaultsRepo;
    }

    internal IEnumerable<Keep> GetAll()
    {
      return _keepsRepo.GetAll();
    }

    internal Keep GetById(int id)
    {
      Keep keep = _keepsRepo.GetById(id);
      if (keep == null)
      {
        throw new Exception("Invalid Id");
      }
      return keep;
    }

    internal IEnumerable<Keep> GetKeepsByProfileId(string profileId)
    {
      return _keepsRepo.GetKeepsByProfileId(profileId);
    }

    internal IEnumerable<KeepVaultKeepViewModel> GetKeepsByVaultId(string userId, int vaultId)
    {
      Vault vault = _vaultsRepo.GetById(vaultId);
      if (vault == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vault.IsPrivate == true && vault.CreatorId != userId)
      {
        throw new Exception("Access Denied: This vault is private");
      }
      return _keepsRepo.GetKeepsByVaultId(vaultId);
    }

    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _keepsRepo.Create(newKeep);
      return newKeep;
    }

    internal Keep Edit(string userId, Keep editedKeep)
    {
      Keep original = GetById(editedKeep.Id);
      if (original.CreatorId != userId)
      {
        throw new Exception("Access Denied: Cannot edit a keep you did not create");
      }
      editedKeep.CreatorId = original.CreatorId;
      editedKeep.Name = editedKeep.Name == null ? original.Name : editedKeep.Name;
      editedKeep.Description = editedKeep.Description == null ? original.Description : editedKeep.Description;
      editedKeep.Img = editedKeep.Img == null ? original.Img : editedKeep.Img;
      editedKeep.Views = original.Views;
      editedKeep.Shares = original.Shares;
      editedKeep.Keeps = original.Keeps;

      return _keepsRepo.Edit(editedKeep);
    }


    internal string Delete(string userId, int id)
    {
      Keep keep = _keepsRepo.GetById(id);
      if (keep == null)
      {
        throw new Exception("Invalid Id");
      }
      if (keep.CreatorId != userId)
      {
        throw new Exception("Access Denied: Cannot delete a keep you did not create");
      }
      _keepsRepo.Delete(id);
      return "Successfully Deleted";
    }
  }
}