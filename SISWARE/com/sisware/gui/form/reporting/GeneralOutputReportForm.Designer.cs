namespace com.sisware.gui.form.reporting
{
    partial class GeneralOutputReportForm
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
            this.reportViewerGeneralOutput = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerGeneralOutput
            // 
            this.reportViewerGeneralOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerGeneralOutput.Location = new System.Drawing.Point(0, 0);
            this.reportViewerGeneralOutput.Name = "reportViewerGeneralOutput";
            this.reportViewerGeneralOutput.Size = new System.Drawing.Size(954, 729);
            this.reportViewerGeneralOutput.TabIndex = 0;
            // 
            // GeneralOutputReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 729);
            this.Controls.Add(this.reportViewerGeneralOutput);
            this.Name = "GeneralOutputReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte General de Salidas";
            this.Load += new System.EventHandler(this.GeneralOutputReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerGeneralOutput;
    }
}