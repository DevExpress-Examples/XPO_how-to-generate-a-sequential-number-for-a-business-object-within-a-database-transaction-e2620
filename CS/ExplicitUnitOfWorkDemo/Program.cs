using System;
using DevExpress.Xpo;
using System.Windows.Forms;
using System.Configuration;

namespace ExplicitUnitOfWorkDemo {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            InitDAL();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());        
        }
        private static void InitDAL() {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            XpoDefault.Session = null;
            XpoDefault.DataLayer = DatabaseHelper.DataLayer = XpoDefault.GetDataLayer(cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            DatabaseHelper.SequenceDataLayer = XpoDefault.GetDataLayer(cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
        }

   }
}