namespace com.sisware.gui.form.reporting
{
    partial class GeneralConsumptionReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralConsumptionReportForm));
            this.reportViewerGeneralConsumption = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerGeneralConsumption
            // 
            this.reportViewerGeneralConsumption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerGeneralConsumption.Location = new System.Drawing.Point(0, 0);
            this.reportViewerGeneralConsumption.Name = "reportViewerGeneralConsumption";
            this.reportViewerGeneralConsumption.Size = new System.Drawing.Size(1047, 642);
            this.reportViewerGeneralConsumption.TabIndex = 0;
            // 
            // GeneralConsumptionReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 642);
            this.Controls.Add(this.reportViewerGeneralConsumption);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralConsumptionReportForm";
            this.Text = "Reporte General de Consumo";
            this.Load += new System.EventHandler(this.GeneralConsumptionReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerGeneralConsumption;
    }
}