using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;
namespace Mertens.Dao
{
    class PrijslijstDao
    {
        static PrijslijstDao instance = null;
        static readonly object padlock = new object();

        PrijslijstDao()
        {
        }

        public static PrijslijstDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PrijslijstDao();
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

        public ArrayList getPriceList()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList prijslijst = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * From kostendetail";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                KostDetail detail = new KostDetail();
                detail.Id = int.Parse(reader["id"].ToString());
                detail.Type = reader["type"].ToString()[0];
                detail.Omschrijving = reader["beschrijving"].ToString();
                detail.Prijslaag = float.Parse(reader["prijslaag"].ToString());
                detail.Prijsmedium = float.Parse(reader["prijsmedium"].ToString());
                detail.Prijshoog = float.Parse(reader["prijshoog"].ToString());
                prijslijst.Add(detail);
            }

            closeConnection();

            return prijslijst;
        }

        public ArrayList getPriceListErelonen()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList prijslijst = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM kostendetail WHERE type = \'E\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                KostDetail detail = new KostDetail();
                detail.Id = int.Parse(reader["id"].ToString());
                detail.Type = reader["type"].ToString()[0];
                detail.Omschrijving = reader["beschrijving"].ToString();
                detail.Prijslaag = float.Parse(reader["prijslaag"].ToString());
                detail.Prijsmedium = float.Parse(reader["prijsmedium"].ToString());
                detail.Prijshoog = float.Parse(reader["prijshoog"].ToString());
                prijslijst.Add(detail);
            }

            closeConnection();

            return prijslijst;
        }

        public ArrayList getPriceListOnkosten()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList prijslijst = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM kostendetail WHERE type = \'O\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                KostDetail detail = new KostDetail();
                detail.Id = int.Parse(reader["id"].ToString());
                detail.Type = reader["type"].ToString()[0];
                detail.Omschrijving = reader["beschrijving"].ToString();
                detail.Prijslaag = float.Parse(reader["prijslaag"].ToString());
                detail.Prijsmedium = float.Parse(reader["prijsmedium"].ToString());
                detail.Prijshoog = float.Parse(reader["prijshoog"].ToString());
                prijslijst.Add(detail);
            }

            closeConnection();

            return prijslijst;
        }

        public KostDetail getKostDetailById(int id)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList prijslijst = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM kostendetail WHERE id = \'" + id + "\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            KostDetail detail = null;
            while (reader.Read())
            {
                detail = new KostDetail();
                detail.Id = int.Parse(reader["id"].ToString());
                detail.Type = reader["type"].ToString()[0];
                detail.Omschrijving = reader["beschrijving"].ToString();
                detail.Prijslaag = float.Parse(reader["prijslaag"].ToString());
                detail.Prijsmedium = float.Parse(reader["prijsmedium"].ToString());
                detail.Prijshoog = float.Parse(reader["prijshoog"].ToString());

            }
            closeConnection();
            return detail;
        }

        public KostDetail getKostDetailByOmschrijving(String omschrijving)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList prijslijst = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM kostendetail WHERE beschrijving = \'" + omschrijving + "\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            KostDetail detail = null;
            while (reader.Read())
            {
                detail = new KostDetail();
                detail.Id = int.Parse(reader["id"].ToString());
                detail.Type = reader["type"].ToString()[0];
                detail.Omschrijving = reader["beschrijving"].ToString();
                detail.Prijslaag = float.Parse(reader["prijslaag"].ToString());
                detail.Prijsmedium = float.Parse(reader["prijsmedium"].ToString());
                detail.Prijshoog = float.Parse(reader["prijshoog"].ToString());

            }
            closeConnection();
            return detail;
        }

        public void updateKostDetail(KostDetail detail)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE kostendetail SET ";
            command.CommandText += "`type`=\'" + detail.Type + "\', ";
            command.CommandText += "`beschrijving`=\'" + detail.Omschrijving + "\', ";
            command.CommandText += "`prijslaag`=\'" + detail.Prijslaag.ToString().Replace(',', '.') + "\', ";
            command.CommandText += "`prijsmedium`=\'" + detail.Prijsmedium.ToString().Replace(',', '.') + "\', ";
            command.CommandText += "`prijshoog`=\'" + detail.Prijshoog.ToString().Replace(',', '.') + "\'";
            command.CommandText += "WHERE `id`=\'" + detail.Id + "\';";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
