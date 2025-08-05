using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mertens.BusinessLogic
{
    class Maatschappij
    {
        private int id;
        private string naam;
        private string straat;
        private string postcode;
        private string telefoon;
        private string fax;
        private string email;
        private string btw;

        public Maatschappij(string naam, string straat, string gemeente, string postcode)
        {
            Naam = naam;
            Straat = straat;
            Gemeente = gemeente;
            Postcode = postcode;
        }

        #region getters & setters
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


        public string Straat
        {
            get { return straat; }
            set { straat = value; }
        }
        private string gemeente;

        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }


        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Telefoon
        {
            get { return telefoon; }
            set { telefoon = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Btw
        {
            get { return btw; }
            set { btw = value; }
        } 
        #endregion

        


    }
}
