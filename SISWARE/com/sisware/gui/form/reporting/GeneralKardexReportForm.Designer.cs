namespace com.sisware.gui.form.reporting
{
    partial class GeneralKardexReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerKardex = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerKardex
            // 
            this.reportViewerKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerKardex.Location = new System.Drawing.Point(0, 0);
            this.reportViewerKardex.Name = "reportViewerKardex";
            this.reportViewerKardex.Size = new System.Drawing.Size(989, 595);
            this.reportViewerKardex.TabIndex = 0;
            // 
            // GeneralKardexReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 595);
            this.Controls.Add(this.reportViewerKardex);
            this.Name = "GeneralKardexReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Kardex";
            this.Load += new System.EventHandler(this.KardexReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerKardex;
    }
}