using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Dao
{
    class KostDao
    {
        static KostDao instance = null;
        static readonly object padlock = new object();

        KostDao() { }

        public static KostDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new KostDao();
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

        public Dictionary<string, float> getTarieven(string tarief)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            string tariefkolom = "";

            switch (tarief)
            {
                case "laag": tariefkolom = "prijslaag"; break;
                case "medium": tariefkolom = "prijsmedium"; break;
                case "hoog": tariefkolom = "prijshoog"; break;
            }

            Dictionary<string, float> tarieven = new Dictionary<string, float>();

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select beschrijving, " + tariefkolom + " From kostendetail";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    tarieven.Add(reader["beschrijving"].ToString(), float.Parse(reader[tariefkolom].ToString()));
                }
                catch (FormatException fe) { };
            }

            closeConnection();

            return tarieven;
        }

        public ArrayList getKostOmschrijving(char type)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList omschrijvingen = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT beschrijving FROM kostendetail WHERE type=\'" + type + "\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    omschrijvingen.Add(reader["beschrijving"].ToString());
                }
                catch (FormatException fe) { };
            }

            closeConnection();

            return omschrijvingen;
        }

        public ArrayList getKostPerPost(int prestatieId, string post)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM kost WHERE prestatieId=\'" + prestatieId + "\' AND UPPER(kostenPost) = UPPER(\'" +post+ "\');";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            ArrayList kosten = new ArrayList();

            while (reader.Read())
            {
                try
                {
                    Kost kost = new Kost();
                    kost.Id = int.Parse(reader["id"].ToString());
                    kost.PrestatieId = int.Parse(reader["prestatieId"].ToString());
                    kost.Type = reader["type"].ToString()[0];
                    kost.Datum = reader["datum"].ToString(); 
                    kost.Omschrijving = reader["omschrijving"].ToString();
                    kost.Commentaar = reader["commentaar"].ToString();
                    kost.Hoeveelheid = float.Parse(reader["hoeveelheid"].ToString());
                    kost.Eenheidsprijs = float.Parse(reader["eenheidsprijs"].ToString());
                    kost.Totaal = float.Parse(reader["totaal"].ToString());
                    kost.HoofdKostId = int.Parse(reader["hoofdKostId"].ToString());
                    kost.KostenPost = reader["kostenPost"].ToString();
                    kosten.Add(kost);

                }
                catch (FormatException fe) { };
            }

            closeConnection();

            return kosten;
        }

        public ArrayList getKostenByPrestatie(int prestatieId)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM kost WHERE prestatieId=\'" + prestatieId + "\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            ArrayList kosten = new ArrayList();

            while (reader.Read())
            {
                try
                {
                    Kost kost = new Kost();
                    kost.Id = int.Parse(reader["id"].ToString());
                    kost.PrestatieId = int.Parse(reader["prestatieId"].ToString());
                    kost.Type = reader["type"].ToString()[0];
                    kost.Datum = reader["datum"].ToString();
                    kost.Omschrijving = reader["omschrijving"].ToString();
                    kost.Commentaar = reader["commentaar"].ToString();
                    kost.Hoeveelheid = float.Parse(reader["hoeveelheid"].ToString());
                    kost.Eenheidsprijs = float.Parse(reader["eenheidsprijs"].ToString());
                    kost.Totaal = float.Parse(reader["totaal"].ToString());
                    kost.HoofdKostId = int.Parse(reader["hoofdKostId"].ToString());
                    kost.KostenPost = reader["kostenPost"].ToString();
                    kosten.Add(kost);

                }
                catch (FormatException fe) { };
            }

            closeConnection();

            return kosten;
        }

        public int getLatestKostId(int prestatieId)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT id FROM kost WHERE prestatieId=\'"+prestatieId+"\' ORDER BY id DESC;";
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

        public void createKost(Kost kost)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "INSERT INTO `db_mertens`.`kost` (`prestatieId`, `type`, `datum`, `omschrijving`, `commentaar`, `hoeveelheid`, `eenheidsprijs`, `totaal`, `hoofdKostId`, `kostenPost`) VALUES (";
            command.CommandText += "\'" + kost.PrestatieId + "\',";
            command.CommandText += "\'" + kost.Type + "\',";
            command.CommandText += "\'" + kost.Datum + "\',";
            command.CommandText += "\'" + kost.Omschrijving.Replace("'", "\\'") + "\',";
            command.CommandText += "\'" + kost.Commentaar.Replace("'", "\\'") + "\',";
            command.CommandText += "\'" + kost.Hoeveelheid.ToString().Replace(',', '.') + "\',";
            command.CommandText += "\'" + kost.Eenheidsprijs.ToString().Replace(',','.') + "\',";
            command.CommandText += "\'" + kost.Totaal.ToString().Replace(',', '.') + "\',";
            command.CommandText += "\'" + kost.HoofdKostId + "\',";
            command.CommandText += "\'" + kost.KostenPost + "\');";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public float getTotaal(int prestatieId, char soortKost)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT SUM(totaal) Totaal FROM kost WHERE prestatieId = \'"+prestatieId+"\' AND  type = \'"+soortKost+"\'";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            reader.Read();
            float totaal = 0;

            try
            {
                totaal = float.Parse(reader["Totaal"].ToString());
            }
            catch (FormatException fe)
            {
                closeConnection();
                return 0;
            }


            closeConnection();

            return totaal;
        }

        public Kost getKostById(int id)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM kost WHERE id=\'"+id+"\';";
            MySqlDataReader reader;
            Kost kost = new Kost(); ;

            openConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    kost.Id = int.Parse(reader["id"].ToString());
                    kost.PrestatieId = int.Parse(reader["prestatieId"].ToString());
                    kost.Type = reader["type"].ToString()[0];
                    kost.Datum = reader["datum"].ToString();
                    kost.Omschrijving = reader["omschrijving"].ToString();
                    kost.Commentaar = reader["commentaar"].ToString();
                    kost.Hoeveelheid = float.Parse(reader["hoeveelheid"].ToString());
                    kost.Eenheidsprijs = float.Parse(reader["eenheidsprijs"].ToString());
                    kost.Totaal = float.Parse(reader["totaal"].ToString());
                    kost.HoofdKostId = int.Parse(reader["hoofdKostId"].ToString());
                    kost.KostenPost = reader["kostenPost"].ToString();

                }
                catch (FormatException fe) { };
            }

            closeConnection();

            return kost;
        }

        public void updateKost(Kost kost)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE kost SET ";
            command.CommandText += "`type`=\'"+kost.Type+"\', ";
            command.CommandText += "`datum`=\'"+kost.Datum+"\', ";
            command.CommandText += "`omschrijving`=\'" + kost.Omschrijving.Replace("'", "\\'") + "\', ";
            command.CommandText += "`commentaar`=\'" + kost.Commentaar.Replace("'", "\\'") + "\', ";
            command.CommandText += "`hoeveelheid`=\'"+kost.Hoeveelheid.ToString().Replace(',','.')+"\', ";
            command.CommandText += "`eenheidsprijs`=\'"+kost.Eenheidsprijs.ToString().Replace(',','.')+"\', ";
            command.CommandText += "`totaal`=\'"+kost.Totaal.ToString().Replace(',','.')+"\', ";
            command.CommandText += "`hoofdKostId`=\'"+kost.HoofdKostId+"\', ";
            command.CommandText += "`kostenPost`=\'"+kost.KostenPost+"\' ";
            command.CommandText += "WHERE `id`=\'"+kost.Id+"\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void deleteKost(Kost kost)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "DELETE FROM kost WHERE id=\'" + kost.Id + "\' OR hoofdKostId=\'" + kost.Id + "\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}