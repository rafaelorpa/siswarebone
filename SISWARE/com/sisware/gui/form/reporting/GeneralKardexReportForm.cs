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
    public partial class GeneralKardexReportForm : Form
    {
        private Int32 codeSubcategory;
        private InventoryLogic inventoryLogic;
        private String nameSubCat;
        public GeneralKardexReportForm()
        {
            InitializeComponent();
            
            inventoryLogic = new InventoryLogic();
        }

        private void KardexReportForm_Load(object sender, EventArgs e)
        {

            try
            {
                this.reportViewerKardex.Reset();
                ReportDataSource rptSrc = new ReportDataSource("DataSet1", inventoryLogic.reportGeneralKardex());
                reportViewerKardex.LocalReport.DataSources.Add(rptSrc);
                //reportViewerKardex.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\GeneralReportKardex.rdlc";
                //reportViewerKardex.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\GeneralReportKardex.rdlc";
                reportViewerKardex.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "GeneralReportKardex.rdlc";
                reportViewerKardex.LocalReport.Refresh();
                reportViewerKardex.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
