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
    public partial class GeneralInventoryReportForm : Form
    {
        private string dateIni;
        private string dateEnd;
        private InventoryLogic inventoryLogic;
        private List<EInventoryGeneral> Invetoriesg;
        public GeneralInventoryReportForm(string dateIni, string dateEnd)
        {
            InitializeComponent();
            inventoryLogic = new InventoryLogic();
            Invetoriesg = new List<EInventoryGeneral>();
            this.dateIni = dateIni;
            this.dateEnd = dateEnd;
        }

        private void GeneralInventoryReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewerGeneralInventary.Reset();
                this.LoadInventoryGeneral();
                ReportDataSource rptSrc = new ReportDataSource("DataSet1", this.Invetoriesg);
                reportViewerGeneralInventary.LocalReport.DataSources.Add(rptSrc);
               // reportViewerGeneralInventary.LocalReport.ReportPath = @"..\\..\\SnapSoft-Technology\\SISWARE\\ReportGeneralInventory.rdlc";

                //reportViewerGeneralInventary.LocalReport.ReportPath = @"..\\..\\com\\sisware\\gui\\form\\reporting\\ReportGeneralInventory.rdlc";
                reportViewerGeneralInventary.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportGeneralInventory.rdlc";
                reportViewerGeneralInventary.LocalReport.Refresh();
                reportViewerGeneralInventary.RefreshReport();

                //Enviando Parametros
                ReportParameter ParamdateIni = new ReportParameter("dateIni", this.dateIni);
                ReportParameter ParamdateEnd = new ReportParameter("dateEnd", this.dateEnd);
                reportViewerGeneralInventary.LocalReport.SetParameters(ParamdateIni);
                reportViewerGeneralInventary.LocalReport.SetParameters(ParamdateEnd);
                reportViewerGeneralInventary.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadInventoryGeneral()
        {
            try
            {
                DataTable dataInvetory = new DataTable();
                DataTable dataInventory = new DataTable();
                DataTable dataInventoryOutput = new DataTable();
                DataTable dataInventoryInput = new DataTable();
                dataInvetory = inventoryLogic.reportGeneralInventory();
                string codeArticle = "";
                int codeArt=0;
                double priceUfv = 0;
                for(int i=0; i<dataInvetory.Rows.Count; i++)
                {
                    codeArt = Convert.ToInt32(dataInvetory.Rows[i].ItemArray[4]);
                    dataInventory = inventoryLogic.reportGeneralInventory1(codeArt, this.dateIni, this.dateEnd);
                    string dato =dataInventory.Rows[0].ItemArray[0].ToString();
                    if (dato != "")
                    {
                        EInventoryGeneral inventori = new EInventoryGeneral();
                        inventori.ca_code = Convert.ToInt32(dataInvetory.Rows[i].ItemArray[0]);
                        inventori.ca_description = dataInvetory.Rows[i].ItemArray[1].ToString();
                        codeArticle = dataInvetory.Rows[i].ItemArray[2].ToString() + "" + dataInvetory.Rows[i].ItemArray[3].ToString() + "" + dataInvetory.Rows[i].ItemArray[5].ToString();
                        inventori.code = codeArticle;
                        inventori.description = dataInvetory.Rows[i].ItemArray[6].ToString();
                        inventori.unid = dataInvetory.Rows[i].ItemArray[7].ToString();
                        priceUfv = Convert.ToDouble(dataInventory.Rows[0].ItemArray[0]) / Convert.ToDouble(dataInventory.Rows[0].ItemArray[1]);
                        inventori.ufv = priceUfv;
                        inventori.balance_init = Convert.ToDouble(dataInventory.Rows[0].ItemArray[2]);
                        inventori.bsUnitPrice = Convert.ToDouble(dataInventory.Rows[0].ItemArray[1]);
                        dataInventoryOutput = inventoryLogic.reportGeneralInventory2(codeArt, this.dateIni, this.dateEnd);
                        string output = dataInventoryOutput.Rows[0].ItemArray[0].ToString();
                        if (output != "")
                        {
                            inventori.balance = Convert.ToDouble(dataInventoryOutput.Rows[0].ItemArray[0]);
                        }
                        else
                        {
                            inventori.balance = 0;
                        }
                        dataInventoryInput = inventoryLogic.reportGeneralInventory3(codeArt);
                        inventori.date = DateTime.Parse(dataInventoryInput.Rows[0].ItemArray[0].ToString());
                        this.Invetoriesg.Add(inventori);
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
