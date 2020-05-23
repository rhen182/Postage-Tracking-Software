using System.Data.SQLite;

namespace WGUCapstoneProject.HelperClasses
{
    class CustomSQLiteCommand
    {
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
