using System.Data.SQLite;
using System.Windows.Controls;

namespace WGUCapstoneProject.HelperClasses
{
    class CustomSQLiteCommand
    {
        #region Delete table entry methods
        public static SQLiteCommand DeleteFromTableStatement(SQLiteConnection connection, string tableName, int deletedValueId)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"DELETE FROM {tableName} WHERE {tableName}Id = {deletedValueId}";
            return command;
        }

        public static void DeleteFromTable(SQLiteCommand command)
        {
            using (SQLiteConnection conn = SQLiteDBConnection.Connection)
            {
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
                command = null;
                conn.Close();
            }
        }
        #endregion
        #region Methods for truncating more than one table at a time - public void ClearTables(string tableName1, ..., string tableNameN) 
        /// <summary>
        /// SQLite truncate table one table
        /// </summary>
        public static SQLiteCommand TruncateTableStatement(SQLiteConnection connection, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            command.CommandText = $"DELETE FROM {tableName}";
            return command;
        }

        /// <summary>
        /// Truncate one table
        /// </summary>
        public static void TruncateTable(string table1)
        {
            using (SQLiteConnection conn = SQLiteDBConnection.Connection)
            {
                conn.Open();
                SQLiteCommand cmd = TruncateTableStatement(conn, table1);
                cmd.ExecuteNonQuery();
                cmd = null;
                conn.Close();
            }
        }
        /// <summary>
        /// Truncate two tables
        /// </summary>
        public static void TruncateTable(string table1, string table2)
        {
            using (SQLiteConnection conn = SQLiteDBConnection.Connection)
            {
                conn.Open();
                SQLiteCommand cmd = TruncateTableStatement(conn, table1);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table2);
                cmd.ExecuteNonQuery();
                cmd = null;
                conn.Close();
            }
        }
        /// <summary>
        /// Truncate three tables
        /// </summary>
        public static void TruncateTable(string table1, string table2, string table3)
        {
            using (SQLiteConnection conn = SQLiteDBConnection.Connection)
            {
                conn.Open();
                SQLiteCommand cmd = TruncateTableStatement(conn, table1);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table2);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table3);
                cmd.ExecuteNonQuery();
                cmd = null;
                conn.Close();
            }
        }
        /// <summary>
        /// Truncate four tables
        /// </summary>
        public static void TruncateTable(string table1, string table2, string table3, string table4)
        {
            using (SQLiteConnection conn = SQLiteDBConnection.Connection)
            {
                conn.Open();
                SQLiteCommand cmd = TruncateTableStatement(conn, table1);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table2);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table3);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table4);
                cmd.ExecuteNonQuery();
                cmd = null;
                conn.Close();
            }
        }
        /// <summary>
        /// Truncate five tables
        /// </summary>
        public static void TruncateTable(string table1, string table2, string table3, string table4, string table5)
        {
            using (SQLiteConnection conn = SQLiteDBConnection.Connection)
            {
                conn.Open();
                SQLiteCommand cmd = TruncateTableStatement(conn, table1);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table2);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table3);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table4);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table5);
                cmd.ExecuteNonQuery();
                cmd = null;
                conn.Close();
            }
        }
        /// <summary>
        /// Truncate six tables
        /// </summary>
        public void TruncateTable(string table1, string table2, string table3, string table4, string table5, string table6)
        {
            using (SQLiteConnection conn = SQLiteDBConnection.Connection)
            {
                conn.Open();
                SQLiteCommand cmd = TruncateTableStatement(conn, table1);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table2);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table3);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table4);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table5);
                cmd.ExecuteNonQuery();
                cmd = TruncateTableStatement(conn, table6);
                cmd.ExecuteNonQuery();
                cmd = null;
                conn.Close();
            }
        }
        #endregion
        #region Select all statement methods
        public static SQLiteCommand SelectAllStatement(SQLiteConnection connection, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT * FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        #endregion
        #region Select statement with specific columns methods
        /// <summary>
        /// SQLite select statement with one column
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with two columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with three columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with four columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string column4, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3}, {column4} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with five columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string column4, string column5, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3}, {column4}, {column5} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with six columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string column4, string column5, string column6, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3}, {column4}, {column5}, {column6} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with seven columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string column4, string column5, string column6, string column7, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3}, {column4}, {column5}, {column6}, {column7} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with eight columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string column4, string column5, string column6, string column7, string column8, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3}, {column4}, {column5}, {column6}, {column7}, {column8} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with nine columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string column4, string column5, string column6, string column7, string column8, string column9, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3}, {column4}, {column5}, {column6}, {column7}, {column8}, {column9} FROM {tableName}";
            command.Connection = connection;
            return command;
        }
        /// <summary>
        /// SQLite select statement with ten columns
        /// </summary>
        public static SQLiteCommand SelectStatement(SQLiteConnection connection, string column1, string column2, string column3, string column4, string column5, string column6, string column7, string column8, string column9, string column10, string tableName)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT {column1}, {column2}, {column3}, {column4}, {column5}, {column6}, {column7}, {column8}, {column9}, {column10} FROM {tableName}";
            command.Connection = connection;
            return command;
        } 
        #endregion
    }
}
