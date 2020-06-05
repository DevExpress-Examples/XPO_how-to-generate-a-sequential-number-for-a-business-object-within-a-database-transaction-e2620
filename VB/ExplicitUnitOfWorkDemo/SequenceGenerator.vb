Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Xpo.DB.Exceptions

Namespace ExplicitUnitOfWorkDemo
	'This class is used to generate sequential numbers for persistent objects.
	'Use the GetNextId method to get the next number and the Accept method, to save these changes to the database.
	Public Class SequenceGenerator(Of T)
		Implements IDisposable

		Private euow As ExplicitUnitOfWork
		Private classInfo As XPClassInfo
		Private seq As Sequence
		Public Sub New(ByVal dataLayer As IDataLayer)
			euow = New ExplicitUnitOfWork(dataLayer)
			classInfo = euow.GetClassInfo(Of T)()
		End Sub
		Public Sub Accept()
			euow.CommitChanges()
		End Sub
		Public Function GetNextId() As Long
			Dim nextId As Long
			Do
				Try
					If seq Is Nothing Then
						seq = euow.GetObjectByKey(Of Sequence)(classInfo.FullName, True)
						If seq Is Nothing Then
							seq = New Sequence(euow)
							seq.TypeName = classInfo.FullName
							seq.NextId = 0
						End If
					End If
					nextId = seq.NextId
					seq.NextId += 1
					euow.FlushChanges()
				Catch e1 As LockingException
					seq = Nothing
					Continue Do
				End Try
				Exit Do
			Loop
			Return nextId
		End Function
		Public Sub Close()
			If euow IsNot Nothing Then
				euow.Dispose()
			End If
		End Sub
		Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
			Close()
		End Sub
	End Class
	'This persistent class is used to store last sequential number for persistent objects.
	Public Class Sequence
		Inherits XPBaseObject

'INSTANT VB NOTE: The field typeName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private typeName_Conflict As String
'INSTANT VB NOTE: The field nextId was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private nextId_Conflict As Long
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Key>
		Public Property TypeName() As String
			Get
				Return typeName_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("TypeName", typeName_Conflict, value)
			End Set
		End Property
		Public Property NextId() As Long
			Get
				Return nextId_Conflict
			End Get
			Set(ByVal value As Long)
				SetPropertyValue("NextId", nextId_Conflict, value)
			End Set
		End Property
	End Class
End Namespace
