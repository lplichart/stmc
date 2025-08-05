using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Mertens.BusinessLogic;
using System.Collections;

namespace Mertens.Dao
{
    class FactuurDao
    {
        static FactuurDao instance = null;
        static readonly object padlock = new object();

        FactuurDao()
        {
        }

        public static FactuurDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FactuurDao();
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

        public string getLatestFactuurNummer()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select factuurnummer from factuur order by factuurnummer desc";
            MySqlDataReader reader;
            string factuurnummer = "";

            openConnection();

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                factuurnummer = reader["factuurnummer"].ToString();
            }

            closeConnection();
            return factuurnummer;
        }

        public void createFactuur(Factuur factuur)
        {
             if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "INSERT INTO factuur (`datum`, `factuurnummer`, `referentie`, `erelonen`, `onkosten`, `btw`, `totaal`, `prestatie_id`, `expert`) VALUES (";
            command.CommandText += "\'" + factuur.Datum + "\',";
            command.CommandText += "\'" + factuur.Factuurnummer + "\',";
            command.CommandText += "\'" + factuur.Referentie + "\',";
            command.CommandText += "\'" + factuur.Erelonen.ToString().Replace(',','.') + "\',";
            command.CommandText += "\'" + factuur.Onkosten.ToString().Replace(',', '.') + "\',";
            command.CommandText += "\'" + factuur.Btw.ToString().Replace(',', '.') + "\',";
            command.CommandText += "\'" + factuur.Totaal.ToString().Replace(',', '.') + "\',";
            command.CommandText += "\'" + factuur.Prestatie_id.ToString() + "\',";
            command.CommandText += "\'" + factuur.Expert + "\');";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public ArrayList getFactuurPerExpert(String maand, string jaar, string expert)
        {
             if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList facturen = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select f.*, m.naam from factuur f, dossier d, maatschappij m where f.referentie=d.referentie AND d.maatschappij_id=m.id AND datum LIKE \'%%/" + maand + "/" + jaar + "\' AND expert = \'" + expert + "\' Order By factuurnummer;";
            // "Select f.id, f.datum, f.factuurnummer, f.referentie, f.erelonen, f.onkosten, f.btw, f.totaal, f.prestatie_id, f.expert, m.naam from factuur f, dossier d, maatschappij m where f.referentie=d.referentie AND d.maatschappij_id=m.id AND datum LIKE \'%%/" + maand + "/" + jaar + "\' AND expert = \'" + expert + "\' Order By factuurnummer;";    
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Factuur factuur = new Factuur();
                try
                {
                    factuur.Id = int.Parse(reader["id"].ToString());
                    factuur.Datum = reader["datum"].ToString();
                    factuur.Factuurnummer = reader["factuurnummer"].ToString();
                    factuur.Referentie = reader["referentie"].ToString();
                    factuur.Erelonen = float.Parse(reader["erelonen"].ToString());
                    factuur.Onkosten = float.Parse(reader["onkosten"].ToString());
                    factuur.Btw = float.Parse(reader["btw"].ToString());
                    factuur.Totaal = float.Parse(reader["totaal"].ToString());
                    factuur.Prestatie_id = int.Parse(reader["prestatie_id"].ToString());
                    factuur.Expert = reader["expert"].ToString()[0];
                    factuur.Maatschappij = reader["naam"].ToString();

                } catch (Exception e){};

                facturen.Add(factuur);
            }

            connection.Close();

            return facturen;
        }

        public ArrayList getAllFacturenPerMonthAndYear(String maand, string jaar)
        {
             if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList facturen = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select f.*, m.naam from factuur f, dossier d, maatschappij m where f.referentie=d.referentie AND d.maatschappij_id=m.id  AND datum LIKE \'%%/" + maand + "/" + jaar + "\' Order By factuurnummer;";
            //"Select * from factuur where datum LIKE \'%%/" + maand + "/" + jaar + "\' Order By factuurnummer;";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Factuur factuur = new Factuur();
                try
                {
                    factuur.Id = int.Parse(reader["id"].ToString());
                    factuur.Datum = reader["datum"].ToString();
                    factuur.Factuurnummer = reader["factuurnummer"].ToString();
                    factuur.Referentie = reader["referentie"].ToString();
                    factuur.Erelonen = float.Parse(reader["erelonen"].ToString());
                    factuur.Onkosten = float.Parse(reader["onkosten"].ToString());
                    factuur.Btw = float.Parse(reader["btw"].ToString());
                    factuur.Totaal = float.Parse(reader["totaal"].ToString());
                    factuur.Prestatie_id = int.Parse(reader["prestatie_id"].ToString());
                    factuur.Expert = reader["expert"].ToString()[0];
                    factuur.Maatschappij = reader["naam"].ToString();

                } catch (Exception e){};

                facturen.Add(factuur);
            }

            connection.Close();

            return facturen;
        }

        public ArrayList getAllFacturen()
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList facturen = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select f.id, f.datum, f.factuurnummer, d.referentie, d.date_in ,f.erelonen, f.onkosten, f.btw, f.totaal, f.expert, m.naam from factuur f, dossier d, maatschappij m where f.referentie = d.referentie and d.maatschappij_id = m.id;";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Factuur factuur = new Factuur();
                try
                {
                    factuur.Id = int.Parse(reader["id"].ToString());
                    factuur.Datum = reader["datum"].ToString();
                    factuur.Factuurnummer = reader["factuurnummer"].ToString();
                    factuur.Referentie = reader["referentie"].ToString();
                    factuur.DatumDossier = reader["date_in"].ToString();
                    factuur.Erelonen = float.Parse(reader["erelonen"].ToString());
                    factuur.Onkosten = float.Parse(reader["onkosten"].ToString());
                    factuur.Btw = float.Parse(reader["btw"].ToString());
                    factuur.Totaal = float.Parse(reader["totaal"].ToString());
                    factuur.Expert = reader["expert"].ToString().ToCharArray(0, 1)[0];
                    factuur.Maatschappij = reader["naam"].ToString();

                }
                catch (Exception e) { };

                facturen.Add(factuur);
            }

            connection.Close();

            return facturen;
        }

        public Boolean factuurExists(string factuurnummer)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * from factuur where factuurnummer=\'"+factuurnummer+"\';";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                closeConnection();
                return true; 
            }

            closeConnection();
            return false;
        }
        
    }
}
