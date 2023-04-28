﻿using Gifter.Repositories;
using Gifter.Utils;
using Mooch_Lightning.Model;

namespace Mooch_Lightning.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IConfiguration configuration) : base(configuration) { }

    public User AddUser(User user)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO [user] 
                                    (
                                      [FirebaseUid]
                                      ,[Username]
                                      ,[FirstName]
                                      ,[LastName]
                                      ,[Email]
                                      ,[Password]
                                      ,[SubscriptionLevelId]
                                      ,[ImageUrl]
                                      )
                                        OUTPUT INSERTED.id
                                        VALUES (
                                      @FirebaseUid
                                      ,@Username
                                      ,@FirstName
                                      ,@LastName
                                      ,@Email
                                      ,@Password
                                      ,@SubscriptionLevelId
                                      ,@ImageUrl
                                        );";
                DbUtils.AddParameter(cmd, "@FirebaseUid", user.FirebaseUid);
                DbUtils.AddParameter(cmd, "@Username", user.Username);
                DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                DbUtils.AddParameter(cmd, "@Email", user.Email);
                DbUtils.AddParameter(cmd, "@Password", user.Email);
                DbUtils.AddParameter(cmd, "@SubscriptionLevelId", user.SubscriptionLevelId);
                DbUtils.AddParameter(cmd, "@ImageUrl", user.ImageUrl);

                user.Id = (int)cmd.ExecuteScalar();
                return user;
            }
        }
    }

    public void DeleteUser(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"Delete from [dbo].[User] where id = @id";
                DbUtils.AddParameter(cmd, "@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public User GetById(int id) 
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT [Id]
                          ,[FirebaseUid]
                          ,[Username]
                          ,[FirstName]
                          ,[LastName]
                          ,[Email]
                          ,[Password]
                          ,[SubscriptionLevelId]
                          ,[ImageUrl]
                      FROM [Mooch].[dbo].[User]
                    WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                User user = null;

                if (reader.Read())
                {
                    user = new User()
                    {
                        Id = DbUtils.GetInt(reader, "Id"),
                        FirebaseUid = DbUtils.GetString(reader, "FirebaseUid"),
                        Username = DbUtils.GetString(reader, "Username"),
                        FirstName = DbUtils.GetString(reader, "FirstName"),
                        LastName = DbUtils.GetString(reader, "LastName"),
                        Email = DbUtils.GetString(reader, "Email"),
                        Password = DbUtils.GetString(reader, "Password"),
                        SubscriptionLevelId = DbUtils.GetInt(reader, "SubscriptionLevelId"),
                        ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                    };

                }
                reader.Close();
                return user;
            }
        }
    }

    public void UpdateUser(User user)
    {
        using(var conn = Connection)
            {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                                    UPDATE [dbo].[User]
                                       SET [FirebaseUid] = @FirebaseUid
                                          ,[Username] = @Username
                                          ,[FirstName] = @FirstName
                                          ,[LastName] = @LastName
                                          ,[Email] = @Email
                                          ,[Password] = @Password
                                          ,[SubscriptionLevelId] = @SubscriptionLevelId
                                          ,[ImageUrl] = @ImageUrl
                                     WHERE Id = @Id;
                                    ";

                DbUtils.AddParameter(cmd, "@FirebaseUid", user.FirebaseUid);
                DbUtils.AddParameter(cmd, "@Username", user.Username);
                DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                DbUtils.AddParameter(cmd, "@Email", user.Email);
                DbUtils.AddParameter(cmd, "@Password", user.Password);
                DbUtils.AddParameter(cmd, "@SubscriptionLevelId", user.SubscriptionLevelId);
                DbUtils.AddParameter(cmd, "@ImageUrl", user.ImageUrl);
                DbUtils.AddParameter(cmd, "@Id", user.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
