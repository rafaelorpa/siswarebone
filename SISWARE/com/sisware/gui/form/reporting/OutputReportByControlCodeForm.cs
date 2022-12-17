using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sisware.logic;

namespace com.sisware.gui.form.reporting
{
    public partial class OutputReportByControlCodeForm : Form
    {
        private OutputLogic outputLogic;
        public OutputReportByControlCodeForm()
        {
            InitializeComponent();
            outputLogic = new OutputLogic();
        }

        private void OutputReportByControlCodeForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            //ReportDataSource rptSrc = new ReportDataSource("DataSet1", outputLogic.reportGetAll());
            //reportViewer1.LocalReport.DataSources.Add(rptSrc);
            //reportViewer1.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportOutputByControlCode.rdlc";
            //reportViewer1.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportOutputByControlCode.rdlc";
            reportViewer1.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportOutputByControlCode.rdlc";
             
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
