using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Mertens.BusinessLogic;
using System.Collections;

namespace Mertens.Dao
{
    class PrestatieDao
    {
        static PrestatieDao instance = null;
        static readonly object padlock = new object();

        PrestatieDao() { }

        public static PrestatieDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PrestatieDao();
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

        public Prestatie getOpenstaandePrestatie(int dossierId)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM prestatie where dossierId=\'"+dossierId+"\' AND openstaand=\'1\';" ;
            MySqlDataReader reader;

            openConnection();

            Prestatie prestatie = null;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                prestatie = new Prestatie();
                prestatie.Id = int.Parse(reader["id"].ToString());
                prestatie.DossierId = int.Parse(reader["dossierId"].ToString());
                prestatie.Werkdatum = reader["werkdatum"].ToString();
                prestatie.Herinnerdatum = reader["herinnerdatum"].ToString();
                prestatie.HerinnerCommentaar = reader["herinnercommentaar"].ToString();
                prestatie.Btw = float.Parse(reader["btw"].ToString());
                prestatie.TotaalErelonen = float.Parse(reader["totaal_erelonen"].ToString());
                prestatie.TotaalOnkosten = float.Parse(reader["totaal_onkosten"].ToString());
                prestatie.TotaalBtw = float.Parse(reader["totaal_btw"].ToString());
                prestatie.Historiek= reader["historiek"].ToString();
                prestatie.Tariefniveau = reader["tariefniveau"].ToString();
                if (int.Parse(reader["openstaand"].ToString()) == 1)
                {
                    prestatie.Openstaand = true;
                }
                else { prestatie.Openstaand = false; }
            }


            closeConnection();
            
            return prestatie;
        }

        public Prestatie getPrestatieById(int prestatieId)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM prestatie where id=\'" + prestatieId + "\';";
            MySqlDataReader reader;

            openConnection();

            Prestatie prestatie = null;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                prestatie = new Prestatie();
                prestatie.Id = int.Parse(reader["id"].ToString());
                prestatie.DossierId = int.Parse(reader["dossierId"].ToString());
                prestatie.Werkdatum = reader["werkdatum"].ToString();
                prestatie.Herinnerdatum = reader["herinnerdatum"].ToString();
                prestatie.HerinnerCommentaar = reader["herinnercommentaar"].ToString();
                prestatie.Btw = float.Parse(reader["btw"].ToString());
                prestatie.TotaalErelonen = float.Parse(reader["totaal_erelonen"].ToString());
                prestatie.TotaalOnkosten = float.Parse(reader["totaal_onkosten"].ToString());
                prestatie.TotaalBtw = float.Parse(reader["totaal_btw"].ToString());
                prestatie.Historiek = reader["historiek"].ToString();
                prestatie.Tariefniveau = reader["tariefniveau"].ToString();
                if (int.Parse(reader["openstaand"].ToString()) == 1)
                {
                    prestatie.Openstaand = true;
                }
                else { prestatie.Openstaand = false; }
            }


            closeConnection();

            return prestatie;
        }

        public int getLatestPrestatie(int dossierId)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT id FROM prestatie WHERE dossierId=\'"+dossierId+"\' ORDER BY id DESC;";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            reader.Read();
            int latestId = 0;

            try
            {
                latestId = int.Parse(reader["id"].ToString());
            }
            catch (FormatException fe)
            {
                closeConnection();
                return -1;
            }

            closeConnection();

            return latestId;
        }

        public Prestatie getPrestatieByDossierReferentie(String referentie)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM prestatie WHERE dossierId IN (SELECT id FROM dossier WHERE referentie=\'"+referentie+"\');";
            MySqlDataReader reader;

            openConnection();

            Prestatie prestatie = null;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                prestatie = new Prestatie();
                prestatie.Id = int.Parse(reader["id"].ToString());
                prestatie.DossierId = int.Parse(reader["dossierId"].ToString());
                prestatie.Werkdatum = reader["werkdatum"].ToString();
                prestatie.Herinnerdatum = reader["herinnerdatum"].ToString();
                prestatie.HerinnerCommentaar = reader["herinnercommentaar"].ToString();
                prestatie.Btw = float.Parse(reader["btw"].ToString());
                prestatie.TotaalErelonen = float.Parse(reader["totaal_erelonen"].ToString());
                prestatie.TotaalOnkosten = float.Parse(reader["totaal_onkosten"].ToString());
                prestatie.TotaalBtw = float.Parse(reader["totaal_btw"].ToString());
                prestatie.Historiek = reader["historiek"].ToString();
                prestatie.Tariefniveau = reader["tariefniveau"].ToString();
                if (int.Parse(reader["openstaand"].ToString()) == 1)
                {
                    prestatie.Openstaand = true;
                }
                else { prestatie.Openstaand = false; }
            }


            closeConnection();

            return prestatie;
        }

        public void createNewPrestatie(Prestatie prestatie)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "INSERT INTO `prestatie` (`dossierId`, `werkdatum`, `herinnerdatum`, `btw`, `totaal_erelonen`, `totaal_onkosten`, `totaal_btw`, `historiek`, `tariefniveau`, `openstaand`) VALUES ("; 
            command.CommandText += "\'"+prestatie.DossierId+"\',"; 
            command.CommandText += "\'"+prestatie.Werkdatum+"\',"; 
            command.CommandText += "\'"+prestatie.Herinnerdatum+"\',"; 
            command.CommandText += "\'"+prestatie.Btw+"\',";
            command.CommandText += "\'"+prestatie.TotaalErelonen+"\',";
            command.CommandText += "\'"+prestatie.TotaalOnkosten+"\',";
            command.CommandText += "\'"+prestatie.TotaalBtw+"\',";
            command.CommandText += "\'"+prestatie.Historiek.Replace("\'","\\\'")+"\',";
            command.CommandText += "\'"+prestatie.Tariefniveau+"\',";
            if(prestatie.Openstaand == true) command.CommandText += "\'1\');";
            if(prestatie.Openstaand == false) command.CommandText += "\'0\');";
            
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void updatePrestatie(Prestatie prestatie)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE prestatie SET ";
            command.CommandText += "`werkdatum`=\'"+prestatie.Werkdatum+"\', ";
            command.CommandText += "`herinnerdatum`=\'"+prestatie.Herinnerdatum+"\', ";
            command.CommandText += "`herinnercommentaar`=\'" + prestatie.HerinnerCommentaar.Replace("'", "\\'") + "\', ";
            command.CommandText += "`btw`=\'"+prestatie.Btw.ToString().Replace(',','.')+"\', ";
            command.CommandText += "`totaal_erelonen`=\'" + prestatie.TotaalErelonen.ToString().Replace(',', '.') + "\', ";
            command.CommandText += "`totaal_onkosten`=\'" + prestatie.TotaalOnkosten.ToString().Replace(',', '.') + "\', ";
            command.CommandText += "`totaal_btw`=\'" + prestatie.TotaalBtw.ToString().Replace(',', '.') + "\', ";
            command.CommandText += "`historiek`=\'" + prestatie.Historiek.Replace("'", "\\'") + "\', "; 
            command.CommandText += "`tariefniveau`=\'"+prestatie.Tariefniveau+"\' ";
            command.CommandText += "WHERE `id`=\'"+prestatie.Id+"\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public ArrayList getVerwachtlijst()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT d.referentie, p.herinnerdatum FROM dossier d, prestatie p WHERE p.dossierId = d.id AND d.id in (SELECT dossierId FROM prestatie WHERE openstaand='1' AND herinnerdatum NOT LIKE '') ORDER BY d.referentie;";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            ArrayList verwachtlijst = new ArrayList();

            while (reader.Read())
            {
                string lijn = reader["referentie"].ToString() +"\t" + reader["herinnerdatum"].ToString();
                verwachtlijst.Add(lijn);
            }


            closeConnection();

            return verwachtlijst;
        }

        public void deletePrestatie(int id)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }
            MySqlCommand command = this.connection.CreateCommand();
            openConnection();
            command.CommandText = "DELETE FROM prestatie WHERE id=\'" + id + "\';";
            command.ExecuteNonQuery();
            command.CommandText += "DELETE FROM kost WHERE prestatieId=\'" + id + "\';";
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
