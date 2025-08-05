using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Dao
{
    class GemeenteDao
    {

        static GemeenteDao instance = null;
        static readonly object padlock = new object();

        GemeenteDao()
        {
        }

        public static GemeenteDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GemeenteDao();
                    }
                    return instance;
                }
            }
        }

        #region connection
        private MySqlConnection connection;
        private string connectionString;

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
        #endregion

        public ArrayList getAllPostCodes()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList postcodes = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select distinct postcode from gemeente";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                postcodes.Add(reader["postcode"].ToString());
            }

            closeConnection();

            return postcodes;
        }

        public ArrayList getGemeentenByPostcode(int postcode)
        {

            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList gemeenten = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select gemeente from gemeente where postcode=" + postcode.ToString();
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                gemeenten.Add(reader["gemeente"].ToString());
            }

            closeConnection();

            return gemeenten;
        }

        public Dictionary<string, ArrayList> getGemeenteDatabase()
        {
            ArrayList postcodes = getAllPostCodes();
            Dictionary<string, ArrayList> gemeentenBestand = new Dictionary<string, ArrayList>();
            foreach (Object o in postcodes)
            {
                string postcode = (String) o;
                gemeentenBestand.Add(postcode, getGemeentenByPostcode(int.Parse(postcode)));
            }

            return gemeentenBestand;
        }

    }
}
