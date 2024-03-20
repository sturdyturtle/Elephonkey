using Elephonkey.Models.Entities;
using SQLite;

namespace Elephonkey.Models.DataAccess
{
    public class DataAccessSQLiteImplementation
    {
        //SQLiteAsyncConnection: Is a class provided by SQLite-net to facilitate asynchronous database operations.
        //con: This is a variable name chosen to represent the SQLite database connection.
        SQLiteAsyncConnection con;

        public DataAccessSQLiteImplementation()
        {
            //Initialize and sets up the database. The method is async, as a result
            //we ignore any return value by using the discard symbole "_" which tells
            //the compiler that the result of the method is intentionally being ignored.
            //This can be useful when you have a method that returns a value,
            //but you don't need that value for the current operation.
            _ = InitializeDatabase();
        }

        //Method to get a connection to SQLite database with table creation
        private async Task InitializeDatabase()
        {
            if (con == null)
            {
                //Set the database file name
                string fileName = DataAccessDatabaseNames.LoginCredentialsDB;

                //Get the path to the personal folder on the device
                string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                //Combine the document path and file name to get the complete path
                string path = Path.Combine(documentPath, fileName);

                //Check if the directory exists, create it if it doesn't
                if (!File.Exists(path))
                {
                    //Create the directory if it doesn't exist
                    Directory.CreateDirectory(documentPath);
                }

                //Initialize SQLite connection
                con = new SQLiteAsyncConnection(path);

                //Create 'Login' table if it does not exist
                await con.CreateTableAsync<EntityLogin>();
            }
        }

        //Method to retrieve all Login from the 'Login' table
        public async Task<List<EntityLogin>> GetLogin()
        {
            //Use the returned connection from InitializeDatabase
            await InitializeDatabase();

            //SQL query to select all rows from 'Login' table
            string sql = "SELECT * FROM EntityLogin";

            //Execute the query and retrieve a list of Logins
            List<EntityLogin> Login = await con.QueryAsync<EntityLogin>(sql);

            return Login;
        }

        //Method to save a new Login record
        public async Task<string> CreateLogin(EntityLogin Login)
        {
            string result = string.Empty;

            try
            {
                await InitializeDatabase();

                //Check if a record with the same Email and Password already exists
                var existingLogin = await con.Table<EntityLogin>()
                      .Where(v => v.Email == Login.Email && v.Password == Login.Password)
                      .FirstOrDefaultAsync();

                if (existingLogin == null)
                {
                    //Insert the Login record into the 'Login' table
                    await con.InsertAsync(Login);
                }
                else
                {
                    //Record with the same Email and Password already exists
                    string msg = Login.Email + " and " + Login.Password + " already exists.";
                    //await Application.Current.MainPage.DisplayAlert("Message", msg, "Ok");

                    result = msg;
                }
            }
            catch (Exception ex)
            {
                result = "ERROR: " + ex.Message;
            }

            return result;
        }

        public async Task<string> PerformLogin(EntityLogin Login)
        {
            string result = string.Empty;

            try
            {
                await InitializeDatabase();

                var existingLogin = await con.Table<EntityLogin>()
                      .Where(v => v.Email == Login.Email && v.Password == Login.Password)
                      .FirstOrDefaultAsync();

                if (existingLogin != null)
                {
                    //Insert the Login record into the 'Login' table
                    await con.InsertAsync(Login);
                }
                else
                {
                    string msg = "Account does not exist";
                    result = msg;
                }
            }
            catch (Exception ex)
            {
                result = "ERROR: " + ex.Message;
            }

            return result;
        }

        //Method to update an existing Login record
        public async Task<bool> UpdateLogin(EntityLogin Login)
        {
            bool res = false;

            try
            {
                //Use the returned connection from InitializeDatabase
                await InitializeDatabase();

                //$ is short-hand for String.Format, used with string 
                //interpolations (e.g. {0}).  Used in C# 6.0
                //SQL query to update login details based on the provided Id
                string sql = $"UPDATE EntityLogin " +
                                  $"SET Email = '{Login.Email}', " +
                                  $"Password = '{Login.Password}', " +
                                  $"WHERE Id = {Login.Id}";

                //Execute the update query
                await con.QueryAsync<EntityLogin>(sql);
                res = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return res;
        }
    }
}
