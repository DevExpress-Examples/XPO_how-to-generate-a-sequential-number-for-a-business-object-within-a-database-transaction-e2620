Imports System
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors
Imports System.Collections.Generic

Namespace ExplicitUnitOfWorkDemo

    Public Partial Class frmMain
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnRecreateAddress_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim row As ViewRecord = TryCast(gridView1.GetFocusedRow(), ViewRecord)
            If row Is Nothing Then Return
            Dim personOid As Long = RecreateAddress(row)
            UpdateRows()
            gridView1.SetFocusedRowCellValue(colOid, personOid)
        End Sub

        Private Shared Function RecreateAddress(ByVal selectedRow As ViewRecord) As Long
            Dim personOid As Long
            Using explicitUnitOfWork As ExplicitUnitOfWork = New ExplicitUnitOfWork(DataLayer)
                'Get selected person object.
                Dim person As Person = explicitUnitOfWork.GetObjectByKey(Of Person)(selectedRow("Oid"))
                If person Is Nothing OrElse person.Address Is Nothing Then Throw New ArgumentNullException("person")
                'Remember person key value.
                personOid = person.Oid
                Dim address As Address = person.Address
                Dim addressOid As Long = address.Oid
                Dim referenceList As List(Of Person) = New List(Of Person)(address.Persons)
                'Reset references to the Address object.
                For i As Integer = 0 To referenceList.Count - 1
                    referenceList(i).Address = Nothing
                Next

                'Delete the Address object.
                explicitUnitOfWork.Delete(address)
                'Save changes to the database in case of an explicit transaction.
                explicitUnitOfWork.FlushChanges()
                'Create a new instance of the Address object.
                address = CreateNewAddress(explicitUnitOfWork, addressOid)
                'Recover references to the Address object.
                For i As Integer = 0 To referenceList.Count - 1
                    referenceList(i).Address = address
                Next

                explicitUnitOfWork.CommitChanges()
            End Using

            Return personOid
        End Function

        Private Sub btnCreatePerson_Click(ByVal sender As Object, ByVal e As EventArgs)
            Call CreatePerson()
            UpdateRows()
        End Sub

        Private Shared Sub CreatePerson()
            Dim personOid As Long
            Using uow As UnitOfWork = New UnitOfWork(SequenceDataLayer)
                Dim address As Address
                Using sg As SequenceGenerator(Of Address) = New SequenceGenerator(Of Address)(SequenceDataLayer)
                    address = CreateNewAddress(uow, sg.GetNextId())
                    uow.CommitChanges()
                    sg.Accept()
                End Using

                Using sg As SequenceGenerator(Of Person) = New SequenceGenerator(Of Person)(SequenceDataLayer)
                    Dim person As Person = CreateNewPerson(uow, sg.GetNextId())
                    personOid = person.Oid
                    person.Address = address
                    uow.CommitChanges()
                    sg.Accept()
                End Using
            End Using
        End Sub

        Private Sub btnCreatePersons_Click(ByVal sender As Object, ByVal e As EventArgs)
            Call CreatePersons()
            UpdateRows()
        End Sub

        Private Shared Sub CreatePersons()
            Using uow As UnitOfWork = New UnitOfWork(SequenceDataLayer)
                Dim addressList As List(Of Address) = New List(Of Address)()
                Using sg As SequenceGenerator(Of Address) = New SequenceGenerator(Of Address)(SequenceDataLayer)
                    For i As Integer = 0 To 10 - 1
                        Dim address As Address = CreateNewAddress(uow, sg.GetNextId())
                        addressList.Add(address)
                    Next

                    uow.CommitChanges()
                    sg.Accept()
                End Using

                Using sg As SequenceGenerator(Of Person) = New SequenceGenerator(Of Person)(SequenceDataLayer)
                    For i As Integer = 0 To 10 - 1
                        For k As Integer = 0 To 10 - 1
                            Dim person As Person = CreateNewPerson(uow, sg.GetNextId())
                            person.Address = addressList(i)
                        Next
                    Next

                    uow.CommitChanges()
                    sg.Accept()
                End Using
            End Using
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
            UpdateRows()
        End Sub

        Private Sub UpdateRows()
            xpView1.TopReturnedRecords = CInt(spinEdit1.Value)
            xpView1.Reload()
        End Sub

        Private Sub btnClearDB_Click(ByVal sender As Object, ByVal e As EventArgs)
            Call ClearDatabase()
            UpdateRows()
        End Sub

        Private Shared Sub ClearDatabase()
            Using uow As UnitOfWork = New UnitOfWork(DataLayer)
                Dim personList As XPCollection(Of Person) = New XPCollection(Of Person)(uow)
                Dim addressList As XPCollection(Of Address) = New XPCollection(Of Address)(uow)
                Dim sequencList As XPCollection(Of Sequence) = New XPCollection(Of Sequence)(uow)
                uow.Delete(personList)
                uow.Delete(addressList)
                uow.Delete(sequencList)
                uow.CommitChanges()
            End Using
        End Sub
    End Class
End Namespace
