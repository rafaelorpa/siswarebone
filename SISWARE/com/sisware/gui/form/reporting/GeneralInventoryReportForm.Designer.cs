namespace com.sisware.gui.form.reporting
{
    partial class GeneralInventoryReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralInventoryReportForm));
            this.reportViewerGeneralInventary = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerGeneralInventary
            // 
            this.reportViewerGeneralInventary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerGeneralInventary.Location = new System.Drawing.Point(0, 0);
            this.reportViewerGeneralInventary.Name = "reportViewerGeneralInventary";
            this.reportViewerGeneralInventary.Size = new System.Drawing.Size(1016, 590);
            this.reportViewerGeneralInventary.TabIndex = 0;
            // 
            // GeneralInventoryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 590);
            this.Controls.Add(this.reportViewerGeneralInventary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralInventoryReportForm";
            this.Text = "Reporte General del Inventario";
            this.Load += new System.EventHandler(this.GeneralInventoryReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerGeneralInventary;
    }
}