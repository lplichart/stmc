using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mertens.BusinessLogic
{
    class Kost
    {
        private int id;
        private int prestatieId;
        private char type;
        private string datum;
        private string omschrijving;
        private string commentaar;
        private float hoeveelheid;
        private float eenheidsprijs;
        private float totaal;
        private int hoofdKostId;
        private string kostenPost;

        public Kost()
        {

        }
        public Kost(int prestatieId, char type, string datum, string omschrijving, string commentaar, float hoeveelheid, float eenheidsprijs, int hoofdkostId, string kostenPost) 
        {
            PrestatieId = prestatieId;
            Type = type;
            Datum = datum;
            Omschrijving = omschrijving;
            Commentaar = commentaar;
            Hoeveelheid = hoeveelheid;
            Eenheidsprijs = eenheidsprijs;
            setTotaal();
            HoofdKostId = hoofdkostId;
            KostenPost = kostenPost;
        }

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int PrestatieId
        {
            get { return prestatieId; }
            set { prestatieId = value; }
        }
        public char Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
        public string Commentaar
        {
            get { return commentaar; }
            set { commentaar = value; }
        }
        public float Hoeveelheid
        {
            get { return hoeveelheid; }
            set { hoeveelheid = value; }
        }
        public float Eenheidsprijs
        {
            get { return eenheidsprijs; }
            set { eenheidsprijs = value; }
        }
        public float Totaal
        {
            get { return totaal; }
            set { totaal = value; }
        }

        public int HoofdKostId
        {
            get { return hoofdKostId; }
            set { hoofdKostId = value; }
        }
        public string KostenPost
        {
            get { return kostenPost; }
            set { kostenPost = value; }
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
            Kost k = obj as Kost;
            if ((System.Object)k == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (!this.Id.Equals(k.Id)) return false;
            if (!this.prestatieId.Equals(k.prestatieId)) return false;
            if (!this.Type.Equals(k.Type)) return false;
            if (!this.Datum.Equals(k.Datum)) return false;
            if (!this.Omschrijving.Equals(k.Omschrijving)) return false;
            if (!this.Commentaar.Equals(k.Commentaar)) return false;
            if (!this.Hoeveelheid.Equals(k.Hoeveelheid)) return false;
            if (!this.Eenheidsprijs.Equals(k.Eenheidsprijs)) return false;
            if (!this.Totaal.Equals(k.Totaal)) return false;
            if (!this.HoofdKostId.Equals(k.HoofdKostId)) return false;
            if (!this.KostenPost.Equals(k.KostenPost)) return false;

            return true;
        }

        public void setTotaal()
        {
            if (Eenheidsprijs != null && Eenheidsprijs > 0 && Hoeveelheid != null && Hoeveelheid > 0)
            {
                Totaal = Eenheidsprijs * Hoeveelheid;
                Totaal = (float)Math.Round(Totaal, 2);
            }
            else
            {
                Totaal = 0;
            }
        }

    }
}
