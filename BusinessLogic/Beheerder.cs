using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mertens.BusinessLogic
{
    class Beheerder
    {
        private int id = 0;
        private string maatschappij = null;
        private string voornaam = null;
        private string naam = null;
        private string aanspreektitel = null;
        private string telefoon=null;
        private string fax=null;
        private string email=null;

        public Beheerder(string maatschappij, string naam)
        {
            Maatschappij = maatschappij;
            Naam = naam;
        }

        public string Maatschappij
        {
            get { return maatschappij; }
            set { maatschappij = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Voornaam
        {
            get { return voornaam; }
            set { voornaam = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
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

        public string Aanspreektitel
        {
            get { return aanspreektitel; }
            set { aanspreektitel = value; }
        }

    }
}
