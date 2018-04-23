Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports System.Windows.Forms
Imports System.Configuration

Namespace ExplicitUnitOfWorkDemo
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			InitDAL()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New frmMain())
		End Sub
		Private Shared Sub InitDAL()
			Dim cs As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
			XpoDefault.Session = Nothing
			DatabaseHelper.DataLayer = XpoDefault.GetDataLayer(cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
			XpoDefault.DataLayer = DatabaseHelper.DataLayer
			DatabaseHelper.SequenceDataLayer = XpoDefault.GetDataLayer(cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
		End Sub

	End Class
End Namespace