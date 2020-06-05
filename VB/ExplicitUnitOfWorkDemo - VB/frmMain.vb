Imports System
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors
Imports System.Collections.Generic

Namespace ExplicitUnitOfWorkDemo
	Partial Public Class frmMain
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub btnRecreateAddress_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRecreateAddress.Click
			Dim row As ViewRecord = TryCast(gridView1.GetFocusedRow(), ViewRecord)
			If row Is Nothing Then
				Return
			End If
			Dim personOid As Long = RecreateAddress(row)
			UpdateRows()
			gridView1.SetFocusedRowCellValue(colOid, personOid)
		End Sub
		Private Shared Function RecreateAddress(ByVal selectedRow As ViewRecord) As Long
			Dim personOid As Long
			Using explicitUnitOfWork As New ExplicitUnitOfWork(DatabaseHelper.DataLayer)
				'Get selected person object.
				Dim person As Person = explicitUnitOfWork.GetObjectByKey(Of Person)(selectedRow("Oid"))
				If person Is Nothing OrElse person.Address Is Nothing Then
					Throw New ArgumentNullException("person")
				End If
				'Remember person key value.
				personOid = person.Oid
				Dim address As Address = person.Address
				Dim addressOid As Long = address.Oid
				Dim referenceList As New List(Of Person)(address.Persons)
				'Reset references to the Address object.
				For i As Integer = 0 To referenceList.Count - 1
					referenceList(i).Address = Nothing
				Next i
				'Delete the Address object.
				explicitUnitOfWork.Delete(address)
				'Save changes to the database in case of an explicit transaction.
				explicitUnitOfWork.FlushChanges()

				'Create a new instance of the Address object.
				address = DatabaseHelper.CreateNewAddress(explicitUnitOfWork, addressOid)
				'Recover references to the Address object.
				For i As Integer = 0 To referenceList.Count - 1
					referenceList(i).Address = address
				Next i
				explicitUnitOfWork.CommitChanges()
			End Using
			Return personOid
		End Function
		Private Sub btnCreatePerson_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreatePerson.Click
			CreatePerson()
			UpdateRows()
		End Sub
		Private Shared Sub CreatePerson()
			Dim personOid As Long
			Using uow As New UnitOfWork(DatabaseHelper.SequenceDataLayer)
				Dim address As Address
				Using sg As New SequenceGenerator(Of Address)(DatabaseHelper.SequenceDataLayer)
					address = DatabaseHelper.CreateNewAddress(uow, sg.GetNextId())
					uow.CommitChanges()
					sg.Accept()
				End Using
				Using sg As New SequenceGenerator(Of Person)(DatabaseHelper.SequenceDataLayer)
					Dim person As Person = DatabaseHelper.CreateNewPerson(uow, sg.GetNextId())
					personOid = person.Oid
					person.Address = address
					uow.CommitChanges()
					sg.Accept()
				End Using
			End Using
		End Sub
		Private Sub btnCreatePersons_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreatePersons.Click
			CreatePersons()
			UpdateRows()
		End Sub
		Private Shared Sub CreatePersons()
			Using uow As New UnitOfWork(DatabaseHelper.SequenceDataLayer)
				Dim addressList As New List(Of Address)()
				Using sg As New SequenceGenerator(Of Address)(DatabaseHelper.SequenceDataLayer)
					For i As Integer = 0 To 9
						Dim address As Address = DatabaseHelper.CreateNewAddress(uow, sg.GetNextId())
						addressList.Add(address)
					Next i
					uow.CommitChanges()
					sg.Accept()
				End Using
				Using sg As New SequenceGenerator(Of Person)(DatabaseHelper.SequenceDataLayer)
					For i As Integer = 0 To 9
						For k As Integer = 0 To 9
							Dim person As Person = DatabaseHelper.CreateNewPerson(uow, sg.GetNextId())
							person.Address = addressList(i)
						Next k
					Next i
					uow.CommitChanges()
					sg.Accept()
				End Using
			End Using
		End Sub

		Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
			UpdateRows()
		End Sub
		Private Sub UpdateRows()
			xpView1.TopReturnedRecords = CInt(Math.Truncate(spinEdit1.Value))
			xpView1.Reload()
		End Sub
		Private Sub btnClearDB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearDB.Click
			ClearDatabase()
			UpdateRows()
		End Sub
		Private Shared Sub ClearDatabase()
			Using uow As New UnitOfWork(DatabaseHelper.DataLayer)
				Dim personList As New XPCollection(Of Person)(uow)
				Dim addressList As New XPCollection(Of Address)(uow)
				Dim sequencList As New XPCollection(Of Sequence)(uow)
				uow.Delete(personList)
				uow.Delete(addressList)
				uow.Delete(sequencList)
				uow.CommitChanges()
			End Using
		End Sub
	End Class
End Namespace