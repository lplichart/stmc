using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Mertens.BusinessLogic
{
    class Dossier
    {
        private int id;
        private string referentie;
        private string date_in;
        private string date_out;
        private string jaarGeopend;
        private string maandGeopend;
        private string maatschappij;
        private string referentie_Maatschappij;
        private string polis;
        private string beheerder;
        private string contract;
        private string pvds_datum;
        private string pvds_naam;
        private string pvds_straat;
        private string pvds_nr;
        private string pvds_postcode;
        private string pvds_gemeente;
        private string pvds_omvang;
        private string plaatsbezoek;
        private string opdracht;
        private string opmerking;
        private String[] monthName = { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


        public Dossier(string referentie, string date_in)
        {
            Referentie = referentie;
            Date_in = date_in;
        }

        public Dossier()
        {
        }


        public Dossier(string referentie, string date_in, string date_out, string maatschappij, string beheerder, string contract)
        {
            Referentie = referentie;
            Date_in = date_in;
            Date_out = date_out;
            Maatschappij = maatschappij;
            Beheerder = beheerder;
            Contract = contract;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Dossier d = obj as Dossier;
            if ((System.Object)d == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (!this.referentie.Equals(d.Referentie)) return false;
            if (!this.Date_in.Equals(d.Date_in)) return false;
            if (!this.date_out.Equals(d.Date_out)) return false;
            if (!this.maatschappij.Equals(d.Maatschappij)) return false;
            if (!this.beheerder.Equals(d.Beheerder)) return false;
            if (!this.contract.Equals(d.Contract)) return false;
            if (!this.Referentie_Maatschappij.Equals(d.Referentie_Maatschappij)) return false;
            if (!this.Polis.Equals(d.Polis)) return false;
            if (!this.Pvds_datum.Equals(d.Pvds_datum)) return false;
            if (!this.Pvds_naam.Equals(d.Pvds_naam)) return false;
            if (!this.Pvds_straat.Equals(d.Pvds_straat)) return false;
            if (!this.Pvds_nr.Equals(d.Pvds_nr)) return false;
            if (!this.Pvds_postcode.Equals(d.Pvds_postcode)) return false;
            if (!this.Pvds_gemeente.Equals(d.Pvds_gemeente)) return false;
            if (!this.Pvds_omvang.Equals(d.Pvds_omvang)) return false;
            if (!this.Plaatsbezoek.Equals(d.Plaatsbezoek)) return false;
            if (!this.Opdracht.Equals(d.Opdracht)) return false;
            if (!this.Opmerking.Equals(d.Opmerking)) return false;

            return true;
        }

        #region properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Referentie
        {
            get { return referentie; }
            set { referentie = value; }
        }
        public string Maatschappij
        {
            get { return maatschappij; }
            set { maatschappij = value; }
        }

        public string Referentie_Maatschappij
        {
            get { return referentie_Maatschappij; }
            set { referentie_Maatschappij = value; }
        }
        public string Polis
        {
            get { return polis; }
            set { polis = value; }
        }
        public string Date_in
        {
            get { return date_in; }
            set
            {
                date_in = value;
                try
                {
                    if (!date_in.Trim().Equals(""))
                    {
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "dd/MM/yyyy";
                        dtfi.DateSeparator = "/";
                        DateTime objDate = Convert.ToDateTime(date_in, dtfi);
                        JaarGeopend = objDate.Year.ToString();
                        MaandGeopend = monthName[int.Parse(objDate.Month.ToString())];
                    }
                }
                catch (Exception e) { JaarGeopend = ""; MaandGeopend = ""; }

            }
        }
        public string Date_out
        {
            get { return date_out; }
            set { date_out = value; }
        }
        public string JaarGeopend
        {
            get { return jaarGeopend; }
            set { jaarGeopend = value; }
        }
        public string MaandGeopend
        {
            get { return maandGeopend; }
            set { maandGeopend = value; }
        }
        public string Beheerder
        {
            get { return beheerder; }
            set { beheerder = value; }
        }

        public string Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        public string Pvds_datum
        {
            get { return pvds_datum; }
            set { pvds_datum = value; }
        }
        public string Pvds_naam
        {
            get { return pvds_naam; }
            set { pvds_naam = value; }
        }


        public string Pvds_straat
        {
            get { return pvds_straat; }
            set { pvds_straat = value; }
        }

        public string Pvds_nr
        {
            get { return pvds_nr; }
            set { pvds_nr = value; }
        }

        public string Pvds_postcode
        {
            get { return pvds_postcode; }
            set { pvds_postcode = value; }
        }


        public string Pvds_gemeente
        {
            get { return pvds_gemeente; }
            set { pvds_gemeente = value; }
        }

        public string Pvds_omvang
        {
            get { return pvds_omvang; }
            set { pvds_omvang = value; }
        }

        public string Plaatsbezoek
        {
            get { return plaatsbezoek; }
            set { plaatsbezoek = value; }
        }

        public string Opdracht
        {
            get { return opdracht; }
            set { opdracht = value; }
        }


        public string Opmerking
        {
            get { return opmerking; }
            set { opmerking = value; }
        }
        #endregion

    }
}
