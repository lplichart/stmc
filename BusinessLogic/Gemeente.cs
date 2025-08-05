using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mertens.BusinessLogic
{
    class Gemeente
    {
        private string postcode;
        private string naam;

        //Properties

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        // end Properties

        public Gemeente(string postcode, string naam)
        {
            this.postcode = postcode;
            this.naam = naam;
        }

        public Gemeente()
        {
           
        }

        
        
        
    }
}
