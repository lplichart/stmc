using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Mertens.BusinessLogic
{
    class Factuur
    {
        private int id;
        private string datum;
        private string factuurnummer;
        private string referentie;
        private string datumDossier;
        private string jaarDossier;
        private string jaarFacturatie;
        private string maandFacturatie;
        private string maatschappij;
        private float erelonen;
        private float onkosten;
        private float btw;
        private float totaal;
        private int prestatie_id;
        private char expert;
        private String[] monthName = { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October","November", "December" };

        public Factuur()
        {
        }

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Datum
        {
            get { return datum; }
            set
            {
                datum = value;
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                dtfi.DateSeparator = "/";
                DateTime objDate = Convert.ToDateTime(datum, dtfi);
                JaarFacturatie = objDate.Year.ToString();
                maandFacturatie = monthName[int.Parse(objDate.Month.ToString())];  
            }
        }
        public string Factuurnummer
        {
            get { return factuurnummer; }
            set { factuurnummer = value; }
        }
        public string Referentie
        {
            get { return referentie; }
            set { referentie = value; }
        }
        public string DatumDossier
        {
            get { return datumDossier; }
            set {
                datumDossier = value;
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                dtfi.DateSeparator = "/";
                DateTime objDate = Convert.ToDateTime(datumDossier, dtfi);
                JaarDossier = objDate.Year.ToString();
            }
        }
        public string JaarDossier
        {
            get { return jaarDossier; }
            set { jaarDossier = value; }
        }
        public string JaarFacturatie
        {
            get { return jaarFacturatie; }
            set { jaarFacturatie = value; }
        }
        public string MaandFacturatie
        {
            get { return maandFacturatie; }
            set { maandFacturatie = value; }
        }
        public string Maatschappij
        {
            get { return maatschappij; }
            set { maatschappij = value; }
        }
        public float Erelonen
        {
            get { return erelonen; }
            set { erelonen = value; }
        }
        public float Onkosten
        {
            get { return onkosten; }
            set { onkosten = value; }
        }
        public float Btw
        {
            get { return btw; }
            set { btw = value; }
        }
        public float Totaal
        {
            get { return totaal; }
            set { totaal = value; }
        }
        public int Prestatie_id
        {
            get { return prestatie_id; }
            set { prestatie_id = value; }
        }
        public char Expert
        {
            get { return expert; }
            set { expert = value; }
        }
        #endregion

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Factuur f = obj as Factuur;
            if ((System.Object)f == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (!this.Id.Equals(f.Id)) return false;
            if (!this.Datum.Equals(f.Datum)) return false;
            if (!this.Factuurnummer.Equals(f.factuurnummer)) return false;
            if (!this.Referentie.Equals(f.Referentie)) return false;
            if (!this.Erelonen.Equals(f.Erelonen)) return false;
            if (!this.Onkosten.Equals(f.Onkosten)) return false;
            if (!this.Btw.Equals(f.Btw)) return false;
            if (!this.Totaal.Equals(f.Totaal)) return false;
            if (!this.Prestatie_id.Equals(f.Prestatie_id)) return false;
            if (!this.Expert.Equals(f.Expert)) return false;

            return true;
        }
    }
}
