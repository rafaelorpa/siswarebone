namespace com.sisware.gui.form.reporting
{
    partial class GeneralInputReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralInputReportForm));
            this.reportViewerGeneralI = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerGeneralI
            // 
            this.reportViewerGeneralI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerGeneralI.Location = new System.Drawing.Point(0, 0);
            this.reportViewerGeneralI.Name = "reportViewerGeneralI";
            this.reportViewerGeneralI.Size = new System.Drawing.Size(913, 783);
            this.reportViewerGeneralI.TabIndex = 0;
            // 
            // GeneralInputReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 783);
            this.Controls.Add(this.reportViewerGeneralI);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralInputReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte General de Entradas";
            this.Load += new System.EventHandler(this.GeneralInputReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerGeneralI;
    }
}