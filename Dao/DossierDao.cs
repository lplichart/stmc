using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using Mertens.BusinessLogic;

namespace Mertens.Dao
{
    class DossierDao
    {

        static DossierDao instance = null;
        static readonly object padlock = new object();

        DossierDao()
        {
        }

        public static DossierDao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DossierDao();
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

        public ArrayList getDossiers(string query)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList dossiers = new ArrayList();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = query;
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dossier dossier;

                try
                {
                    dossier = new Dossier(reader["referentie"].ToString(), reader["date_in"].ToString());
                    dossier.Date_out = reader["date_out"].ToString();
                    dossier.Id = int.Parse(reader["id"].ToString());
                    dossier.Referentie_Maatschappij = reader["referentie_maatschappij"].ToString();
                    dossier.Polis = reader["polis"].ToString();
                    dossier.Contract = reader["contract"].ToString();
                    dossier.Pvds_datum = reader["pvds_datum"].ToString();
                    dossier.Pvds_naam = reader["pvds_naam"].ToString();
                    dossier.Pvds_straat = reader["pvds_straat"].ToString();
                    dossier.Pvds_nr = reader["pvds_nr"].ToString();
                    dossier.Pvds_postcode = reader["pvds_postcode"].ToString();
                    dossier.Pvds_gemeente = reader["pvds_gemeente"].ToString();
                    dossier.Pvds_omvang = reader["pvds_omvang"].ToString();
                    dossier.Plaatsbezoek = reader["plaatsbezoek"].ToString();
                    dossier.Opdracht = reader["opdracht"].ToString();
                    dossier.Opmerking = reader["opmerking"].ToString();
                }
                catch (FormatException fe)
                {
                    throw fe;
                }

                try
                {
                    MaatschappijDao maatschappijDao = MaatschappijDao.Instance;
                    dossier.Maatschappij = maatschappijDao.getMaatschappijNaamById(int.Parse(reader["maatschappij_id"].ToString()));
                }
                catch (FormatException fe)
                {
                    dossier.Maatschappij = "";
                }
                catch (Exception e)
                {
                    throw new Exception("De maatschappij kon niet gevonden worden of omgezet");
                }


                dossiers.Add(dossier);
            }

            closeConnection();

            return dossiers;
        }

        public Dossier getDossierByReference(string referentie)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            Dossier dossier = new Dossier();
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * from dossier where referentie=\'"+referentie+"\'";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    dossier.Id = int.Parse(reader["id"].ToString());
                    dossier.Referentie = reader["referentie"].ToString();
                    dossier.Date_in = reader["date_in"].ToString();
                    dossier.Date_out = reader["date_out"].ToString();
                    dossier.Referentie_Maatschappij = reader["referentie_maatschappij"].ToString();
                    dossier.Polis = reader["polis"].ToString();
                    dossier.Contract = reader["contract"].ToString();
                    dossier.Pvds_datum = reader["pvds_datum"].ToString();
                    dossier.Pvds_naam = reader["pvds_naam"].ToString();
                    dossier.Pvds_straat = reader["pvds_straat"].ToString();
                    dossier.Pvds_nr = reader["pvds_nr"].ToString();
                    dossier.Pvds_postcode = reader["pvds_postcode"].ToString();
                    dossier.Pvds_gemeente = reader["pvds_gemeente"].ToString();
                    dossier.Pvds_omvang = reader["pvds_omvang"].ToString();
                    dossier.Plaatsbezoek = reader["plaatsbezoek"].ToString();
                    dossier.Opdracht = reader["opdracht"].ToString();
                    dossier.Opmerking = reader["opmerking"].ToString();
                }
                catch (Exception e)
                {}
                
            }

            closeConnection();

            return dossier;
        }

        public ArrayList getDossiersByReferenceLike(string referentie)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            ArrayList dossiers = null;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "SELECT * FROM dossier WHERE referentie LIKE \'%" + referentie + "%\'";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();
            dossiers = new ArrayList();

            while (reader.Read())
            {
                try
                {
                    Dossier dossier = new Dossier();
                    dossier.Id = int.Parse(reader["id"].ToString());
                    dossier.Referentie = reader["referentie"].ToString();
                    dossier.Date_in = reader["date_in"].ToString();
                    dossier.Date_out = reader["date_out"].ToString();
                    dossier.Referentie_Maatschappij = reader["referentie_maatschappij"].ToString();
                    dossier.Polis = reader["polis"].ToString();
                    dossier.Contract = reader["contract"].ToString();
                    dossier.Pvds_datum = reader["pvds_datum"].ToString();
                    dossier.Pvds_naam = reader["pvds_naam"].ToString();
                    dossier.Pvds_straat = reader["pvds_straat"].ToString();
                    dossier.Pvds_nr = reader["pvds_nr"].ToString();
                    dossier.Pvds_postcode = reader["pvds_postcode"].ToString();
                    dossier.Pvds_gemeente = reader["pvds_gemeente"].ToString();
                    dossier.Pvds_omvang = reader["pvds_omvang"].ToString();
                    dossier.Plaatsbezoek = reader["plaatsbezoek"].ToString();
                    dossier.Opdracht = reader["opdracht"].ToString();
                    dossier.Opmerking = reader["opmerking"].ToString();
                    dossiers.Add(dossier);
                }
                catch (Exception e)
                { }

            }

            closeConnection();

            return dossiers;
        }

        public int getMaatschappijIdFromDossier(string reference)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            int maatschappijId = -1;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select maatschappij_id from dossier where referentie= \'" + reference +"\'";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {

                    maatschappijId = int.Parse(reader["maatschappij_id"].ToString());
                }
                catch (Exception e)
                {
                    closeConnection();
                    return - 1;
                }
            }

            closeConnection();

            return maatschappijId;

        }

        public int getBeheerderIdFromDossier(string reference)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            int beheerderId = -1;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select beheerder_id from dossier where referentie= \'" + reference + "\'";
            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {

                    beheerderId = int.Parse(reader["beheerder_id"].ToString());
                }
                catch (Exception e)
                {
                    closeConnection();
                    return -1;
                }
            }

            closeConnection();

            return beheerderId;

        }

        public Dossier getDossier(Dossier dossierToCheck, int maatschappijId, int beheerderId)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            Dossier dossier = null;
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "Select * from dossier where id =\'" + dossierToCheck.Id + "\' AND referentie=\'" + dossierToCheck.Referentie.Replace("'", "\\'") + "\' AND date_in=\'" + dossierToCheck.Date_in.Replace("'", "\\'")
                                    + "\'AND date_out=\'" + dossierToCheck.Date_out.Replace("'", "\\'") + "\' ";
            if (maatschappijId == -1) { command.CommandText += " AND (maatschappij_id IS NULL OR maatschappij_id = \'-1\')"; } else { command.CommandText += " AND maatschappij_id =\'" + maatschappijId + "\' "; }
            if (beheerderId == -1) { command.CommandText += " AND (beheerder_id IS NULL OR beheerder_id = \'-1\')"; } else { command.CommandText += " AND beheerder_id=\'" + beheerderId + "\' "; }
            if (dossierToCheck.Referentie_Maatschappij.Equals("")) { command.CommandText += " AND (referentie_maatschappij IS NULL OR referentie_maatschappij=\'" + dossierToCheck.Referentie_Maatschappij.Replace("'", "\\'") + "\')"; } else { command.CommandText += " AND referentie_maatschappij=\'" + dossierToCheck.Referentie_Maatschappij.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Polis.Equals("")) { command.CommandText += " AND (polis IS NULL OR polis=\'" + dossierToCheck.Polis + "\')"; } else { command.CommandText += "AND polis=\'" + dossierToCheck.Polis.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Contract.Equals("")) { command.CommandText += " AND (contract IS NULL OR contract=\'" + dossierToCheck.Contract + "\')"; } else { command.CommandText += " AND contract=\'" + dossierToCheck.Contract.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Pvds_datum.Equals("")) { command.CommandText += " AND (pvds_datum IS NULL OR pvds_datum=\'" + dossierToCheck.Pvds_datum + "\')"; } else { command.CommandText += " AND pvds_datum=\'" + dossierToCheck.Pvds_datum.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Pvds_naam.Equals("")) { command.CommandText += " AND (pvds_naam IS NULL OR pvds_naam=\'" + dossierToCheck.Pvds_naam + "\')"; } else { command.CommandText += " AND pvds_naam=\'" + dossierToCheck.Pvds_naam.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Pvds_straat.Equals("")) { command.CommandText += " AND (pvds_straat IS NULL OR pvds_straat=\'" + dossierToCheck.Pvds_straat + "\')"; } else { command.CommandText += " AND pvds_straat=\'" + dossierToCheck.Pvds_straat.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Pvds_nr.Equals("")) { command.CommandText += " AND (pvds_nr IS NULL OR pvds_nr=\'" + dossierToCheck.Pvds_nr + "\')"; } else { command.CommandText += " AND pvds_nr=\'" + dossierToCheck.Pvds_nr.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Pvds_postcode.Equals("")) { command.CommandText += " AND (pvds_postcode IS NULL OR pvds_postcode=\'" + dossierToCheck.Pvds_postcode + "\')"; } else { command.CommandText += " AND pvds_postcode=\'" + dossierToCheck.Pvds_postcode.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Pvds_gemeente.Equals("")) { command.CommandText += " AND (pvds_gemeente IS NULL OR pvds_gemeente=\'" + dossierToCheck.Pvds_gemeente + "\')"; } else { command.CommandText += " AND pvds_gemeente=\'" + dossierToCheck.Pvds_gemeente.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Pvds_omvang.Equals("")) { command.CommandText += " AND (pvds_omvang IS NULL OR pvds_omvang=\'"+ dossierToCheck.Pvds_omvang +"\')"; } else { command.CommandText += " AND pvds_omvang=\'" + dossierToCheck.Pvds_omvang.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Plaatsbezoek.Equals("")) { command.CommandText += " AND (plaatsbezoek IS NULL OR plaatsbezoek=\'" + dossierToCheck.Plaatsbezoek + "\')"; } else { command.CommandText += "AND plaatsbezoek=\'" + dossierToCheck.Plaatsbezoek.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Opdracht.Equals("")) { command.CommandText += " AND (opdracht IS NULL OR opdracht=\'" + dossierToCheck.Opdracht + "\')"; } else { command.CommandText += " AND opdracht=\'" + dossierToCheck.Opdracht.Replace("'", "\\'") + "\'"; }
            if (dossierToCheck.Opmerking.Equals("")) { command.CommandText += " AND (opmerking IS NULL OR opmerking=\'" + dossierToCheck.Opmerking + "\');"; } else { command.CommandText += " AND opmerking=\'" + dossierToCheck.Opmerking.Replace("'", "\\'") + "\';"; }

            MySqlDataReader reader;

            openConnection();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    dossier = new Dossier();
                    dossier.Id = int.Parse(reader["id"].ToString());
                    dossier.Referentie = reader["referentie"].ToString();
                    dossier.Date_in = reader["date_in"].ToString();
                    dossier.Date_out = reader["date_out"].ToString();
                    dossier.Referentie_Maatschappij = reader["referentie_maatschappij"].ToString();
                    dossier.Polis = reader["polis"].ToString();
                    dossier.Contract = reader["contract"].ToString();
                    dossier.Pvds_datum = reader["pvds_datum"].ToString();
                    dossier.Pvds_naam = reader["pvds_naam"].ToString();
                    dossier.Pvds_straat = reader["pvds_straat"].ToString();
                    dossier.Pvds_nr = reader["pvds_nr"].ToString();
                    dossier.Pvds_postcode = reader["pvds_postcode"].ToString();
                    dossier.Pvds_gemeente = reader["pvds_gemeente"].ToString();
                    dossier.Pvds_omvang = reader["pvds_omvang"].ToString();
                    dossier.Plaatsbezoek = reader["plaatsbezoek"].ToString();
                    dossier.Opdracht = reader["opdracht"].ToString();
                    dossier.Opmerking = reader["opmerking"].ToString();
                }
                catch (Exception e)
                { }

            }

            closeConnection();

            return dossier;
        }

        public ArrayList getDossiersBySchadeAdres(string straat, string nr, string postcode, string gemeente)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            if (!straat.Trim().Equals("") && !nr.Trim().Equals("") || !postcode.Trim().Equals("") && !gemeente.Trim().Equals(""))
            {
                ArrayList dossiers = null;
                MySqlCommand command = this.connection.CreateCommand();
                command.CommandText = "SELECT * FROM dossier WHERE pvds_straat LIKE \'%" + straat.Replace("'", "\\'") + "%\'";
                command.CommandText += " AND pvds_nr LIKE \'%" + nr.Replace("'", "\\'") + "%\'";
                command.CommandText += " AND pvds_postcode LIKE \'%" + postcode.Replace("'", "\\'") + "%\'";
                command.CommandText += " AND pvds_gemeente LIKE \'%" + gemeente.Replace("'", "\\'") + "%\';";

                MySqlDataReader reader;

                openConnection();

                reader = command.ExecuteReader();
                dossiers = new ArrayList();

                while (reader.Read())
                {
                    try
                    {
                        Dossier dossier = new Dossier();
                        dossier.Id = int.Parse(reader["id"].ToString());
                        dossier.Referentie = reader["referentie"].ToString();
                        dossier.Date_in = reader["date_in"].ToString();
                        dossier.Date_out = reader["date_out"].ToString();
                        dossier.Referentie_Maatschappij = reader["referentie_maatschappij"].ToString();
                        dossier.Polis = reader["polis"].ToString();
                        dossier.Contract = reader["contract"].ToString();
                        dossier.Pvds_datum = reader["pvds_datum"].ToString();
                        dossier.Pvds_naam = reader["pvds_naam"].ToString();
                        dossier.Pvds_straat = reader["pvds_straat"].ToString();
                        dossier.Pvds_nr = reader["pvds_nr"].ToString();
                        dossier.Pvds_postcode = reader["pvds_postcode"].ToString();
                        dossier.Pvds_gemeente = reader["pvds_gemeente"].ToString();
                        dossier.Pvds_omvang = reader["pvds_omvang"].ToString();
                        dossier.Plaatsbezoek = reader["plaatsbezoek"].ToString();
                        dossier.Opdracht = reader["opdracht"].ToString();
                        dossier.Opmerking = reader["opmerking"].ToString();
                        dossiers.Add(dossier);
                    }
                    catch (Exception e)
                    { }

                }

                closeConnection();

                return dossiers;
            }
            return new ArrayList();
        }

        public void updateDossier(int maatschappijId, int beheerderId, Dossier newDossier)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE dossier";
            command.CommandText += " SET date_in = \'" + newDossier.Date_in + "\', date_out = \'" + newDossier.Date_out + "\', ";
            command.CommandText +=  " maatschappij_id = \'" + maatschappijId.ToString() + "\', ";
            command.CommandText += " beheerder_id = \'" + beheerderId.ToString() + "\', ";
            command.CommandText += "referentie_maatschappij = \'" + newDossier.Referentie_Maatschappij.Replace("'", "\\'") + "\', polis = \'" + newDossier.Polis.Replace("'", "\\'") + "\', contract = \'" + newDossier.Contract.Replace("'", "\\'") + "\', ";
            command.CommandText += "pvds_datum = \'" + newDossier.Pvds_datum.Replace("'", "\\'") + "\', ";
            command.CommandText += "pvds_naam = \'" + newDossier.Pvds_naam.Replace("'", "\\'") + "\', pvds_straat = \'" + newDossier.Pvds_straat.Replace("'", "\\'") + "\', pvds_nr = \'" + newDossier.Pvds_nr.Replace("'", "\\'") + "\', pvds_postcode = \'" + newDossier.Pvds_postcode.Replace("'", "\\'") + "\', ";
            command.CommandText += "pvds_gemeente = \'" + newDossier.Pvds_gemeente.Replace("'", "\\'") + "\'" + ", pvds_omvang = \'" + newDossier.Pvds_omvang.Replace("'", "\\'") + "\'" + ", plaatsbezoek = \'" + newDossier.Plaatsbezoek.ToString().Replace("'", "\\'") + "\', opdracht = \'" + newDossier.Opdracht.Replace("'", "\\'") + "\', opmerking = \'" + newDossier.Opmerking.Replace("'", "\\'") + "\'";
            command.CommandText += " WHERE id=" + newDossier.Id.ToString() + "; COMMIT;";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void updateReferentie(string oldReferentie, string newReferentie)
        {
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE dossier SET referentie=\'" +newReferentie+ "\' WHERE referentie= \'"+oldReferentie+"\'";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();

        }

        public void createDossier(string referentie)
        {
            
            if (connectionString == null || connectionString.Length == 0)
            {
                setupConnection();
            }

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = "INSERT INTO dossier (`referentie`,`date_in`, `date_out`) VALUES (\'" + referentie + "\', \'  /  /\', \'  /  /\');";
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
