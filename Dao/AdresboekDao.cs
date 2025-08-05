using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Dao
{
    class AdresboekDao
    {
        static AdresboekDao instance = null;
        static readonly object padlock = new object();

        AdresboekDao()
        {
        }

        public static AdresboekDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AdresboekDao();
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

        public ArrayList getPartijenFromAdresboek()
        {

            ArrayList partijen = new ArrayList();

            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * FROM adresboek ORDER BY naam";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Partij partij = new Partij(reader["naam"].ToString(), reader["straat"].ToString(), reader["postcode"].ToString(), reader["gemeente"].ToString(), reader["tel"].ToString(), reader["fax"].ToString(), reader["email"].ToString());
                partijen.Add(partij);
            }

            closeConnection();
            return partijen;
        }

        public Partij getPartijFromAdresboek(Partij partij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * From adresboek WHERE naam = \'" + partij.Naam + "\'AND straat = \'" + partij.Adres + "\'AND gemeente = \'" + partij.Gemeente + "\'AND postcode = \'" + partij.Postcode + "\'AND tel = \'" + partij.Tel + "\'AND fax = \'" + partij.Fax + "\'AND email = \'" + partij.Email + "\';"; 
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            Partij partijInDb = null;

            while (reader.Read())
            {
                partijInDb = new Partij();
                partijInDb.Naam = reader["naam"].ToString();
                partijInDb.Adres = reader["straat"].ToString();
                partijInDb.Gemeente = reader["postcode"].ToString();
                partijInDb.Postcode = reader["tel"].ToString();
                partijInDb.Tel = reader["tel"].ToString();
                partijInDb.Fax = reader["fax"].ToString();
                partijInDb.Email = reader["email"].ToString();
            }

            closeConnection();

            return partijInDb;
        }

        public void addNewPartijInAdresboek(Partij partij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = createInsertStatement(partij);
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public string createInsertStatement(Partij partij)
        {
            string statement = "INSERT INTO `db_mertens`.`adresboek` (`naam`, `straat`, `gemeente`, `postcode`, `tel`, `fax`, `email`) VALUES (";

            ArrayList gegevens = new ArrayList();
            int i = 0;


            if (partij.Naam == null) gegevens.Add(""); else { gegevens.Add(partij.Naam.Replace("'", "\\'")); }
            if (partij.Adres == null) gegevens.Add(""); else { gegevens.Add(partij.Adres.Replace("'", "\\'")); }
            if (partij.Gemeente == null) gegevens.Add(""); else { gegevens.Add(partij.Gemeente); }
            if (partij.Postcode == null) gegevens.Add(""); else { gegevens.Add(partij.Postcode); }
            if (partij.Tel == null) gegevens.Add(""); else { gegevens.Add(partij.Tel); }
            if (partij.Fax == null) gegevens.Add(""); else { gegevens.Add(partij.Fax); }
            if (partij.Email == null) gegevens.Add(""); else { gegevens.Add(partij.Email); }

            foreach (Object o in gegevens)
            {
                String s = (String)o;

                if (i == 0) { statement += "\'" + s + "\'"; }
                else { statement += ",\'" + s + "\'"; }

                i++;
            }

            statement += ");";

            return statement;
        }



        //UPDATE `db_mertens`.`adresboek` SET `naam`='Vanbreda isk & Benefits', `straat`='', `gemeente`='Borgerhut', `postcode`='214', `tel`='03 217 67 7', `fax`='k', `email`='k' WHERE `id`='4';

        public void updateAdresboek(Partij partij, Partij newPartij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE adresboek";
            command.CommandText += " SET naam = \'" + newPartij.Naam.Replace("'", "\\'") + "\', straat = \'" + newPartij.Adres.Replace("'", "\\'") + "\', gemeente = \'" + newPartij.Gemeente.Replace("'", "\\'") + "\', postcode = \'" + newPartij.Postcode + "\', tel = \'" + newPartij.Tel + "\', fax = \'" + newPartij.Fax + "\', email = \'" + newPartij.Email + "\'";
            command.CommandText += " WHERE naam = \'" + partij.Naam.Replace("'", "\\'") + "\'AND straat = \'" + partij.Adres.Replace("'", "\\'") + "\'AND gemeente = \'" + partij.Gemeente.Replace("'", "\\'") + "\'AND postcode = \'" + partij.Postcode + "\'AND tel = \'" + partij.Tel + "\'AND fax = \'" + partij.Fax + "\'AND email = \'" + partij.Email + "\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        #region Delete
        public void deletePartijFromAdresboek(Partij partij)
        {

            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "DELETE FROM adresboek WHERE naam = \'" + partij.Naam.Replace("'", "\\'") + "\' And straat = \'" + partij.Adres.Replace("'", "\\'") + "\' And postcode = \'" + partij.Postcode + "\' And gemeente = \'" + partij.Gemeente.Replace("'", "\\'") + "\' And tel = \'" + partij.Tel + "\' And fax = \'" + partij.Fax + "\'And email = \'" + partij.Email + "\';"; 
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
        #endregion
    }
}
