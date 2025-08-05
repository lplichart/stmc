using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Dao
{
    class PartijDao
    {

        static PartijDao instance = null;
        static readonly object padlock = new object();

        PartijDao()
        {
        }

        public static PartijDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PartijDao();
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

        public ArrayList getPartijenVoorDossier(int dossierId)
        {

            ArrayList partijen = new ArrayList();

            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList dossiers = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * from partij where dossier_id=" + dossierId;
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Partij partij = new Partij();
                partij.Id = int.Parse(reader["id"].ToString());
                partij.Naam = reader["naam"].ToString();
                partij.Referentie = reader["referentie"].ToString();
                partij.Adres = reader["adres"].ToString();
                partij.Postcode = reader["postcode"].ToString();
                partij.Gemeente = reader["gemeente"].ToString();
                partij.Tel = reader["tel"].ToString();
                partij.Fax = reader["fax"].ToString();
                partij.Gsm = reader["gsm"].ToString();
                partij.Email = reader["email"].ToString();
                partij.Type = int.Parse(reader["type_id"].ToString());
                partij.Hoedanigheid = reader["hoedanigheid"].ToString();
                partij.ContactPersoon = reader["contact"].ToString();
                try
                {
                    partij.Hoofdpartij_id = int.Parse(reader["hoofdpartij_id"].ToString());
                }
                catch (FormatException fe)
                {
                    partij.Hoofdpartij_id = 0;
                }

                partijen.Add(partij);
            }

            closeConnection();
            return partijen;
        }

        public Partij getPartij(Partij partij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            Partij foundPartij = null;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * from partij where id=\'" + partij.Id + "\' AND ";
            if (partij.Naam.Equals("")) command.CommandText += "(naam IS NULL OR naam = \'\') AND "; else command.CommandText += "naam=\'" + partij.Naam.Replace("'", "\\'") + "\' AND ";
            if (partij.Referentie.Equals("")) command.CommandText += "(referentie IS NULL OR referentie = \'\') AND "; else command.CommandText += "referentie=\'" + partij.Referentie.Replace("'", "\\'") + "\' AND ";
            if (partij.Adres.Equals("")) command.CommandText += "(adres IS NULL OR adres = \'\') AND "; else command.CommandText += "adres=\'" + partij.Adres.Replace("'", "\\'") + "\' AND ";
            if (partij.Postcode.Equals("")) command.CommandText += "(postcode IS NULL OR postcode = \'\') AND "; else command.CommandText += "postcode=\'" + partij.Postcode + "\' AND ";
            if (partij.Gemeente.Equals("")) command.CommandText += "(gemeente IS NULL OR gemeente = \'\') AND "; else command.CommandText += "gemeente=\'" + partij.Gemeente.Replace("'", "\\'") + "\' AND ";
            if (partij.Tel.Equals("")) command.CommandText += "(tel IS NULL OR tel = \'\') AND "; else command.CommandText += "tel=\'" + partij.Tel.Replace("'", "\\'") + "\' AND ";
            if (partij.Fax.Equals("")) command.CommandText += "(fax IS NULL OR fax = \'\') AND "; else command.CommandText += "fax=\'" + partij.Fax.Replace("'", "\\'") + "\' AND ";
            if (partij.Gsm.Equals("")) command.CommandText += "(gsm IS NULL OR gsm = \'\') AND "; else command.CommandText += "gsm=\'" + partij.Gsm.Replace("'", "\\'") + "\' AND ";
            if (partij.Email.Equals("")) command.CommandText += "(email IS NULL OR email = \'\') AND "; else command.CommandText += "email=\'" + partij.Email.Replace("'", "\\'") + "\' AND ";
            if (partij.Type.Equals("")) command.CommandText += "(type_id IS NULL OR type_id = \'\') AND "; else command.CommandText += "type_id=\'" + partij.Type + "\' AND ";
            if (partij.Hoedanigheid.Equals("")) command.CommandText += "(hoedanigheid IS NULL OR hoedanigheid = \'\') AND "; else command.CommandText += "hoedanigheid=\'" + partij.Hoedanigheid.Replace("'", "\\'") + "\' AND ";
            if (partij.ContactPersoon.Equals("")) command.CommandText += "(contact IS NULL OR contact = \'\') AND "; else command.CommandText += "contact=\'" + partij.ContactPersoon.Replace("'", "\\'") + "\' AND ";
            if (partij.Hoofdpartij_id.Equals("")) command.CommandText += "(hoofdpartij_id IS NULL OR hoofdpartij_id = \'\') AND "; else command.CommandText += "hoofdpartij_id=\'" + partij.Hoofdpartij_id + "\';";

            MySqlDataReader reader;
            openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                foundPartij = new Partij();
                foundPartij.Id = int.Parse(reader["id"].ToString());
                foundPartij.Naam = reader["naam"].ToString();
                foundPartij.Referentie = reader["referentie"].ToString();
                foundPartij.Adres = reader["adres"].ToString();
                foundPartij.Postcode = reader["postcode"].ToString();
                foundPartij.Gemeente = reader["gemeente"].ToString();
                foundPartij.Tel = reader["tel"].ToString();
                foundPartij.Fax = reader["fax"].ToString();
                foundPartij.Gsm = reader["gsm"].ToString();
                foundPartij.Email = reader["email"].ToString();
                foundPartij.Type = int.Parse(reader["type_id"].ToString());
                foundPartij.Hoedanigheid = reader["hoedanigheid"].ToString();
                foundPartij.ContactPersoon = reader["contact"].ToString();
                try
                {
                    foundPartij.Hoofdpartij_id = int.Parse(reader["hoofdpartij_id"].ToString());
                }
                catch (FormatException fe)
                {
                    foundPartij.Hoofdpartij_id = 0;
                }

            }

            closeConnection();
            return foundPartij;
        }

        public void updatePartij(Partij partij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE partij";
            command.CommandText += " SET naam = \'" + partij.Naam.Replace("'", "\\'") + "\', referentie = \'" + partij.Referentie + "\', ";
            command.CommandText += "adres = \'" + partij.Adres.Replace("'", "\\'") + "\', ";
            command.CommandText += "postcode = \'" + partij.Postcode + "\', ";
            command.CommandText += "gemeente = \'" + partij.Gemeente + "\', tel = \'" + partij.Tel + "\', fax = \'" + partij.Fax + "\', ";
            command.CommandText += "gsm = \'" + partij.Gsm + "\', email = \'" + partij.Email + "\', type_id = \'" + partij.Type.ToString() + "\', ";
            command.CommandText += "hoedanigheid = \'" + partij.Hoedanigheid.Replace("'", "\\'") + "\', contact = \'" + partij.ContactPersoon + "\', hoofdpartij_id = \'" + partij.Hoofdpartij_id + "\'";
            command.CommandText += " WHERE id=" + partij.Id.ToString() + "; COMMIT;";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void createPartij(int dossierId, Partij partij)
        {
              if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "INSERT INTO `partij` (`dossier_id`, `naam`, `referentie`, `adres`, `postcode`, `gemeente`, `tel`, `fax`, `gsm`, `email`, `type_id`, `hoedanigheid`, `contact`, `hoofdpartij_id`)  VALUES ";
            command.CommandText+= "(\'"+ dossierId+"\', ";
            command.CommandText += "\'" + partij.Naam.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Referentie.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Adres.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Postcode.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Gemeente.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Tel.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Fax.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Gsm.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Email.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Type + "\', ";
            command.CommandText += "\'" + partij.Hoedanigheid.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.ContactPersoon.Replace("'", "\\'") + "\', ";
            command.CommandText += "\'" + partij.Hoofdpartij_id + "\');";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void deletePartij(Partij partij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "DELETE FROM partij WHERE id=\'"+partij.Id+"\' OR hoofdpartij_id=\'"+partij.Id+"\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

    }
}
