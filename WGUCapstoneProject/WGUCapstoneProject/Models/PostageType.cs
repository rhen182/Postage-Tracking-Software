﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class PostageType
    {
        public int PostageTypeId { get; set; }
        public string PostageTypeName { get; set; }
        public PostageType()
        {

        }

        public PostageType(string postageTypeName)
        {
            PostageTypeName = postageTypeName;
        }

        public static ObservableCollection<PostageType> PostageTypeObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<PostageType> postageTypes = new ObservableCollection<PostageType>();

            //Step 2 - Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteDBConnection.DatabaseDirectory;

            //Step 2.5 - Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
                //Step 3 - Command
                SqliteCommand command = new SqliteCommand();
                command.CommandText = "SELECT * FROM PostageType";
                command.Connection = conn;

                //Step 4 - Open connection
                conn.Open();

                //Step 5 - Execute Command
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PostageType postageType = new PostageType();
                        postageType.PostageTypeId = reader.GetInt32(0);
                        postageType.PostageTypeName = reader.GetString(1);
                        postageTypes.Add(postageType);
                    }
                }
                else
                {
                    return null;
                }

                //Step x = Close Connection

                //Step x = return the ObservableCollection
                return postageTypes;
            }
        }

        public static void InsertPostageTypeToDb(string postageTypeName)
        {
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteDBConnection.DatabaseDirectory;
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
                SqliteCommand command = new SqliteCommand();
                command.Connection = conn;
                command.CommandText = @"INSERT INTO PostageType (PostageTypeName) 
                                        VALUES ('" + postageTypeName + "')";
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
