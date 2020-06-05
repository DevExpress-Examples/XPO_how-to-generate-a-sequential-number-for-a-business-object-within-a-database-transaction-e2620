Imports System
Imports DevExpress.Xpo
Imports System.Windows.Forms
Imports System.Configuration

Namespace ExplicitUnitOfWorkDemo
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			InitDAL()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New frmMain())
		End Sub
		Private Sub InitDAL()
			Dim cs As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
			XpoDefault.Session = Nothing
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: XpoDefault.DataLayer = DatabaseHelper.DataLayer = XpoDefault.GetDataLayer(cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
			DatabaseHelper.DataLayer = XpoDefault.GetDataLayer(cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
			XpoDefault.DataLayer = DatabaseHelper.DataLayer
			DatabaseHelper.SequenceDataLayer = XpoDefault.GetDataLayer(cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
		End Sub

	End Module
End Namespace