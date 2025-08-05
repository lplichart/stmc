using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Mertens.Dao
{
    class ContractDao
    {
        private MySqlConnection connection;
        private string connectionString;
        static ContractDao instance = null;
        static readonly object padlock = new object();

        ContractDao()
        {
        }

        public static ContractDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ContractDao();
                    }
                    return instance;
                }
            }
        }

        private void setupConnection()
        {
            this.connectionString = ConnectionStringManager.getConnectionString();
            connection = new MySqlConnection(connectionString);
        }

        private void openConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }  
            }
            catch (Exception ex)
            {
                throw new Exception("Kon geen connectie maken met de databank " + ex.Message);
            }

        }

        private void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {

                throw new Exception("de verbindding kon niet gesloten worden " + e.Message);
            }
        }

        public ArrayList getContracten()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList contracten = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM contract";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                contracten.Add(reader["naam"].ToString());
            }

            closeConnection();

            return contracten;
        }

    }
}
