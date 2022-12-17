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
    public partial class GeneralOutputReportForm : Form
    {
        private OutputLogic outputLogic;
        
        public GeneralOutputReportForm()
        {
            InitializeComponent();
            outputLogic = new OutputLogic();
        }

        private void GeneralOutputReportForm_Load(object sender, EventArgs e)
        {

            try
            {
                this.reportViewerGeneralOutput.Reset();
               // ReportDataSource rptSrc = new ReportDataSource("DataSet1", outputLogic.ReportGeneralOutput());
                //reportViewerGeneralOutput.LocalReport.DataSources.Add(rptSrc);
               // reportViewerGeneralOutput.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportGeneralOutput.rdlc";
                //reportViewerGeneralOutput.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportGeneralOutput.rdlc";
                reportViewerGeneralOutput.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportGeneralOutput.rdlc";
                reportViewerGeneralOutput.LocalReport.Refresh();
                reportViewerGeneralOutput.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
