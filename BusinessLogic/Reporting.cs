using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Mertens.Dao;
using Mertens.Forms;
using System.Collections;
using System.IO;

namespace Mertens.BusinessLogic
{
    class Reporting
    {
        Dictionary<int,String> maatschappijen = new Dictionary<int, string>();
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;

        public void initializeData()
        {
            Dictionary<String, int> reversedmaatschappijen  = new Dictionary<string, int>();
            reversedmaatschappijen = MaatschappijDao.Instance.getMaatschappijen();
            foreach(String key in reversedmaatschappijen.Keys)
            {
                int newkey = reversedmaatschappijen[key];
                maatschappijen.Add(newkey, key);
            }
        }

        public void generateReport()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range range;
            int row = 3;
            xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Kon Excel niet starten, kijk uw softwareinstelling na !");
                return;
            }

            //string workbookPath = Path.Combine(Environment.CurrentDirectory, @"..\..\Data\Reporting.xlsx");
            string workbookPath = Path.Combine(Environment.CurrentDirectory, @"..\..\Data\Kopie_Reporting.xlsx");
            xlWorkBook = xlApp.Workbooks.Open(workbookPath,
                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);
            
            
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            ArrayList dossiers = DossierDao.Instance.getDossiers("SELECT * FROM dossier ORDER BY referentie;");
            foreach (Object o in dossiers)
            {
                Dossier d = (Dossier)o;
                range = xlWorkSheet.get_Range("A" + row);
                range.Value = d.Referentie;
                range = xlWorkSheet.get_Range("B" + row);
                range.Value = d.JaarGeopend;
                range = xlWorkSheet.get_Range("C" + row);
                range.Value = d.MaandGeopend;
                range = xlWorkSheet.get_Range("D" + row);
                range.Value = d.Referentie.Substring(10, 1);
                range = xlWorkSheet.get_Range("E" + row);
                range.Value = d.Maatschappij;
                row++;
            }

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
            ArrayList facturen = FactuurDao.Instance.getAllFacturen();
            row = 3;
            foreach (Object o in facturen)
            {
                Factuur f = (Factuur)o;
                range = xlWorkSheet.get_Range("A" + row);
                range.Value = f.Factuurnummer;
                range = xlWorkSheet.get_Range("B" + row);
                range.Value = f.Referentie;
                range = xlWorkSheet.get_Range("C" + row);
                range.Value = f.JaarFacturatie;
                range = xlWorkSheet.get_Range("D" + row);
                range.Value = f.JaarDossier;
                range = xlWorkSheet.get_Range("E" + row);
                range.Value = f.MaandFacturatie;
                range = xlWorkSheet.get_Range("F" + row);
                range.Value = f.Expert;
                range = xlWorkSheet.get_Range("G" + row);
                range.Value = f.Maatschappij;
                range = xlWorkSheet.get_Range("H" + row);
                range.Value = f.Erelonen;
                range = xlWorkSheet.get_Range("I" + row);
                range.Value = f.Onkosten;
                range = xlWorkSheet.get_Range("J" + row);
                range.Value = f.Btw;
                range = xlWorkSheet.get_Range("K" + row);
                range.Value = f.Totaal;
                range = xlWorkSheet.get_Range("L" + row);
                range.Value = f.Expert.ToString();
                row++;
            }
            try
            {
                xlApp.Visible = true;
            }
            catch
            {
                //MessageBox.Show("Er is een fout opgetreden, neem contact op met uw programmabeheerder", "FOUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlApp.Visible = true;
            }
            
            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkSheet);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
