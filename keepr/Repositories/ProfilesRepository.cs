using System;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;
    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id;";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = @"
      INSERT INTO profiles
        (id, name, email, picture)
      VALUES
        (@Id, @Name, @Email, @Picture);";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}