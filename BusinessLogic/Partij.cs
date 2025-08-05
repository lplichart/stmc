using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mertens.BusinessLogic
{
    class Partij
    {
        private int id;
        private string naam;
        private string referentie;
        private string adres;
        private string postcode;
        private string gemeente;
        private string tel;
        private string fax;
        private string gsm;
        private string email;
        private int type;
        private string hoedanigheid;
        private string contactPersoon;
        private int hoofdpartij_id;

        #region properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string Referentie
        {
            get { return referentie; }
            set { referentie = value; }
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Gsm
        {
            get { return gsm; }
            set { gsm = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Hoedanigheid
        {
            get { return hoedanigheid; }
            set { hoedanigheid = value; }
        }

        public string ContactPersoon
        {
            get { return contactPersoon; }
            set { contactPersoon = value; }
        }

        public int Hoofdpartij_id
        {
            get { return hoofdpartij_id; }
            set { hoofdpartij_id = value; }
        }

#endregion
        #region constructor
        public Partij()
        {

        }

        public Partij(string naam, string adres, string postcode, string gemeente, string tel, string fax, string email)
        {
            Naam = naam;
            Referentie = referentie;
            Adres = adres;
            Postcode = postcode;
            Gemeente = gemeente;
            Tel = tel;
            Fax = fax;
            Email = email;
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
            Partij p = obj as Partij;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            if (!this.id.Equals(p.id)) return false;
            if (!this.naam.Equals(p.naam)) return false;
            if (!this.referentie.Equals(p.referentie)) return false;
            if (!this.adres.Equals(p.adres)) return false;
            if (!this.postcode.Equals(p.postcode)) return false;
            if (!this.gemeente.Equals(p.gemeente)) return false;
            if (!this.tel.Equals(p.tel)) return false;
            if (!this.fax.Equals(p.fax)) return false;
            if (!this.gsm.Equals(p.gsm)) return false;
            if (!this.email.Equals(p.email)) return false;
            if (!this.type.Equals(p.type)) return false;
            if (!this.hoedanigheid.Equals(p.hoedanigheid)) return false;
            if (!this.contactPersoon.Equals(p.contactPersoon)) return false;
            if (!this.hoofdpartij_id.Equals(p.hoofdpartij_id)) return false;

            return true;
        }



    }
}
