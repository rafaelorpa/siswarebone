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
    public partial class GeneralArticleReport : Form
    {
        private ArticleLogic articleLogic;
        public GeneralArticleReport()
        {
            InitializeComponent();
            articleLogic = new ArticleLogic();
        }

        private void GeneralArticleReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.Reset();
                ReportDataSource rptSrc = new ReportDataSource("DataSet1", articleLogic.reportGeneralArticle());
                reportViewer1.LocalReport.DataSources.Add(rptSrc);
                //reportViewer1.LocalReport.ReportPath = @"..\\..\\com\\sisware\\gui\\form\\reporting\\ReportGeneralArticle.rdlc";
                //reportViewer1.LocalReport.ReportPath = @"..\\..\\SnapSoft-Technology\\SISWARE\\ReportGeneralArticle.rdlc";

                reportViewer1.LocalReport.ReportPath = SISWARE.Properties.Settings.Default.reportPath + "ReportGeneralArticle.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
