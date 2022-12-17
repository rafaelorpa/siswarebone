namespace com.sisware.gui.form.reporting
{
    partial class InputArticleReport
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
            this.reportViewerInputArticle = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerInputArticle
            // 
            this.reportViewerInputArticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerInputArticle.Location = new System.Drawing.Point(0, 0);
            this.reportViewerInputArticle.Name = "reportViewerInputArticle";
            this.reportViewerInputArticle.Size = new System.Drawing.Size(939, 545);
            this.reportViewerInputArticle.TabIndex = 0;
            // 
            // InputArticleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 545);
            this.Controls.Add(this.reportViewerInputArticle);
            this.Name = "InputArticleReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte del Ingreso de un Producto";
            this.Load += new System.EventHandler(this.InputArticleReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerInputArticle;
    }
}