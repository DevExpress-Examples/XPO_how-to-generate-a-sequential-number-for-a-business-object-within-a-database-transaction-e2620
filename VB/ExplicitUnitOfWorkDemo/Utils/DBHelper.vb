Imports System
Imports DevExpress.Xpo
Imports System.Runtime.InteropServices

Namespace ExplicitUnitOfWorkDemo

    Friend Module DatabaseHelper

        Private maleNames As String() = New String() {"Denzel", "Stratford", "Leanian", "Patwin", "Renaldo", "Welford", "Maher", "Gregorio", "Roth", "Gawain", "Fiacre", "Coillcumhann", "Honi", "Westcot", "Walden", "Onfroi", "Merlow", "Atol", "Gimm", "Dumont", "Weorth", "Corcoran", "Sinley", "Perekin", "Galt"}

        Private femaleNames As String() = New String() {"Tequiefah", "Zina", "Hemi Skye", "Chiziana", "Adelie", "Afric", "Laquinta", "Molli", "Cimberleigh", "Morissa", "Alastriona", "Ailisa", "Leontina", "Aruba", "Marilda", "Ascencion", "Lidoine", "Winema", "Eraman", "Karline", "Edwinna", "Yseult", "Florencia", "Bethsaida", "Aminah"}

        Private lastNames As String() = New String() {"SMITH", "JOHNSON", "WILLIAMS", "JONES", "BROWN", "DAVIS", "MILLER", "WILSON", "MOORE", "TAYLOR", "ANDERSON", "THOMAS", "JACKSON", "WHITE", "HARRIS", "MARTIN", "THOMPSON", "GARCIA", "MARTINEZ", "ROBINSON", "CLARK", "RODRIGUEZ", "LEWIS", "LEE", "WALKER", "HALL", "ALLEN", "YOUNG", "HERNANDEZ", "KING", "WRIGHT", "LOPEZ", "HILL", "SCOTT", "GREEN", "ADAMS", "BAKER", "GONZALEZ", "NELSON", "CARTER", "MITCHELL", "PEREZ", "ROBERTS", "TURNER", "PHILLIPS", "CAMPBELL", "PARKER", "EVANS", "EDWARDS", "COLLINS", "STEWART", "SANCHEZ", "MORRIS", "ROGERS", "REED", "COOK", "MORGAN", "BELL", "MURPHY", "BAILEY", "RIVERA", "COOPER", "RICHARDSON", "COX", "HOWARD", "WARD", "TORRES", "PETERSON", "GRAY", "RAMIREZ", "JAMES", "WATSON", "BROOKS", "KELLY", "SANDERS", "PRICE", "BENNETT", "WOOD", "BARNES", "ROSS", "HENDERSON", "COLEMAN", "JENKINS", "PERRY", "POWELL", "LONG", "PATTERSON", "HUGHES", "FLORES", "WASHINGTON", "BUTLER", "SIMMONS", "FOSTER", "GONZALES", "BRYANT", "ALEXANDER", "RUSSELL", "GRIFFIN", "DIAZ", "HAYES", "MYERS", "FORD", "HAMILTON", "GRAHAM", "SULLIVAN", "WALLACE", "WOODS", "COLE", "WEST", "JORDAN", "OWENS", "REYNOLDS", "FISHER", "ELLIS", "HARRISON"}

        Private cityList As String() = New String() {"New York,New York", "Los Angeles,California", "Chicago,Illinois", "Houston,Texas", "Phoenix,Arizona", "Philadelphia,Pennsylvania", "San Antonio,Texas", "San Diego,California", "Dallas,Texas", "San Jose,California", "Detroit,Michigan", "San Francisco,California", "Jacksonville,Florida", "Indianapolis,Indiana", "Austin,Texas", "Columbus,Ohio", "Fort Worth,Texas", "Charlotte,North Carolina", "Memphis,Tennessee", "Boston,Massachusetts", "Baltimore,Maryland", "El Paso,Texas", "Seattle,Washington", "Denver,Colorado", "Nashville,Tennessee", "Milwaukee,Wisconsin", "Washington,District of Columbia", "Las Vegas,Nevada", "Louisville,Kentucky", "Portland,Oregon", "Oklahoma City,Oklahoma", "Tucson,Arizona", "Atlanta,Georgia", "Albuquerque,New Mexico", "Kansas City,Missouri", "Fresno,California", "Sacramento,California", "Long Beach,California", "Mesa,Arizona", "Omaha,Nebraska", "Virginia Beach,Virginia", "Miami,Florida", "Cleveland,Ohio", "Oakland,California", "Raleigh,North Carolina", "Colorado Springs,Colorado", "Tulsa,Oklahoma", "Odessa,Texas", "Boulder,Colorado"}

        Private currentPersonMaleName As Integer = 0

        Private currentPersonFemaleName As Integer = 0

        Private currentPersonSex As PersonSex = PersonSex.Male

        Private Function GetNextName(<Out> ByRef sex As PersonSex) As String
            If currentPersonSex = PersonSex.Male Then
                sex = PersonSex.Male
                currentPersonSex = PersonSex.Female
                If currentPersonMaleName >= maleNames.Length Then currentPersonMaleName = 0
                Return maleNames(Math.Min(Threading.Interlocked.Increment(currentPersonMaleName), currentPersonMaleName - 1))
            End If

            sex = PersonSex.Female
            currentPersonSex = PersonSex.Male
            If currentPersonFemaleName >= femaleNames.Length Then currentPersonFemaleName = 0
            Return femaleNames(Math.Min(Threading.Interlocked.Increment(currentPersonFemaleName), currentPersonFemaleName - 1))
        End Function

        Private currentPersonLastName As Integer = 0

        Private Function GetNextLastName() As String
            If currentPersonLastName >= lastNames.Length Then currentPersonLastName = 0
            Return lastNames(Math.Min(Threading.Interlocked.Increment(currentPersonLastName), currentPersonLastName - 1))
        End Function

        Private currentAddressCity As Integer = 0

        Private Function GetNextCity(<Out> ByRef province As String) As String
            If currentAddressCity >= cityList.Length Then currentAddressCity = 0
            Dim clItem As String() = cityList(Math.Min(Threading.Interlocked.Increment(currentAddressCity), currentAddressCity - 1)).Split(","c)
            province = clItem(1)
            Return clItem(0)
        End Function

        Private randomizeField As Random

        Private ReadOnly Property Randomize As Random
            Get
                If randomizeField Is Nothing Then randomizeField = New Random()
                Return randomizeField
            End Get
        End Property

        Public Function CreateNewPerson(ByVal uow As UnitOfWork, ByVal oid As Long) As Person
            Dim person As Person = New Person(uow)
            person.Oid = oid
            Dim sex As PersonSex
            person.FirstName = GetNextName(sex)
            person.Sex = sex
            person.LastName = GetNextLastName()
            person.Age = Randomize.Next(70)
            Return person
        End Function

        Public Function CreateNewAddress(ByVal uow As UnitOfWork, ByVal oid As Long) As Address
            Dim address As Address = New Address(uow)
            address.Oid = oid
            address.Country = "USA"
            Dim province As String
            address.City = GetNextCity(province)
            address.Province = province
            address.Address1 = "Street" & oid.ToString()
            address.Address2 = oid.ToString()
            Return address
        End Function

        Private dataLayerField As IDataLayer

        Public Property DataLayer As IDataLayer
            Get
                Return dataLayerField
            End Get

            Set(ByVal value As IDataLayer)
                dataLayerField = value
            End Set
        End Property

        Private sequenceDataLayerField As IDataLayer

        Public Property SequenceDataLayer As IDataLayer
            Get
                Return sequenceDataLayerField
            End Get

            Set(ByVal value As IDataLayer)
                sequenceDataLayerField = value
            End Set
        End Property
    End Module
End Namespace
