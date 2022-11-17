Imports DevExpress.Xpo

Namespace ExplicitUnitOfWorkDemo

    Public Class Address
        Inherits XPBaseObject

        Private oidField As Long

        Private zipCodeField As String

        Private countryField As String

        Private provinceField As String

        Private cityField As String

        Private address1Field As String

        Private address2Field As String

        <Key>
        Public Property Oid As Long
            Get
                Return oidField
            End Get

            Set(ByVal value As Long)
                SetPropertyValue("Oid", oidField, value)
            End Set
        End Property

        Public Property Province As String
            Get
                Return provinceField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Province", provinceField, value)
            End Set
        End Property

        Public Property ZipCode As String
            Get
                Return zipCodeField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("ZipCode", zipCodeField, value)
            End Set
        End Property

        Public Property Country As String
            Get
                Return countryField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Country", countryField, value)
            End Set
        End Property

        Public Property City As String
            Get
                Return cityField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("City", cityField, value)
            End Set
        End Property

        Public Property Address1 As String
            Get
                Return address1Field
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Address1", address1Field, value)
            End Set
        End Property

        Public Property Address2 As String
            Get
                Return address2Field
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Address2", address2Field, value)
            End Set
        End Property

        <Association>
        Public ReadOnly Property Persons As XPCollection(Of Person)
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

        Private oidField As Long

        Private firstNameField As String

        Private lastNameField As String

        Private sexField As PersonSex

        Private ageField As Integer

        Private addressField As Address

        <Key>
        Public Property Oid As Long
            Get
                Return oidField
            End Get

            Set(ByVal value As Long)
                SetPropertyValue("Oid", oidField, value)
            End Set
        End Property

        Public Property FirstName As String
            Get
                Return firstNameField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("FirstName", firstNameField, value)
            End Set
        End Property

        Public Property LastName As String
            Get
                Return lastNameField
            End Get

            Set(ByVal value As String)
                SetPropertyValue("LastName", lastNameField, value)
            End Set
        End Property

        Public Property Age As Integer
            Get
                Return ageField
            End Get

            Set(ByVal value As Integer)
                SetPropertyValue("Age", ageField, value)
            End Set
        End Property

        Public Property Sex As PersonSex
            Get
                Return sexField
            End Get

            Set(ByVal value As PersonSex)
                SetPropertyValue("Sex", sexField, value)
            End Set
        End Property

        <Association>
        Public Property Address As Address
            Get
                Return addressField
            End Get

            Set(ByVal value As Address)
                SetPropertyValue("Address", addressField, value)
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
