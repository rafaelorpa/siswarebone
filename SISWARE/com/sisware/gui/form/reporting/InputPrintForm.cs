using com.sisware.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace com.sisware.gui.form.reporting
{
    public partial class InputPrintForm : Form
    {
        private InputLogic inputLogic;
        private string inputNumber;
        private string valueLiteral;
        public InputPrintForm(string inputNum, string valueLiteral)
        {
            InitializeComponent();
            inputLogic = new InputLogic();
            this.inputNumber = inputNum;
            this.valueLiteral = valueLiteral;
        }

        public void setValues(string inputNum, string literal)
        {
            this.inputNumber = inputNum;
            this.valueLiteral = literal;
        }


        private void InputPrintForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.Reset();
                ReportDataSource rptSrc = new ReportDataSource("DataSet2", inputLogic.reportGetByInputNumber(inputNumber));
               // ReportParameter paramValueL = new ReportParameter("ValueLiteral", this.valueLiteral);
                reportViewer1.LocalReport.DataSources.Add(rptSrc);
               // reportViewer1.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportInputPrint.rdlc";
               // reportViewer1.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportInputPrint.rdlc";
                reportViewer1.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportInputPrint.rdlc";
                //reportViewer1.LocalReport.SetParameters(paramValueL);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //this.reportViewer1.RefreshReport();
        }
    }
}
