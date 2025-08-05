using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Dao
{
    class BeheerderDao
    {

        static BeheerderDao instance = null;
        static readonly object padlock = new object();

        BeheerderDao()
        {
        }

        public static BeheerderDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BeheerderDao();
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
        public Dictionary<string, Dictionary<string,int>> getBeheerders()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MaatschappijDao maatschappijDao = MaatschappijDao.Instance;
            Dictionary<string, Dictionary<string, int>> beheerders = new Dictionary<string, Dictionary<string, int>>();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * From beheerder Order By maatschappij_id";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            int id = -1;
            int key = -1;
            Dictionary<string, int> beheerdersnamen = null;
            string maatschappij = null;

            while (reader.Read())
            {


                try { id = int.Parse(reader["maatschappij_id"].ToString()); }
                catch (Exception e) { throw new Exception("e.Message"); }

                if (key == -1)
                {
                    key = id;
                    maatschappij = MaatschappijDao.Instance.getMaatschappijNaamById(id);
                    beheerdersnamen = new Dictionary<string, int>();
                    beheerdersnamen.Add(reader["naam"].ToString() + " " + reader["voornaam"].ToString(), int.Parse(reader["id"].ToString()));
                }
                else
                {
                    if (key != -1 && key == id) { beheerdersnamen.Add(reader["naam"].ToString() + " " + reader["voornaam"].ToString(), int.Parse(reader["id"].ToString())); ; }
                    else
                    {
                        beheerders.Add(maatschappij.ToUpper(), beheerdersnamen);
                        key = id;
                        maatschappij = MaatschappijDao.Instance.getMaatschappijNaamById(id);
                        beheerdersnamen = new Dictionary<string,int>();
                        beheerdersnamen.Add(reader["naam"].ToString() + " " + reader["voornaam"].ToString(), int.Parse(reader["id"].ToString())); ;
                    }
                }
            }

            beheerders.Add(maatschappij.ToUpper(), beheerdersnamen);

            closeConnection();

            return beheerders;
        }

        public ArrayList getBeheerdersDetailByMaatschappij(string maatschappij)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList beheerders = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM beheerder WHERE maatschappij_id = (SELECT id FROM maatschappij WHERE UPPER(naam) = \'" + maatschappij.Replace("'", "\\'") + "\');";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Beheerder beheerder;

                try
                {
                    beheerder = new Beheerder(maatschappij, reader["naam"].ToString());
                    beheerder.Id = int.Parse(reader["id"].ToString());
                    beheerder.Voornaam = reader["voornaam"].ToString();
                    beheerder.Aanspreektitel = reader["aanspreektitel"].ToString();
                    beheerder.Telefoon = reader["tel"].ToString();
                    beheerder.Fax = reader["fax"].ToString();
                    beheerder.Email = reader["email"].ToString();
                }
                catch (FormatException fe)
                {
                    throw fe;
                }
                catch (Exception e)
                {
                    throw new Exception("De Beheerder kon niet gevonden worden of omgezet");
                }

                beheerders.Add(beheerder);
            }

            closeConnection();

            return beheerders;
        }

        public Beheerder getBeheerder(int idMaatschappij, Beheerder beheerderToFind)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM beheerder WHERE maatschappij_id =" + idMaatschappij + " And ";
            if (beheerderToFind.Naam.Equals("")) command.CommandText += "(naam IS NULL OR naam = \'\') AND "; else command.CommandText += "naam=\'" + beheerderToFind.Naam.Replace("'", "\\'") + "\' AND ";
            if (beheerderToFind.Voornaam.Equals("")) command.CommandText += "(voornaam IS NULL OR voornaam = \'\') AND "; else command.CommandText += "voornaam=\'" + beheerderToFind.Voornaam.Replace("'", "\\'") + "\' AND ";
            if (beheerderToFind.Telefoon.Equals("")) command.CommandText += "(tel IS NULL OR tel = \'\') AND "; else command.CommandText += "tel=\'" + beheerderToFind.Telefoon.Replace("'", "\\'") + "\' AND ";
            if (beheerderToFind.Fax.Equals("")) command.CommandText += "(fax IS NULL OR fax = \'\') AND "; else command.CommandText += "fax=\'" + beheerderToFind.Fax.Replace("'", "\\'") + "\' AND ";
            if (beheerderToFind.Email.Equals("")) command.CommandText += "(email IS NULL OR email = \'\') AND "; else command.CommandText += "email=\'" + beheerderToFind.Email.Replace("'", "\\'") + "\' AND ";
            if (beheerderToFind.Aanspreektitel.Equals("")) command.CommandText += "(aanspreektitel IS NULL OR aanspreektitel = \'\');"; else command.CommandText += "aanspreektitel=\'" + beheerderToFind.Aanspreektitel.Replace("'", "\\'") + "\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            Beheerder beheerder = null;
            while (reader.Read())
            {
                try
                {
                    beheerder = new Beheerder(MaatschappijDao.Instance.getMaatschappijNaamById(idMaatschappij), reader["naam"].ToString());
                    beheerder.Voornaam = reader["voornaam"].ToString();
                    beheerder.Aanspreektitel = reader["aanspreektitel"].ToString();
                    beheerder.Telefoon = reader["tel"].ToString();
                    beheerder.Fax = reader["fax"].ToString();
                    beheerder.Email = reader["email"].ToString();
                }
                catch (FormatException fe)
                {
                    throw fe;
                }
                catch (Exception e)
                {
                    throw new Exception("De Beheerder kon niet gevonden worden of omgezet");
                }

            }

            closeConnection();
            return beheerder;
        }

        #endregion

        #region Create
        public void AddBeheerder(Beheerder beheerder)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = createInsertStatement(beheerder);
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
        public string createInsertStatement(Beheerder beheerder)
        {
            string statement = "INSERT INTO `db_mertens`.`beheerder` (`maatschappij_id`, `aanspreektitel`, `naam`, `voornaam`, `tel`, `fax`, `email`) VALUES (";

            ArrayList gegevens = new ArrayList();
            int i = 0;

            gegevens.Add(MaatschappijDao.Instance.getMaatschappijByNaam(beheerder.Maatschappij).Id.ToString());
            if (beheerder.Aanspreektitel == null) gegevens.Add(""); else { gegevens.Add(beheerder.Aanspreektitel.Replace("'", "\\'")); }
            if (beheerder.Naam == null) gegevens.Add(""); else { gegevens.Add(beheerder.Naam.Replace("'", "\\'")); }
            if (beheerder.Voornaam == null) gegevens.Add(""); else { gegevens.Add(beheerder.Voornaam.Replace("'", "\\'")); }
            if (beheerder.Telefoon == null) gegevens.Add(""); else { gegevens.Add(beheerder.Telefoon.Replace("'", "\\'")); }
            if (beheerder.Fax == null) gegevens.Add(""); else { gegevens.Add(beheerder.Fax.Replace("'", "\\'")); }
            if (beheerder.Email == null) gegevens.Add(""); else { gegevens.Add(beheerder.Email.Replace("'", "\\'")); }

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

        #region Delete
        public void deleteBeheerder(Beheerder beheerder)
        {

            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            MySqlDataReader reader;
            string id = "";

            //Retrieve the unique 'beheerder'
            command.CommandText = "SELECT id FROM beheerder WHERE naam = \'" + beheerder.Naam + "\' And voornaam = \'" + beheerder.Voornaam + "\' And tel = \'" + beheerder.Telefoon + "\' And fax = \'" + beheerder.Fax + "\'And email = \'" + beheerder.Email + "\' And aanspreektitel = \'" + beheerder.Aanspreektitel + "\';";
            openConnection();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    id = reader["id"].ToString();
                }
                catch (FormatException fe)
                {
                    throw fe;
                }
                catch (Exception e)
                {
                    throw new Exception("De Beheerder kon niet gevonden worden of omgezet");
                }
            }
            closeConnection();
            
            //Update the referance to the 'beheerder' in 'dossier' to -1 = unknown
            command.CommandText = "UPDATE dossier SET beheerder_id=\'-1\' where beheerder_id=\'"+id+"\'";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
            command.CommandText = "DELETE FROM beheerder WHERE naam = \'" + beheerder.Naam + "\' And voornaam = \'" + beheerder.Voornaam + "\' And tel = \'" + beheerder.Telefoon + "\' And fax = \'" + beheerder.Fax + "\'And email = \'" + beheerder.Email + "\' And aanspreektitel = \'" + beheerder.Aanspreektitel + "\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        } 
        #endregion


        public void updateBeheerder(Beheerder beheerder, Beheerder newBeheerder)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE beheerder";
            command.CommandText += " SET aanspreektitel = \'" + newBeheerder.Aanspreektitel.Replace("'", "\\'") + "\' ,naam = \'" + newBeheerder.Naam.Replace("'", "\\'") + "\' ,voornaam = \'" + newBeheerder.Voornaam.Replace("'", "\\'") + "\' ,tel = \'" + newBeheerder.Telefoon.Replace("'", "\\'") + "\' ,fax = \'" + newBeheerder.Fax.Replace("'", "\\'") + "\',email = \'" + newBeheerder.Email.Replace("'", "\\'") + "\'"; 
            command.CommandText += " WHERE ";
            if (beheerder.Aanspreektitel.Equals("")) command.CommandText += "(aanspreektitel IS NULL OR aanspreektitel = \'\') AND "; else command.CommandText += "aanspreektitel=\'" + beheerder.Aanspreektitel.Replace("'", "\\'") + "\' AND ";
            if (beheerder.Naam.Equals("")) command.CommandText += "(naam IS NULL OR naam = \'\') AND "; else command.CommandText += "naam=\'" + beheerder.Naam.Replace("'", "\\'") + "\' AND ";
            if (beheerder.Voornaam.Equals("")) command.CommandText += "(voornaam IS NULL OR voornaam = \'\') AND "; else command.CommandText += "voornaam=\'" + beheerder.Voornaam.Replace("'", "\\'") + "\' AND ";
            if (beheerder.Telefoon.Equals("")) command.CommandText += "(tel IS NULL OR tel = \'\') AND "; else command.CommandText += "tel=\'" + beheerder.Telefoon.Replace("'", "\\'") + "\' AND ";
            if (beheerder.Fax.Equals("")) command.CommandText += "(fax IS NULL OR fax = \'\') AND "; else command.CommandText += "fax=\'" + beheerder.Fax.Replace("'", "\\'") + "\' AND ";
            if (beheerder.Email.Equals("")) command.CommandText += "(email IS NULL OR email = \'\');"; else command.CommandText += "email=\'" + beheerder.Email.Replace("'", "\\'") + "\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
