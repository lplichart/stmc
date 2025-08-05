using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Dao
{
    class MaatschappijDao
    {
        static MaatschappijDao instance = null;
        static readonly object padlock = new object();

        MaatschappijDao()
        {
        }

        public static MaatschappijDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MaatschappijDao();
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

        #region Select

        public Maatschappij getMaatschappijById(int id)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            Maatschappij maatschappij = null;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * From maatschappij WHERE id =\'"+id+"\'";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                maatschappij = new Maatschappij(reader["naam"].ToString(), reader["straat"].ToString(), reader["gemeente"].ToString(), reader["postcode"].ToString());
                maatschappij.Telefoon = reader["tel"].ToString();
                maatschappij.Fax = reader["fax"].ToString();
                maatschappij.Email = reader["email"].ToString();
                maatschappij.Btw = reader["btw"].ToString();
                maatschappij.Id = int.Parse(reader["id"].ToString());
            }

            closeConnection();

            return maatschappij;
        }

        public string getMaatschappijNaamById(int id)
        {
            return getAnyFromMaatschappij("Select naam from maatschappij where id=" + id.ToString());
        }

        public Maatschappij getMaatschappijByNaam(string naam)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            Maatschappij maatschappij = null;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * From maatschappij Where UPPER(naam) = UPPER(\'" + naam.Replace("'", "\\'") + "\')";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {

                try
                {
                    maatschappij = new Maatschappij(reader["naam"].ToString(), reader["straat"].ToString(), reader["gemeente"].ToString(), reader["postcode"].ToString());
                    maatschappij.Telefoon = reader["tel"].ToString();
                    maatschappij.Fax = reader["fax"].ToString();
                    maatschappij.Email = reader["email"].ToString();
                    maatschappij.Btw = reader["btw"].ToString();
                    maatschappij.Id = int.Parse(reader["id"].ToString());
                }
                catch (Exception e)
                {
                    //do nothing
                }
            }

            closeConnection();

            return maatschappij;
        }

        private string getAnyFromMaatschappij(string commandText)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            string maatschappij = "";
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = commandText;
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                maatschappij = reader["naam"].ToString();
            }

            closeConnection();

            return maatschappij;

        }

        public Dictionary<string, int> getMaatschappijen()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            Dictionary<string, int> maatschappijen = new Dictionary<string, int>();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * From maatschappij Order By naam";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {

                try
                {
                    maatschappijen.Add(reader["naam"].ToString().ToUpper(), int.Parse(reader["id"].ToString()));
                }
                catch (Exception)
                {
                }
            }

            closeConnection();

            return maatschappijen;
        }

        public Maatschappij getMaatschappij(Maatschappij maatschappij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            Maatschappij maatschappijFromDb = null;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * From maatschappij WHERE ";
            if (maatschappij.Naam.Equals("")) command.CommandText += "(naam IS NULL OR naam = \'\') AND "; else command.CommandText += "naam=\'" + maatschappij.Naam.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Straat.Equals("")) command.CommandText += "(straat IS NULL OR straat = \'\') AND "; else command.CommandText += "straat=\'" + maatschappij.Straat.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Gemeente.Equals("")) command.CommandText += "(gemeente IS NULL OR gemeente = \'\') AND "; else command.CommandText += "gemeente=\'" + maatschappij.Gemeente.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Postcode.Equals("")) command.CommandText += "(postcode IS NULL OR postcode = \'\') AND "; else command.CommandText += "postcode=\'" + maatschappij.Postcode.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Telefoon.Equals("")) command.CommandText += "(tel IS NULL OR tel = \'\') AND "; else command.CommandText += "tel=\'" + maatschappij.Telefoon.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Fax.Equals("")) command.CommandText += "(fax IS NULL OR fax = \'\') AND "; else command.CommandText += "fax=\'" + maatschappij.Fax.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Email.Equals("")) command.CommandText += "(email IS NULL OR email = \'\') AND "; else command.CommandText += "email=\'" + maatschappij.Email.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Btw.Equals("")) command.CommandText += "(btw IS NULL OR btw = \'\');"; else command.CommandText += "btw=\'" + maatschappij.Btw.Replace("'", "\\'") + "\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                maatschappijFromDb = new Maatschappij(reader["naam"].ToString(), reader["straat"].ToString(), reader["gemeente"].ToString(), reader["postcode"].ToString());
                maatschappij.Telefoon = reader["tel"].ToString();
                maatschappij.Fax = reader["fax"].ToString();
                maatschappij.Email = reader["email"].ToString();
                maatschappij.Btw = reader["btw"].ToString();
                maatschappij.Id = int.Parse(reader["id"].ToString());
            }

            closeConnection();

            return maatschappijFromDb;
        }

        #endregion

        #region Create
        public void AddMaatschappij(Maatschappij maatschappij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = createInsertStatement(maatschappij);
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
        public string createInsertStatement(Maatschappij maatschappij)
        {
            string statement = "INSERT INTO `db_mertens`.`maatschappij` (`naam`, `straat`, `gemeente`, `postcode`, `tel`, `fax`, `email`, `btw`) VALUES (";

            ArrayList gegevens = new ArrayList();
            int i = 0;


            if (maatschappij.Naam == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Naam.Replace("'", "\\'")); }
            if (maatschappij.Straat == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Straat.Replace("'", "\\'")); }
            if (maatschappij.Gemeente == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Gemeente.Replace("'", "\\'")); }
            if (maatschappij.Postcode == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Postcode.Replace("'", "\\'")); }
            if (maatschappij.Telefoon == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Telefoon.Replace("'", "\\'")); }
            if (maatschappij.Fax == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Fax.Replace("'", "\\'")); }
            if (maatschappij.Email == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Email.Replace("'", "\\'")); }
            if (maatschappij.Btw == null) gegevens.Add(""); else { gegevens.Add(maatschappij.Btw.Replace("'", "\\'")); }

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
        #endregion

        public void updateMaatschappij(Maatschappij maatschappij, Maatschappij newMaatschappij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE maatschappij";
            command.CommandText += " SET naam = \'" + newMaatschappij.Naam.Replace("'", "\\'") + "\', straat = \'" + newMaatschappij.Straat.Replace("'", "\\'") + "\', gemeente = \'" + newMaatschappij.Gemeente.Replace("'", "\\'") + "\', postcode = \'" + newMaatschappij.Postcode.Replace("'", "\\'") + "\', tel = \'" + newMaatschappij.Telefoon.Replace("'", "\\'") + "\', fax = \'" + newMaatschappij.Fax.Replace("'", "\\'") + "\', email = \'" + newMaatschappij.Email.Replace("'", "\\'") + "\', btw = \'" + newMaatschappij.Btw.Replace("'", "\\'") + "\'";
            command.CommandText += " WHERE ";
            if (maatschappij.Naam.Equals("")) command.CommandText += "(naam IS NULL OR naam = \'\') AND "; else command.CommandText += "naam=\'" + maatschappij.Naam.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Straat.Equals("")) command.CommandText += "(straat IS NULL OR straat = \'\') AND "; else command.CommandText += "straat=\'" + maatschappij.Straat.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Gemeente.Equals("")) command.CommandText += "(gemeente IS NULL OR gemeente = \'\') AND "; else command.CommandText += "gemeente=\'" + maatschappij.Gemeente.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Postcode.Equals("")) command.CommandText += "(postcode IS NULL OR postcode = \'\') AND "; else command.CommandText += "postcode=\'" + maatschappij.Postcode.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Telefoon.Equals("")) command.CommandText += "(tel IS NULL OR tel = \'\') AND "; else command.CommandText += "tel=\'" + maatschappij.Telefoon.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Fax.Equals("")) command.CommandText += "(fax IS NULL OR fax = \'\') AND "; else command.CommandText += "fax=\'" + maatschappij.Fax.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Email.Equals("")) command.CommandText += "(email IS NULL OR email = \'\') AND "; else command.CommandText += "email=\'" + maatschappij.Email.Replace("'", "\\'") + "\' AND ";
            if (maatschappij.Btw.Equals("")) command.CommandText += "(btw IS NULL OR btw = \'\');"; else command.CommandText += "btw=\'" + maatschappij.Btw.Replace("'", "\\'") + "\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
