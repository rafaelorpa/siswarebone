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
    public partial class GeneralConsumptionReportForm : Form
    {
        private string dateIni;
        private string dateEnd;
        private InventoryLogic inventoryLogic;
        public GeneralConsumptionReportForm(string dateIni, string dateEnd)
        {
            InitializeComponent();
            inventoryLogic = new InventoryLogic();
            this.dateIni = dateIni;
            this.dateEnd = dateEnd;
        }

        private void GeneralConsumptionReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewerGeneralConsumption.Reset();
                ReportDataSource rptSrc = new ReportDataSource("DataSet1", inventoryLogic.reportGeneralConsumption(this.dateIni, this.dateEnd));
                reportViewerGeneralConsumption.LocalReport.DataSources.Add(rptSrc);
               // reportViewerGeneralConsumption.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportGeneralConsumtion.rdlc";
                //reportViewerGeneralConsumption.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportGeneralConsumtion.rdlc";
                reportViewerGeneralConsumption.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportGeneralConsumtion.rdlc";
                reportViewerGeneralConsumption.LocalReport.Refresh();
                reportViewerGeneralConsumption.RefreshReport();

                //Enviando Parametros
                ReportParameter ParamdateIni = new ReportParameter("dateini", this.dateIni);
                ReportParameter ParamdateEnd = new ReportParameter("dateEnd", this.dateEnd);
                reportViewerGeneralConsumption.LocalReport.SetParameters(ParamdateIni);
                reportViewerGeneralConsumption.LocalReport.SetParameters(ParamdateEnd);
                reportViewerGeneralConsumption.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
