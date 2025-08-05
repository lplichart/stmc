using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mertens.BusinessLogic
{
    class KostDetail
    {
        private int id;
        private char type;
        private String omschrijving;
        private float prijslaag;
        private float prijsmedium;
        private float prijshoog;

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public char Type
        {
            get { return type; }
            set { type = value; }
        }
        public String Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
        public float Prijslaag
        {
            get { return prijslaag; }
            set { prijslaag = value; }
        }
        public float Prijsmedium
        {
            get { return prijsmedium; }
            set { prijsmedium = value; }
        }
        public float Prijshoog
        {
            get { return prijshoog; }
            set { prijshoog = value; }
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
            KostDetail k = obj as KostDetail;
            if ((System.Object)k == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (!this.Id.Equals(k.Id)) return false;
            if (!this.Type.Equals(k.Type)) return false;
            if (!this.Omschrijving.Equals(k.Omschrijving)) return false;
            if (!this.Prijslaag.Equals(k.Prijslaag)) return false;
            if (!this.Prijsmedium.Equals(k.Prijsmedium)) return false;
            if (!this.Prijshoog.Equals(k.Prijshoog)) return false;

            return true;
        }
    }
}
