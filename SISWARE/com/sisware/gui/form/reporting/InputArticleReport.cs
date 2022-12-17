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
    public partial class InputArticleReport : Form
    {
        private Int32 codeArticle;
        private string nameArticle;
        private InputLogic inputLogic;
        public InputArticleReport( Int32 codeArt, string nameArt)
        {
            InitializeComponent();
            this.codeArticle = codeArt;
            this.nameArticle = nameArt;
            inputLogic = new InputLogic();
        }

        private void InputArticleReport_Load(object sender, EventArgs e)
        {

            try
            {
                this.reportViewerInputArticle.Reset();
                ReportDataSource rptSrc = new ReportDataSource("DataSet1", inputLogic.ReportInputArticle(this.codeArticle));
                reportViewerInputArticle.LocalReport.DataSources.Add(rptSrc);
              //  reportViewerInputArticle.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportInputArticle.rdlc";
                //reportViewerInputArticle.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportInputArticle.rdlc";
                reportViewerInputArticle.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportInputArticle.rdlc";
                reportViewerInputArticle.LocalReport.Refresh();
                reportViewerInputArticle.RefreshReport();

                ReportParameter ParamdateIni = new ReportParameter("nameArticle", this.nameArticle);
                reportViewerInputArticle.LocalReport.SetParameters(ParamdateIni);
                reportViewerInputArticle.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
