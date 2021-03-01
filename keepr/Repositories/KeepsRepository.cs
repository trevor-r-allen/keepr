using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    // REVIEW Joining tables and populating
    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
      SELECT
      keep.*, profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }

    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT
      keep.*, profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.id = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal IEnumerable<Keep> GetKeepsByProfileId(string profileId)
    {
      string sql = @"
      SELECT
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.creatorId = @profileId;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { profileId }, splitOn: "id");
    }

    // REVIEW WTF IS THIS BANANAS SHIZ? (TREVOR'S HACKY BULLSHIZ)
    internal IEnumerable<KeepVaultKeepViewModel> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT
      keep.*, 
      vaultkeep.id as VaultKeepId,
      vault.*,
      profile.*,
      FROM vaultkeeps vaultkeep
      JOIN vaults vault ON vaultkeep.vaultId == vault.id
      JOIN keeps keep ON vaultkeep.keepId == keep.id
      JOIN profiles profile ON keep.creatorId == profile.id
      WHERE vaultId = @vaultId;";
      return _db.Query<KeepVaultKeepViewModel, Profile, KeepVaultKeepViewModel>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { vaultId }, splitOn: "id");
    }

    internal int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (creatorId, name, description, img)
      VALUES
      (@CreatorId, @Name, @Description, @Img);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal Keep Edit(Keep editedKeep)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description,
      img = @Img
      WHERE id = @Id;";
      _db.Execute(sql, editedKeep);
      return editedKeep;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}