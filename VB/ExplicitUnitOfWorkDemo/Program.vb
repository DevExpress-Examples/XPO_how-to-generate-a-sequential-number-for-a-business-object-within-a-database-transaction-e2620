Imports System
Imports DevExpress.Xpo
Imports System.Configuration

Namespace ExplicitUnitOfWorkDemo

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call InitDAL()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New frmMain())
        End Sub

        Private Sub InitDAL()
            Dim cs As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            XpoDefault.Session = Nothing
            DataLayer = XpoDefault.GetDataLayer(cs, DB.AutoCreateOption.DatabaseAndSchema)
            XpoDefault.DataLayer = DataLayer
            SequenceDataLayer = XpoDefault.GetDataLayer(cs, DB.AutoCreateOption.DatabaseAndSchema)
        End Sub
    End Module
End Namespace
