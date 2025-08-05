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
    class ExcelBuilder
    {
        public void buildFactuur(Dossier dossier, Maatschappij maatschappij, Prestatie prestatie, Factuur factuur)
        {

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range range;
            string verzekerde = "";
            string tegenpartij = "";
            string beheerder = "";

            foreach (Object po in PartijDao.Instance.getPartijenVoorDossier(dossier.Id))
            {
                Partij partij = (Partij)po;

                if (partij.Type == 2 && verzekerde.Equals(""))
                {
                    verzekerde = partij.Naam.ToUpper(); ;
                }

                if (partij.Type == 3 && tegenpartij.Equals(""))
                {
                    tegenpartij = partij.Naam.ToUpper();
                }
            }

            beheerder = frmDetails.Instance.cmbBeheerder.Text;

            xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Kon Excel niet starten, kijk uw softwareinstelling na !");
                return;
            }

            //xlWorkBook = xlApp.Workbooks.Add(misValue);

            string workbookPath = Path.Combine(Environment.CurrentDirectory, @"..\..\Data\factuurmertens.xls");
            xlWorkBook = xlApp.Workbooks.Open(workbookPath,
                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Name = "Factuur";
            range = xlWorkSheet.get_Range("G1");
            range.Value = "Vilvoorde " + factuur.Datum;

            if(null != maatschappij)
            {
            range = xlWorkSheet.get_Range("E4");
            if(null != maatschappij.Naam && !maatschappij.Naam.Equals("")) range.Value = maatschappij.Naam.ToUpper();
            range = xlWorkSheet.get_Range("E6");
            if (null != maatschappij.Straat && !maatschappij.Straat.Equals("")) range.Value = maatschappij.Straat;
            range = xlWorkSheet.get_Range("E8");
            if ((null != maatschappij.Postcode && !maatschappij.Postcode.Equals("")) && (null != maatschappij.Gemeente && !maatschappij.Gemeente.Equals(""))) range.Value = maatschappij.Postcode + " " + maatschappij.Gemeente;
            range = xlWorkSheet.get_Range("E10");
            if (maatschappij.Btw == null && maatschappij.Btw.Trim() == "") range.Value = "BTW nr. niet onderworpen";
            else range.Value = "BTW nr. " + maatschappij.Btw;
            }

            range = xlWorkSheet.get_Range("B12");
            range.Value = dossier.Referentie_Maatschappij;
            range = xlWorkSheet.get_Range("B13");
            range.Value = beheerder;
            range = xlWorkSheet.get_Range("B15");
            range.Value = dossier.Referentie;

            range = xlWorkSheet.get_Range("E17");
            range.Value = factuur.Factuurnummer;

            range = xlWorkSheet.get_Range("E22");
            range.Value = verzekerde;
            range = xlWorkSheet.get_Range("E24");
            range.Value = tegenpartij;
            range = xlWorkSheet.get_Range("E26");
            range.Value = dossier.Pvds_gemeente + " / " + dossier.Pvds_straat;

            range = xlWorkSheet.get_Range("H29");
            range.Value = prestatie.TotaalErelonen;
            range = xlWorkSheet.get_Range("H33");
            range.Value = prestatie.TotaalOnkosten;
            range = xlWorkSheet.get_Range("H37");
            range.Value = prestatie.TotaalErelonen + prestatie.TotaalOnkosten;
            range = xlWorkSheet.get_Range("H39");
            range.Value = prestatie.TotaalBtw;
            range = xlWorkSheet.get_Range("H41");
            range.Value = prestatie.TotaalErelonen + prestatie.TotaalOnkosten + prestatie.TotaalBtw;

            string factuurnaam = dossier.Referentie.Replace('/', '-') + "- factuur "+ factuur.Factuurnummer.Replace('/','-') +" dd -" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            /*
            chartRange = xlWorkSheet.get_Range("b2", "e9");
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            **/

            buildDetail(prestatie, factuur.Factuurnummer, (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2));

            try
            {
                xlWorkBook.SaveAs("K:\\My Documents\\Facturen\\" + factuurnaam + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
        }

        public void buildDetail(Prestatie prestatie, String factuurnummer, Excel.Worksheet sheet2)
        {

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range range;
            string referentie = frmDetails.Instance.SelectedReference;

            xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Kon Excel niet starten, kijk uw softwareinstelling na !");
                return;
            }

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            // xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet = sheet2;
            xlWorkSheet.Name = "Detail";
            xlWorkSheet.PageSetup.LeftMargin = 0.5;
            xlWorkSheet.PageSetup.RightMargin = 0.5;

            string detailnaam = referentie.Replace('/', '-') + "- detail dd -" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();

            ArrayList kosten = KostDao.Instance.getKostenByPrestatie(prestatie.Id);
            int rij = 1;

            range = xlWorkSheet.get_Range("A1", "E1");
            range.MergeCells = true;
            range.Value = "Detail prestatieblad: "+ referentie + " - " + factuurnummer;
            range.Font.Bold = true;
            range.Font.Underline = true;
            range.Font.Size = 22;

            range = xlWorkSheet.get_Range("A3");
            range.Value = "Datum";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("B3");
            range.Value = "Omschrijving";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("C3");
            range.Value = "Hoeveelheid";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("D3");
            range.Value = "Eenheidsprijs";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("E3");
            range.Value = "Totaal";
            range.Font.Bold = true;
            range.Font.Underline = true;

            rij = 5;

            for (int i = 0; i < kosten.Count; i++)
            {
                Kost kost = (Kost)kosten[i];
                string cell = "A" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = kost.Datum;

                cell = "B" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = kost.Omschrijving;

                cell = "C" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = kost.Hoeveelheid;

                cell = "D" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = kost.Eenheidsprijs;

                cell = "E" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = kost.Totaal;
                rij++;
            }

            rij++;

            range = xlWorkSheet.get_Range("D" + rij.ToString());
            range.Value = "Totaal excl. BTW";

            range = xlWorkSheet.get_Range("E" + rij.ToString());
            range.Formula = "=SUM(E5:E"+ (rij-2).ToString() +")";
            rij++;

            range = xlWorkSheet.get_Range("D" + rij.ToString());
            range.Value = "BTW";

            range = xlWorkSheet.get_Range("E" + rij.ToString());
            range.Formula = "= E" + (rij - 1).ToString() + "*0.21";
            rij++;

            range = xlWorkSheet.get_Range("D" + rij.ToString());
            range.Value = "Totaal incl; BTW";
            range.Font.Bold = true;

            range = xlWorkSheet.get_Range("E" + rij.ToString());
            range.Formula = "= E" + (rij - 2).ToString() + "*1.21";
            range.Font.Bold = true;
            range = xlWorkSheet.get_Range("D" + rij.ToString(), "E" + rij.ToString());
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;

            xlWorkSheet.Columns.AutoFit();
            range = xlWorkSheet.get_Range("A3", "A" + rij.ToString());
            range.NumberFormat = "MM/DD/YYYY";
            //range = xlWorkSheet.get_Range("B3", "B" + rij.ToString());
            //range.ColumnWidth = 30.29;
            range = xlWorkSheet.get_Range("C3", "C" + rij.ToString());
            range.NumberFormat = "#,###0.000_);[Red](#,###0.000)";
            range = xlWorkSheet.get_Range("D3", "D" + rij.ToString());
            range.NumberFormat = "€ #,###0.000_);[Red](€ #,###0.000)";
            range = xlWorkSheet.get_Range("E3", "E" + rij.ToString());
            range.NumberFormat = "€ #,###0.000_);[Red](€ #,###0.000)";
          
            /*
            try
            {
                xlWorkBook.SaveAs("Z:\\My Documents\\Rob\\IT Project\\Facturen\\" + detailnaam + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
             * */
        }

        public void buildVoorblad(Dossier dossier, ArrayList partijen)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range range;
            Beheerder beheerder = null;

            foreach (Object o in BeheerderDao.Instance.getBeheerdersDetailByMaatschappij(dossier.Maatschappij))
            {
                beheerder = (Beheerder)o;
                string naam = beheerder.Naam.ToUpper() + " " + beheerder.Voornaam.ToUpper();
                if (naam.Equals(dossier.Beheerder.ToUpper()))
                {
                    break;
                }
            }

            xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Kon Excel niet starten, kijk uw softwareinstelling na !");
                return;
            }

            frmDetails.Instance.prgrsBar.Value = 25;

            string workbookPath = Path.Combine(Environment.CurrentDirectory, @"..\..\Data\Voorblad.xls");
            xlWorkBook = xlApp.Workbooks.Open(workbookPath,
                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Create a Style
            Excel.Style hoofdstijl = xlWorkBook.Styles.Add("hoofdstijl", Type.Missing);
            hoofdstijl.Font.Name = "Arial";
            hoofdstijl.Font.Size = 9;

            Excel.Style substijl = xlWorkBook.Styles.Add("substijl", Type.Missing);
            substijl.Font.Name = "Arial";
            substijl.Font.Italic = true;
            substijl.Font.Size = 8;

            range = xlWorkSheet.get_Range("A1");
            range.Value = dossier.Referentie;
            range = xlWorkSheet.get_Range("A2");
            range.Value = "  Dossier in : " + dossier.Date_in;
            range = xlWorkSheet.get_Range("G2");
            range.Value = "  Datum klacht : " + dossier.Pvds_datum;
            range = xlWorkSheet.get_Range("B4");
            range.Value = "  " + dossier.Maatschappij;
            range = xlWorkSheet.get_Range("B5");
            range.Value = "  " + dossier.Beheerder;
            range = xlWorkSheet.get_Range("B6");
            if (null != beheerder) range.Value = "  " + beheerder.Telefoon;
            range = xlWorkSheet.get_Range("B7");
            if (null != beheerder) range.Value = "  " + beheerder.Email;
            range = xlWorkSheet.get_Range("F4");
            range.Value = "  " + dossier.Referentie_Maatschappij;
            range = xlWorkSheet.get_Range("F5");
            range.Value = "  " + dossier.Polis;
            range = xlWorkSheet.get_Range("F6");
            range.Value = "  " + dossier.Contract;
            range = xlWorkSheet.get_Range("F7");
            range.Value = "  " + dossier.Opdracht;

            range = xlWorkSheet.get_Range("A11");
            range.Value = "  " + dossier.Pvds_naam;
            String[] temp = dossier.Plaatsbezoek.Split(';');
            range = xlWorkSheet.get_Range("E11");
            if(!temp[0].Equals("dd.  om "))range.Value = "  " + temp[0];
            range = xlWorkSheet.get_Range("E12");
            if (!temp[1].Equals("dd.  om ")) range.Value = "  " + temp[1];
            range = xlWorkSheet.get_Range("E13");
            if (!temp[2].Equals("dd.  om ")) range.Value = "  " + temp[2];
            range = xlWorkSheet.get_Range("G11");
            if (!temp[3].Equals("dd.  om ")) range.Value = "  " + temp[3];
            range = xlWorkSheet.get_Range("G12");
            if (!temp[4].Equals("dd.  om ")) range.Value = "  " + temp[4];
            range = xlWorkSheet.get_Range("G13");
            if (!temp[5].Equals("dd.  om ")) range.Value = "  " + temp[5];

            range = xlWorkSheet.get_Range("A12");
            range.Value = "  " + dossier.Pvds_straat + " " + dossier.Pvds_nr;
            range = xlWorkSheet.get_Range("A13");
            range.Value = "  " + dossier.Pvds_postcode + " " + dossier.Pvds_gemeente;
            range = xlWorkSheet.get_Range("G15");
            if (null != dossier.Pvds_omvang) range.Value = "  " + dossier.Pvds_omvang;
            range = xlWorkSheet.get_Range("A16");
            range.Value = "  " + dossier.Opmerking;

            frmDetails.Instance.prgrsBar.Value = 40;


            int index = 20;

            ArrayList verzekerden = new ArrayList();
            ArrayList tegenpartijen = new ArrayList();
            ArrayList anderen = new ArrayList();
            ArrayList xverzekerden = new ArrayList();
            ArrayList xtegenpartijen = new ArrayList();
            ArrayList xanderen = new ArrayList();

            foreach (Object o in partijen)
            {
                Partij partij = (Partij)o;

                switch (partij.Type)
                {
                    case 2: verzekerden.Add(partij); break;
                    case 3: tegenpartijen.Add(partij); break;
                    case 4: anderen.Add(partij); break;
                    case 5: xverzekerden.Add(partij); break;
                    case 6: xtegenpartijen.Add(partij); break;
                    case 7: xanderen.Add(partij); break;
                }
            }

            frmDetails.Instance.prgrsBar.Value = 55;

            #region Fill Verzekerden
            foreach (var item in verzekerden)
            {
                Partij p = (Partij)item;
                int rangeindex = index + 2;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + rangeindex.ToString());
                range.Style = hoofdstijl;

                range = xlWorkSheet.get_Range("A" + index.ToString());
                range.Value = "  Verzekerde";
                range.Font.Underline = true;
                range.Font.Bold = true;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Naam;
                range.Font.Bold = true;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Tel : " + p.Tel;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "Cntct : " + p.ContactPersoon;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;

                range = xlWorkSheet.get_Range("A" + index.ToString());
                range.Value = "  " + p.Hoedanigheid;
                range.Font.Italic = true;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Adres;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Fax : " + p.Fax;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "E-mail : " + p.Email;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Postcode + " " + p.Gemeente;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Gsm : " + p.Gsm;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "Ref : " + p.Referentie;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                index++;

                foreach (var var2 in xverzekerden)
                {
                    Partij subpartij = (Partij)var2;
                    if (subpartij.Hoofdpartij_id.Equals(p.Id))
                    {
                        rangeindex = index + 3;
                        range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + rangeindex.ToString());
                        range.Style = substijl;

                        range = xlWorkSheet.get_Range("B" + index.ToString());
                        range.Value = subpartij.Hoedanigheid;
                        range.Font.Underline = true;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Naam;
                        range.Font.Bold = true;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Tel : " + subpartij.Tel;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Cntct : " + subpartij.ContactPersoon;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 13;

                        range = xlWorkSheet.get_Range("B" + index.ToString(),"H" + index.ToString());
                        range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = 1;
                        range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;


                        index++;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Adres;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Fax : " + subpartij.Fax;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "E-mail : " + subpartij.Email;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 11;
                        index++;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Postcode + " " + subpartij.Gemeente;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Gsm : " + subpartij.Gsm;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Ref : " + subpartij.Referentie;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 11;
                        index++;
                    }
                }

                index++;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                range.Interior.Color = 14540253;
                index++;

                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                index++;
            }
            #endregion

            frmDetails.Instance.prgrsBar.Value = 65;

            #region Fill Tegenpartijen
            foreach (var item in tegenpartijen)
            {
                Partij p = (Partij)item;

                int rangeindex = index + 2;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + rangeindex.ToString());
                range.Style = hoofdstijl;

                range = xlWorkSheet.get_Range("A" + index.ToString());
                range.Value = "  Tegenpartij";
                range.Font.Underline = true;
                range.Font.Bold = true;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Naam;
                range.Font.Bold = true;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Tel : " + p.Tel;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "Cntct : " + p.ContactPersoon;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;

                range = xlWorkSheet.get_Range("A" + index.ToString());
                range.Value = "  " + p.Hoedanigheid;
                range.Font.Italic = true;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Adres;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Fax : " + p.Fax;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "E-mail : " + p.Email;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Postcode + " " + p.Gemeente;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Gsm : " + p.Gsm;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "Ref : " + p.Referentie;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                index++;

                foreach (var var2 in xtegenpartijen)
                {
                    Partij subpartij = (Partij)var2;
                    if (subpartij.Hoofdpartij_id.Equals(p.Id))
                    {
                        rangeindex = index + 3;
                        range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + rangeindex.ToString());
                        range.Style = substijl;

                        range = xlWorkSheet.get_Range("B" + index.ToString());
                        range.Value = subpartij.Hoedanigheid;
                        range.Font.Underline = true;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Naam;
                        range.Font.Bold = true;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Tel : " + subpartij.Tel;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Cntct : " + subpartij.ContactPersoon;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 13;

                        range = xlWorkSheet.get_Range("B" + index.ToString(), "H" + index.ToString());
                        range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = 1;
                        range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;

                        index++;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Adres;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Fax : " + subpartij.Fax;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "E-mail : " + subpartij.Email;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 11;
                        index++;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Postcode + " " + subpartij.Gemeente;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Gsm : " + subpartij.Gsm;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Ref : " + subpartij.Referentie;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 11;
                        index++;
                    }
                }
                index++;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                range.Interior.Color = 14540253;
                index++;

                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                index++;
            }

            #endregion

            frmDetails.Instance.prgrsBar.Value = 85;

            #region Fill Andere
            foreach (var item in anderen)
            {
                Partij p = (Partij)item;

                int rangeindex = index + 2;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + rangeindex.ToString());
                range.Style = hoofdstijl;

                range = xlWorkSheet.get_Range("A" + index.ToString());
                range.Value = "  Andere";
                range.Font.Underline = true;
                range.Font.Bold = true;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Naam;
                range.Font.Bold = true;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Tel : " + p.Tel;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "Cntct : " + p.ContactPersoon;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;

                range = xlWorkSheet.get_Range("A" + index.ToString());
                range.Value = "  " + p.Hoedanigheid;
                range.Font.Italic = true;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Adres;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Fax : " + p.Fax;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "E-mail : " + p.Email;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;

                range = xlWorkSheet.get_Range("B" + index.ToString(), "C" + index.ToString());
                range.MergeCells = true;
                range.Value = p.Postcode + " " + p.Gemeente;

                range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                range.MergeCells = true;
                range.Value = "Gsm : " + p.Gsm;

                range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.Value = "Ref : " + p.Referentie;
                range.EntireRow.AutoFit();
                range.EntireRow.RowHeight = 12;
                index++;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                index++;

                foreach (var var2 in xanderen)
                {
                    Partij subpartij = (Partij)var2;
                    if (subpartij.Hoofdpartij_id.Equals(p.Id))
                    {
                        rangeindex = index + 3;
                        range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + rangeindex.ToString());
                        range.Style = substijl;

                        range = xlWorkSheet.get_Range("B" + index.ToString());
                        range.Value = subpartij.Hoedanigheid;
                        range.Font.Underline = true;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Naam;
                        range.Font.Bold = true;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Tel : " + subpartij.Tel;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Cntct : " + subpartij.ContactPersoon;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 13;

                        range = xlWorkSheet.get_Range("B" + index.ToString(), "H" + index.ToString());
                        range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = 1;
                        range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;

                        index++;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Adres;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Fax : " + subpartij.Fax;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "E-mail : " + subpartij.Email;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 11;
                        index++;

                        range = xlWorkSheet.get_Range("C" + index.ToString());
                        range.MergeCells = true;
                        range.Value = subpartij.Postcode + " " + subpartij.Gemeente;

                        range = xlWorkSheet.get_Range("D" + index.ToString(), "E" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Gsm : " + subpartij.Gsm;

                        range = xlWorkSheet.get_Range("F" + index.ToString(), "H" + index.ToString());
                        range.MergeCells = true;
                        range.Value = "Ref : " + subpartij.Referentie;
                        range.EntireRow.AutoFit();
                        range.EntireRow.RowHeight = 11;
                        index++;
                    }
                }
                index++;
                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                range.Interior.Color = 14540253;
                index++;

                range = xlWorkSheet.get_Range("A" + index.ToString(), "H" + index.ToString());
                range.MergeCells = true;
                range.RowHeight = 5;
                index++;

            }

            #endregion
            frmDetails.Instance.prgrsBar.Value = 100;

            xlWorkSheet.PageSetup.PrintArea = "A1:H"+index;
            xlApp.Visible = true;
            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);
            frmDetails.Instance.prgrsBar.Value = 0;
            frmDetails.Instance.prgrsBar.Visible = false;
        }

        public void buildPayment(ArrayList facturen, String expert, String datum)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range range;

            xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Kon Excel niet starten, kijk uw softwareinstelling na !");
                return;
            }

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Name = "Facturen";
            int rij = 1;

            range = xlWorkSheet.get_Range("A1", "G1");
            range.MergeCells = true;
            range.Value = "Facturen van "+datum+" voor: "+expert;
            range.Font.Bold = true;
            range.Font.Underline = true;
            range.Font.Size = 22;

            range = xlWorkSheet.get_Range("A3");
            range.Value = "Datum";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("B3");
            range.Value = "FactuurNummer";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("C3");
            range.Value = "Referentie";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("D3");
            range.Value = "Erelonen";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("E3");
            range.Value = "Onkosten";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("F3");
            range.Value = "BTW";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("G3");
            range.Value = "Totaal";
            range.Font.Bold = true;
            range.Font.Underline = true;

            range = xlWorkSheet.get_Range("H3");
            range.Value = "Maatschappij";
            range.Font.Bold = true;
            range.Font.Underline = true;

            rij = 5;

            for (int i = 0; i < facturen.Count; i++)
            {
                Factuur factuur = (Factuur) facturen[i];
                string cell = "A" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Datum;

                cell = "B" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Factuurnummer;

                cell = "C" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Referentie;

                cell = "D" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Erelonen;

                cell = "E" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Onkosten;

                cell = "F" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Btw;

                cell = "G" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Totaal;

                cell = "H" + rij.ToString();
                range = xlWorkSheet.get_Range(cell);
                range.Value = factuur.Maatschappij;

                rij++;
            }

            rij++;

            range = xlWorkSheet.get_Range("F" + rij.ToString());
            range.Value = "Totaal Erelonen";

            range = xlWorkSheet.get_Range("G" + rij.ToString());
            range.Formula = "=SUM(D5:D"+ (rij-2).ToString() +")";
            rij++;

            range = xlWorkSheet.get_Range("F" + rij.ToString());
            range.Value = "Totaal Onkosten";

            range = xlWorkSheet.get_Range("G" + rij.ToString());
            range.Formula = "=SUM(E5:E" + (rij - 3).ToString() + ")";
            rij++;

            range = xlWorkSheet.get_Range("F" + rij.ToString());
            range.Value = "Totaal BTW";

            range = xlWorkSheet.get_Range("G" + rij.ToString());
            range.Formula = "=SUM(F5:F" + (rij - 4).ToString() + ")";
            rij++;

            range = xlWorkSheet.get_Range("G" + rij.ToString());
            range.Value = "Totaal incl; BTW";
            range.Font.Bold = true;

            range = xlWorkSheet.get_Range("G" + rij.ToString());
            range.Formula = "=SUM(G5:G" + (rij - 5).ToString() + ")";
            range.Font.Bold = true;


            range = xlWorkSheet.get_Range("D" + rij.ToString(), "E" + rij.ToString());
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = 4;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;

            xlWorkSheet.Columns.AutoFit();
            range = xlWorkSheet.get_Range("C3", "C" + rij.ToString());
            range.NumberFormat = "#,##0.00_);[Red](#,##0.00)";
            range = xlWorkSheet.get_Range("D3", "D" + rij.ToString());
            range.NumberFormat = "€ #,##0.00_);[Red](€ #,##0.00)";
            range = xlWorkSheet.get_Range("E3", "E" + rij.ToString());
            range.NumberFormat = "€ #,##0.00_);[Red](€ #,##0.00)";
            range = xlWorkSheet.get_Range("F3", "F" + rij.ToString());
            range.NumberFormat = "€ #,##0.00_);[Red](€ #,##0.00)";
            range = xlWorkSheet.get_Range("G3", "G" + rij.ToString());
            range.NumberFormat = "€ #,##0.00_);[Red](€ #,##0.00)";
            xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

           
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
