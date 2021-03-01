using System;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal int Create(VaultKeep newVaultKeep)
    {
      string sql = @"
      UPDATE keeps SET keeps = keeps+1 WHERE id = @keepId;

      INSERT INTO vaultkeeps
        (creatorId, vaultId, keepId)
      VALUES
        (@CreatorId, @VaultId, @KeepId);
        SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }

    internal void Delete(int id, int keepId)
    {
      string sql = @"
      UPDATE keeps SET keeps = keeps-1 WHERE id = @keepId;
      
      DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id, keepId });
    }
  }
}