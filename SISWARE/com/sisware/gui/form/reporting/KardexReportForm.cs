using com.sisware.bean;
using com.sisware.logic;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sisware.gui.form.reporting
{
    public partial class KardexReportForm : Form
    {
        private Int32 codeSubcategory;
        private String codeArticle;
        private String descriptionAr;
        private InventoryLogic inventoryLogic;
        private String nameSubCat;
        private List<EKardex> kardexs;
        private int band;
        private DateTime dateini;
        private DateTime dateend;
        public KardexReportForm( Int32 codeSub, string nameSubC, int band)
        {
            InitializeComponent();
            this.codeSubcategory = codeSub;
            this.nameSubCat = nameSubC;
            kardexs = new List<EKardex>();
            inventoryLogic = new InventoryLogic();
            this.band = 1;
        }

        public KardexReportForm(Int32 codeSub, string nameSubC, DateTime datei, DateTime datee, int band)
        {
            InitializeComponent();
            this.codeSubcategory = codeSub;
            this.nameSubCat = nameSubC;
            this.dateini = datei;
            this.dateend = datee;
            kardexs = new List<EKardex>();
            inventoryLogic = new InventoryLogic();
            this.band = band;
        }

        private void KardexReportForm_Load(object sender, EventArgs e)
        {

            if (band == 1)
            {
                try
                {
                    this.reportViewerKardex.Reset();
                    this.LoadKardex();
                    ReportDataSource rptSrc = new ReportDataSource("DataSet1", this.kardexs);
                    reportViewerKardex.LocalReport.DataSources.Add(rptSrc);
                    // reportViewerKardex.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\Reportkardex.rdlc";
                    //reportViewerKardex.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\Reportkardex.rdlc";
                    reportViewerKardex.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "Reportkardex.rdlc";
                    reportViewerKardex.LocalReport.Refresh();
                    reportViewerKardex.RefreshReport();

                    ReportParameter ParamdateIni = new ReportParameter("codigoArticle", this.codeArticle);
                    reportViewerKardex.LocalReport.SetParameters(ParamdateIni);

                    ReportParameter ParamdateIni1 = new ReportParameter("descriptionArticle", this.descriptionAr);
                    reportViewerKardex.LocalReport.SetParameters(ParamdateIni1);
                    reportViewerKardex.RefreshReport();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (band == 2)
            {
                try
                {
                    this.reportViewerKardex.Reset();
                    this.LoadKardexForDate();
                    ReportDataSource rptSrc = new ReportDataSource("DataSet1", this.kardexs);
                    reportViewerKardex.LocalReport.DataSources.Add(rptSrc);
                    // reportViewerKardex.LocalReport.ReportPath = @"..\\..\\SnapSoft-Technology\\SISWARE\\Reportkardex.rdlc";
                    //reportViewerKardex.LocalReport.ReportPath = @"..\\..\\com\\sisware\\gui\\form\\reporting\\Reportkardex.rdlc";
                    reportViewerKardex.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "Reportkardex.rdlc";
                    reportViewerKardex.LocalReport.Refresh();
                    reportViewerKardex.RefreshReport();

                    ReportParameter ParamdateIni = new ReportParameter("codigoArticle", this.codeArticle);
                    reportViewerKardex.LocalReport.SetParameters(ParamdateIni);

                    ReportParameter ParamdateIni1 = new ReportParameter("descriptionArticle", this.descriptionAr);
                    reportViewerKardex.LocalReport.SetParameters(ParamdateIni1);
                    reportViewerKardex.RefreshReport();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadKardex()
        {
            try
            { 
            DataTable dataKardex1 = new DataTable();
            DataTable dataKardexInput = new DataTable();
            DataTable dataKardexOutput = new DataTable();
            

            dataKardex1 = inventoryLogic.reportKardex1(this.codeSubcategory);
            this.codeArticle = dataKardex1.Rows[0].ItemArray[0].ToString() + "" + dataKardex1.Rows[0].ItemArray[1].ToString() + "" + dataKardex1.Rows[0].ItemArray[2].ToString();
            this.descriptionAr = dataKardex1.Rows[0].ItemArray[3].ToString();

            dataKardexInput = inventoryLogic.reportKardexInput(this.codeSubcategory);
            dataKardexOutput = inventoryLogic.reportKardexOutput(this.codeSubcategory);
            
            double quantity = 0;
            //double change = 0;
            double unitPrice = 0;
            double ufvUnitPrice = 0;
            int lotinput = 0, lotoutput=0;
            int numberInput = 0, numberOutput = 0;
            int j = 0;
            for (int i=0; i < dataKardexInput.Rows.Count; i++ )
            {
                EKardex kardexinput = new EKardex();
                kardexinput.date = DateTime.Parse(dataKardexInput.Rows[i].ItemArray[0].ToString());
                kardexinput.hour = dataKardexInput.Rows[i].ItemArray[1].ToString();
                unitPrice = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[7]);
                ufvUnitPrice = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[6]);
                kardexinput.exchange = ufvUnitPrice / unitPrice;
                kardexinput.detail = dataKardexInput.Rows[i].ItemArray[3].ToString();
                lotinput = Convert.ToInt32( dataKardexInput.Rows[i].ItemArray[4]);
                kardexinput.lote = lotinput;
                kardexinput.quantity_input = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[2]);
                kardexinput.bsUnitPrice_input = unitPrice;
                quantity = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[5]);
                kardexinput.quantity_saldo = quantity;
                kardexinput.bsUnitPrice_saldo = unitPrice;
                numberInput = Convert.ToInt32(dataKardexInput.Rows[i].ItemArray[8]);
                kardexinput.numberInput = numberInput.ToString();
                this.kardexs.Add(kardexinput);

                double quantitydes = 0;
                double quantity2 = 0;
                lotoutput = Convert.ToInt32(dataKardexOutput.Rows[j].ItemArray[4]);



                while ((lotinput == lotoutput) && (j < dataKardexOutput.Rows.Count))
                {
                    EKardex kardexoutput = new EKardex();
                    numberOutput = Convert.ToInt32(dataKardexOutput.Rows[j].ItemArray[8]);
                    
                    if (numberOutput != 0)
                    {
                        kardexoutput.date = DateTime.Parse(dataKardexOutput.Rows[j].ItemArray[0].ToString());
                        kardexoutput.hour = dataKardexOutput.Rows[j].ItemArray[1].ToString();
                        unitPrice = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[7]);
                        ufvUnitPrice = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[6]);
                        kardexoutput.exchange = ufvUnitPrice / unitPrice;
                        kardexoutput.detail = dataKardexOutput.Rows[j].ItemArray[3].ToString();
                        kardexoutput.lote = lotoutput;
                        quantitydes = quantitydes + Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[2]);
                        kardexoutput.quantity_output = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[2]);
                        kardexoutput.bsUnitPrice_output = unitPrice;
                        quantity2 = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[5]) - quantitydes;
                        kardexoutput.quantity_saldo = quantity2;
                        kardexoutput.bsUnitPrice_saldo = unitPrice;
                        kardexoutput.numberOutput = numberOutput.ToString();
                        this.kardexs.Add(kardexoutput);
                    }

                    if (j < dataKardexOutput.Rows.Count)
                    {
                        lotoutput = Convert.ToInt32(dataKardexOutput.Rows[j].ItemArray[4]);
                        j++;
                    }
                    else
                        lotoutput = lotoutput + 1;
                    
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadKardexForDate()
        {
            try
            {
                DataTable dataKardex1 = new DataTable();
                DataTable dataKardexInput = new DataTable();
                DataTable dataKardexOutput = new DataTable();


                dataKardex1 = inventoryLogic.reportKardex1(this.codeSubcategory);
                this.codeArticle = dataKardex1.Rows[0].ItemArray[0].ToString() + "" + dataKardex1.Rows[0].ItemArray[1].ToString() + "" + dataKardex1.Rows[0].ItemArray[2].ToString();
                this.descriptionAr = dataKardex1.Rows[0].ItemArray[3].ToString();

                dataKardexInput = inventoryLogic.reportKardexInput(this.codeSubcategory);
                dataKardexOutput = inventoryLogic.reportKardexOutput(this.codeSubcategory);

                double quantity = 0;
                //double change = 0;
                double unitPrice = 0;
                double ufvUnitPrice = 0;
                int lotinput = 0, lotoutput = 0;
                int numberInput = 0, numberOutput = 0;
                int j = 0;
                DateTime dateinput,dateoutput;
                for (int i = 0; i < dataKardexInput.Rows.Count; i++)
                {
                    dateinput= DateTime.Parse(dataKardexInput.Rows[i].ItemArray[0].ToString());
                    lotinput = Convert.ToInt32(dataKardexInput.Rows[i].ItemArray[4]);
                    int result1 = DateTime.Compare(dateinput, this.dateini);
                    int result2 = DateTime.Compare(dateinput, this.dateend);
                    
                   // if (((result1 >= 0) && (result2 <= 0)) || ((resultoutput1 >= 0) && (resultoutput2 <= 0)))
                    if ((result1 >= 0) && (result2 <= 0))
                    {

                        EKardex kardexinput = new EKardex();
                        kardexinput.date = dateinput;
                        kardexinput.hour = dataKardexInput.Rows[i].ItemArray[1].ToString();
                        unitPrice = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[7]);
                        ufvUnitPrice = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[6]);
                        kardexinput.exchange = ufvUnitPrice / unitPrice;
                        kardexinput.detail = dataKardexInput.Rows[i].ItemArray[3].ToString();
                        kardexinput.lote = lotinput;
                        kardexinput.quantity_input = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[2]);
                        kardexinput.bsUnitPrice_input = unitPrice;
                        quantity = Convert.ToDouble(dataKardexInput.Rows[i].ItemArray[5]);
                        kardexinput.quantity_saldo = quantity;
                        kardexinput.bsUnitPrice_saldo = unitPrice;
                        numberInput = Convert.ToInt32(dataKardexInput.Rows[i].ItemArray[8]);
                        kardexinput.numberInput = numberInput.ToString();
                        this.kardexs.Add(kardexinput);
                    }
                        double quantitydes = 0;
                        double quantity2 = 0;
                        lotoutput = Convert.ToInt32(dataKardexOutput.Rows[j].ItemArray[4]);



                        while ((lotinput == lotoutput) && (j < dataKardexOutput.Rows.Count))
                        {
                            EKardex kardexoutput = new EKardex();
                            numberOutput = Convert.ToInt32(dataKardexOutput.Rows[j].ItemArray[8]);

                            if (numberOutput != 0)
                            {
                                dateoutput = DateTime.Parse(dataKardexOutput.Rows[j].ItemArray[0].ToString());
                                int resultoutput1 = DateTime.Compare(dateoutput, this.dateini);
                                int resultoutput2 = DateTime.Compare(dateoutput, this.dateend);
                                if ((resultoutput1 >= 0) && (resultoutput2 <= 0))
                                {
                                    kardexoutput.date = dateoutput;
                                    kardexoutput.hour = dataKardexOutput.Rows[j].ItemArray[1].ToString();
                                    unitPrice = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[7]);
                                    ufvUnitPrice = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[6]);
                                    kardexoutput.exchange = ufvUnitPrice / unitPrice;
                                    kardexoutput.detail = dataKardexOutput.Rows[j].ItemArray[3].ToString();
                                    kardexoutput.lote = lotoutput;
                                    quantitydes = quantitydes + Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[2]);
                                    kardexoutput.quantity_output = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[2]);
                                    kardexoutput.bsUnitPrice_output = unitPrice;
                                    quantity2 = Convert.ToDouble(dataKardexOutput.Rows[j].ItemArray[5]) - quantitydes;
                                    kardexoutput.quantity_saldo = quantity2;
                                    kardexoutput.bsUnitPrice_saldo = unitPrice;
                                    kardexoutput.numberOutput = numberOutput.ToString();
                                    this.kardexs.Add(kardexoutput);
                                }
                            }

                            if (j < dataKardexOutput.Rows.Count)
                            {
                                lotoutput = Convert.ToInt32(dataKardexOutput.Rows[j].ItemArray[4]);
                                j++;
                            }
                            else
                                lotoutput = lotoutput + 1;

                        }
                    }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
