using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mertens.BusinessLogic
{
    class Prestatie
    {
        private int id;
        private int dossierId;
        private string werkdatum;
        private string herinnerdatum;
        private string herinnerCommentaar;
        private float btw;
        private float totaalErelonen;
        private float totaalOnkosten;
        private float totaalBtw;
        private string historiek;
        private string tariefniveau;
        private Boolean openstaand;

        public Prestatie()
        {
        }

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int DossierId
        {
            get { return dossierId; }
            set { dossierId = value; }
        }
        public string Werkdatum
        {
            get { return werkdatum; }
            set { werkdatum = value; }
        }
        public string Herinnerdatum
        {
            get { return herinnerdatum; }
            set { herinnerdatum = value; }
        }

        public string HerinnerCommentaar
        {
            get { return herinnerCommentaar; }
            set { herinnerCommentaar = value; }
        }
        public float Btw
        {
            get { return btw; }
            set { btw = value; }
        }
        public float TotaalErelonen
        {
            get { return totaalErelonen; }
            set { totaalErelonen = value; }
        }
        public float TotaalOnkosten
        {
            get { return totaalOnkosten; }
            set { totaalOnkosten = value; }
        }
        public float TotaalBtw
        {
            get { return totaalBtw; }
            set { totaalBtw = value; }
        }
        public string Historiek
        {
            get { return historiek; }
            set { historiek = value; }
        }
        public string Tariefniveau
        {
            get { return tariefniveau; }
            set { tariefniveau = value; }
        }
        public Boolean Openstaand
        {
            get { return openstaand; }
            set { openstaand = value; }
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
            Prestatie p = obj as Prestatie;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (!this.Id.Equals(p.Id)) return false;
            if (!this.DossierId.Equals(p.DossierId)) return false;
            if (!this.Werkdatum.Equals(p.Werkdatum)) return false;
            if (!this.Herinnerdatum.Equals(p.Herinnerdatum)) return false;
            if (!this.HerinnerCommentaar.Equals(p.HerinnerCommentaar)) return false;
            if (!this.Btw.Equals(p.Btw)) return false;
            if (!this.TotaalErelonen.Equals(p.TotaalErelonen)) return false;
            if (!this.TotaalOnkosten.Equals(p.TotaalOnkosten)) return false;
            if (!this.TotaalBtw.Equals(p.TotaalBtw)) return false;
            if (!this.Historiek.Equals(p.Historiek)) return false;
            if (!this.Tariefniveau.Equals(p.Tariefniveau)) return false;
            if (!this.Openstaand.Equals(p.Openstaand)) return false;


            return true;
        }
    }
}
