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
    public partial class OutputArticleReport : Form
    {
        private Int32 codeArticle;
        private string nameArticle;
        private OutputLogic outputLogic;
        public OutputArticleReport( Int32 codeArt, string nameArt )
        {
            InitializeComponent();
            codeArticle = codeArt;
            nameArticle = nameArt;
            outputLogic = new OutputLogic();
        }

        private void OutputArticleReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.Reset();
                //ReportDataSource rptSrc = new ReportDataSource("DataSet1", outputLogic.ReportOutputArticle(this.codeArticle));
                //reportViewer1.LocalReport.DataSources.Add(rptSrc);
                //reportViewer1.LocalReport.ReportPath = @"..\..\SnapSoft-Technology\SISWARE\ReportOutputArticle.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"..\..\com\sisware\gui\form\reporting\ReportOutputArticle.rdlc";
                reportViewer1.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportOutputArticle.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

                ReportParameter ParamdateIni = new ReportParameter("nameArticle", this.nameArticle);
                reportViewer1.LocalReport.SetParameters(ParamdateIni);
                reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
