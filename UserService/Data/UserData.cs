﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;
using UserService.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UserService { 

    public class UserData : ControllerBase
    {

        public UserData()
        {

        }

        public IConfigurationRoot GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
            return builder;
        }


        public List<User> getAll()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("Connectionstring").Value))
                {
                    connection.Open();

                    String sql = "SELECT * from Users";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User u = new User();
                                u.userID = reader.GetInt32(0);
                                u.username = reader.GetString(1);
                                u.password = reader.GetString(2);
                                u.email = reader.GetString(3);
                                users.Add(u);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return users;
        }

        public User getUserByID(int userID)
        {
            User u = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("Connectionstring").Value))
                {
                    connection.Open();

                    String sql = "SELECT * from Users where UserID = " + userID;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                u.userID = reader.GetInt32(0);
                                u.username = reader.GetString(1);
                                u.password = reader.GetString(2);
                                u.email = reader.GetString(3);
                                u.followers = getFollowers(u.userID);
                                u.following = getFollowing(u.userID);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return u;
        }

        public List<User> getFollowing(int userID)
        {
            List<User> users = new List<User>();
            List<int> userIds = new List<int>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("Connectionstring").Value))
                {
                    connection.Open();

                    String sql = "SELECT * from Following where UserID_1 = " + userID;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userIds.Add(reader.GetInt32(2));
                            }
                        }
                    }
                     
                }
                foreach(int i in userIds)
                {
                    users.Add(getUserByID(i));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return users;
        }

        public List<User> getFollowers(int userID)
        {
            List<User> users = new List<User>();
            List<int> userIds = new List<int>();
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("Connectionstring").Value))
                {
                    connection.Open();

                    String sql = "SELECT * from Following where UserID_2 = " + userID;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userIds.Add(reader.GetInt32(2));
                            }
                        }
                    }

                }
                foreach (int i in userIds)
                {
                    users.Add(getUserByID(i));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return users;
        }
    }
}
