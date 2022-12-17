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
    public partial class OutputByEmployeeForm : Form
    {
        private OutputLogic outputLogic;
        private string outputControlCode  = string.Empty;
        private string literal = string.Empty;
        public OutputByEmployeeForm()
        {
            InitializeComponent();
            outputLogic = new OutputLogic();
        }

        public void setValues(string outputControlCode, string literal)
        {
            this.outputControlCode = outputControlCode;
            this.literal = literal;
        }

        private void OutputByEmployeeForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            //ReportDataSource rptSrc = new ReportDataSource("DataSet1", outputLogic.ReportGetByEmployee(this.outputControlCode));
            //ReportParameter literal = new ReportParameter("literal", this.literal);
            //reportViewer1.LocalReport.DataSources.Add(rptSrc);
            //reportViewer1.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportOutputByEmployee.rdlc";
           // reportViewer1.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportOutputByEmployee.rdlc";
            reportViewer1.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportOutputByEmployee.rdlc";
            //reportViewer1.LocalReport.SetParameters(literal);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
