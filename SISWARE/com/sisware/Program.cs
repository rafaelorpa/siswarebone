using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.sisware.gui.form;
using com.snapsoft.util;


namespace com.sisware
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static MainForm mainForm;
        
        [STAThread]
        static void Main()
        {
            try
            {
                try
                {
                    Logger.Instance.changeLogName("SISWAREBONE");
                    Logger.Instance.changeLogLevel(Logger.DEBUG);
                    Logger.Instance.enableMessageBox(true);
                }
                catch (Exception)
                {
                    Application.Exit();
                }
                Logger.Instance.info("Application started");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                mainForm = new MainForm();
                Application.Run(mainForm);
             }
            catch (Exception e)
            {
                Logger.Instance.error(e.Message, e);
            }
        }
    }
}
