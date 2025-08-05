using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mertens.Dao
{
    class ConnectionStringManager
    {
        private static string connectionString ="";

        public static string getConnectionString()
        {
            try
            {
                StreamReader re = File.OpenText("../../data/connectionString.txt");
                connectionString = re.ReadLine();
                re.Close();

            }
            catch (FileNotFoundException fnfe)
            {
                throw new Exception("Het bestand met de connectionstring werd niet gevonden" + fnfe.Message );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return connectionString;
        }
    }
}
