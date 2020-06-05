Imports System
Imports DevExpress.Xpo

Namespace ExplicitUnitOfWorkDemo
	Public Class Address
		Inherits XPBaseObject

'INSTANT VB NOTE: The field oid was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private oid_Conflict As Long
'INSTANT VB NOTE: The field zipCode was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private zipCode_Conflict As String
'INSTANT VB NOTE: The field country was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private country_Conflict As String
'INSTANT VB NOTE: The field province was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private province_Conflict As String
'INSTANT VB NOTE: The field city was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private city_Conflict As String
'INSTANT VB NOTE: The field address1 was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private address1_Conflict As String
'INSTANT VB NOTE: The field address2 was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private address2_Conflict As String
		<Key>
		Public Property Oid() As Long
			Get
				Return oid_Conflict
			End Get
			Set(ByVal value As Long)
				SetPropertyValue("Oid", oid_Conflict, value)
			End Set
		End Property
		Public Property Province() As String
			Get
				Return province_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Province", province_Conflict, value)
			End Set
		End Property
		Public Property ZipCode() As String
			Get
				Return zipCode_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("ZipCode", zipCode_Conflict, value)
			End Set
		End Property
		Public Property Country() As String
			Get
				Return country_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Country", country_Conflict, value)
			End Set
		End Property
		Public Property City() As String
			Get
				Return city_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("City", city_Conflict, value)
			End Set
		End Property
		Public Property Address1() As String
			Get
				Return address1_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Address1", address1_Conflict, value)
			End Set
		End Property
		Public Property Address2() As String
			Get
				Return address2_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Address2", address2_Conflict, value)
			End Set
		End Property
		<Association>
		Public ReadOnly Property Persons() As XPCollection(Of Person)
			Get
				Return GetCollection(Of Person)("Persons")
			End Get
		End Property
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class
	Public Class Person
		Inherits XPBaseObject

'INSTANT VB NOTE: The field oid was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private oid_Conflict As Long
'INSTANT VB NOTE: The field firstName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private firstName_Conflict As String
'INSTANT VB NOTE: The field lastName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private lastName_Conflict As String
'INSTANT VB NOTE: The field sex was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private sex_Conflict As PersonSex
'INSTANT VB NOTE: The field age was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private age_Conflict As Integer
'INSTANT VB NOTE: The field address was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private address_Conflict As Address
		<Key>
		Public Property Oid() As Long
			Get
				Return oid_Conflict
			End Get
			Set(ByVal value As Long)
				SetPropertyValue("Oid", oid_Conflict, value)
			End Set
		End Property
		Public Property FirstName() As String
			Get
				Return firstName_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("FirstName", firstName_Conflict, value)
			End Set
		End Property
		Public Property LastName() As String
			Get
				Return lastName_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("LastName", lastName_Conflict, value)
			End Set
		End Property
		Public Property Age() As Integer
			Get
				Return age_Conflict
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Age", age_Conflict, value)
			End Set
		End Property
		Public Property Sex() As PersonSex
			Get
				Return sex_Conflict
			End Get
			Set(ByVal value As PersonSex)
				SetPropertyValue("Sex", sex_Conflict, value)
			End Set
		End Property
		<Association>
		Public Property Address() As Address
			Get
				Return address_Conflict
			End Get
			Set(ByVal value As Address)
				SetPropertyValue("Address", address_Conflict, value)
			End Set
		End Property
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class

	Public Enum PersonSex
		Male
		Female
	End Enum
End Namespace
