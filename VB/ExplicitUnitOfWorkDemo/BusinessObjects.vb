Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace ExplicitUnitOfWorkDemo
	Public Class Address
		Inherits XPBaseObject
		Private oid_Renamed As Long
		Private zipCode_Renamed As String
		Private country_Renamed As String
		Private province_Renamed As String
		Private city_Renamed As String
		Private address1_Renamed As String
		Private address2_Renamed As String
		<Key> _
		Public Property Oid() As Long
			Get
				Return oid_Renamed
			End Get
			Set(ByVal value As Long)
				SetPropertyValue("Oid", oid_Renamed, value)
			End Set
		End Property
		Public Property Province() As String
			Get
				Return province_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Province", province_Renamed, value)
			End Set
		End Property
		Public Property ZipCode() As String
			Get
				Return zipCode_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("ZipCode", zipCode_Renamed, value)
			End Set
		End Property
		Public Property Country() As String
			Get
				Return country_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Country", country_Renamed, value)
			End Set
		End Property
		Public Property City() As String
			Get
				Return city_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("City", city_Renamed, value)
			End Set
		End Property
		Public Property Address1() As String
			Get
				Return address1_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Address1", address1_Renamed, value)
			End Set
		End Property
		Public Property Address2() As String
			Get
				Return address2_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Address2", address2_Renamed, value)
			End Set
		End Property
		<Association> _
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
		Private oid_Renamed As Long
		Private firstName_Renamed As String
		Private lastName_Renamed As String
		Private sex_Renamed As PersonSex
		Private age_Renamed As Integer
		Private address_Renamed As Address
		<Key> _
		Public Property Oid() As Long
			Get
				Return oid_Renamed
			End Get
			Set(ByVal value As Long)
				SetPropertyValue("Oid", oid_Renamed, value)
			End Set
		End Property
		Public Property FirstName() As String
			Get
				Return firstName_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("FirstName", firstName_Renamed, value)
			End Set
		End Property
		Public Property LastName() As String
			Get
				Return lastName_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("LastName", lastName_Renamed, value)
			End Set
		End Property
		Public Property Age() As Integer
			Get
				Return age_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Age", age_Renamed, value)
			End Set
		End Property
		Public Property Sex() As PersonSex
			Get
				Return sex_Renamed
			End Get
			Set(ByVal value As PersonSex)
				SetPropertyValue("Sex", sex_Renamed, value)
			End Set
		End Property
		<Association> _
		Public Property Address() As Address
			Get
				Return address_Renamed
			End Get
			Set(ByVal value As Address)
				SetPropertyValue("Address", address_Renamed, value)
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
