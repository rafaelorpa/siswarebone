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
    public partial class GeneralInputReportForm : Form
    {
        private InputLogic inputLogic;
        
        public GeneralInputReportForm()
        {
            InitializeComponent();
            inputLogic = new InputLogic();
        }

        private void GeneralInputReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewerGeneralI.Reset();
                ReportDataSource rptSrc = new ReportDataSource("DataSet1", inputLogic.reportGeneralInput());
                reportViewerGeneralI.LocalReport.DataSources.Add(rptSrc);
                //reportViewerGeneralI.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportGeneralInput.rdlc";
                //reportViewerGeneralI.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportGeneralInput.rdlc";

                reportViewerGeneralI.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportGeneralInput.rdlc";
                
                reportViewerGeneralI.LocalReport.Refresh();
                reportViewerGeneralI.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
