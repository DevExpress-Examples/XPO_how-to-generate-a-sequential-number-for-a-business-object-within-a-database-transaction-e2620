Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace ExplicitUnitOfWorkDemo
	Friend NotInheritable Class DatabaseHelper
		Private Shared maleNames() As String = { "Denzel", "Stratford", "Leanian", "Patwin", "Renaldo", "Welford", "Maher", "Gregorio", "Roth", "Gawain", "Fiacre", "Coillcumhann", "Honi", "Westcot", "Walden", "Onfroi", "Merlow", "Atol", "Gimm", "Dumont", "Weorth", "Corcoran", "Sinley", "Perekin", "Galt" }
		Private Shared femaleNames() As String = { "Tequiefah", "Zina", "Hemi Skye", "Chiziana", "Adelie", "Afric", "Laquinta", "Molli", "Cimberleigh", "Morissa", "Alastriona", "Ailisa", "Leontina", "Aruba", "Marilda", "Ascencion", "Lidoine", "Winema", "Eraman", "Karline", "Edwinna", "Yseult", "Florencia", "Bethsaida", "Aminah" }

		Private Shared lastNames() As String = { "SMITH", "JOHNSON", "WILLIAMS", "JONES", "BROWN", "DAVIS", "MILLER", "WILSON", "MOORE", "TAYLOR", "ANDERSON", "THOMAS", "JACKSON", "WHITE", "HARRIS", "MARTIN", "THOMPSON", "GARCIA", "MARTINEZ", "ROBINSON", "CLARK", "RODRIGUEZ", "LEWIS", "LEE", "WALKER", "HALL", "ALLEN", "YOUNG", "HERNANDEZ", "KING", "WRIGHT", "LOPEZ", "HILL", "SCOTT", "GREEN", "ADAMS", "BAKER", "GONZALEZ", "NELSON", "CARTER", "MITCHELL", "PEREZ", "ROBERTS", "TURNER", "PHILLIPS", "CAMPBELL", "PARKER", "EVANS", "EDWARDS", "COLLINS", "STEWART", "SANCHEZ", "MORRIS", "ROGERS", "REED", "COOK", "MORGAN", "BELL", "MURPHY", "BAILEY", "RIVERA", "COOPER", "RICHARDSON", "COX", "HOWARD", "WARD", "TORRES", "PETERSON", "GRAY", "RAMIREZ", "JAMES", "WATSON", "BROOKS", "KELLY", "SANDERS", "PRICE", "BENNETT", "WOOD", "BARNES", "ROSS", "HENDERSON", "COLEMAN", "JENKINS", "PERRY", "POWELL", "LONG", "PATTERSON", "HUGHES", "FLORES", "WASHINGTON", "BUTLER", "SIMMONS", "FOSTER", "GONZALES", "BRYANT", "ALEXANDER", "RUSSELL", "GRIFFIN", "DIAZ", "HAYES", "MYERS", "FORD", "HAMILTON", "GRAHAM", "SULLIVAN", "WALLACE", "WOODS", "COLE", "WEST", "JORDAN", "OWENS", "REYNOLDS", "FISHER", "ELLIS", "HARRISON" }

		Private Shared cityList() As String = { "New York,New York", "Los Angeles,California", "Chicago,Illinois", "Houston,Texas", "Phoenix,Arizona", "Philadelphia,Pennsylvania", "San Antonio,Texas", "San Diego,California", "Dallas,Texas", "San Jose,California", "Detroit,Michigan", "San Francisco,California", "Jacksonville,Florida", "Indianapolis,Indiana", "Austin,Texas", "Columbus,Ohio", "Fort Worth,Texas", "Charlotte,North Carolina", "Memphis,Tennessee", "Boston,Massachusetts", "Baltimore,Maryland", "El Paso,Texas", "Seattle,Washington", "Denver,Colorado", "Nashville,Tennessee", "Milwaukee,Wisconsin", "Washington,District of Columbia", "Las Vegas,Nevada", "Louisville,Kentucky", "Portland,Oregon", "Oklahoma City,Oklahoma", "Tucson,Arizona", "Atlanta,Georgia", "Albuquerque,New Mexico", "Kansas City,Missouri", "Fresno,California", "Sacramento,California", "Long Beach,California", "Mesa,Arizona", "Omaha,Nebraska", "Virginia Beach,Virginia", "Miami,Florida", "Cleveland,Ohio", "Oakland,California", "Raleigh,North Carolina", "Colorado Springs,Colorado", "Tulsa,Oklahoma", "Odessa,Texas", "Boulder,Colorado" }

		Private Shared currentPersonMaleName As Integer = 0
		Private Shared currentPersonFemaleName As Integer = 0
		Private Shared currentPersonSex As PersonSex = PersonSex.Male
		Private Sub New()
		End Sub
		Private Shared Function GetNextName(<System.Runtime.InteropServices.Out()> ByRef sex As PersonSex) As String
			If currentPersonSex = PersonSex.Male Then
				sex = PersonSex.Male
				currentPersonSex = PersonSex.Female
				If currentPersonMaleName >= maleNames.Length Then
					currentPersonMaleName = 0
				End If
				Return maleNames(currentPersonMaleName)
				currentPersonMaleName += 1
			End If
			sex = PersonSex.Female
			currentPersonSex = PersonSex.Male
			If currentPersonFemaleName >= femaleNames.Length Then
				currentPersonFemaleName = 0
			End If
			Return femaleNames(currentPersonFemaleName)
			currentPersonFemaleName += 1
		End Function

		Private Shared currentPersonLastName As Integer = 0
		Private Shared Function GetNextLastName() As String
			If currentPersonLastName >= lastNames.Length Then
				currentPersonLastName = 0
			End If
			Return lastNames(currentPersonLastName)
			currentPersonLastName += 1
		End Function

		Private Shared currentAddressCity As Integer = 0
		Private Shared Function GetNextCity(<System.Runtime.InteropServices.Out()> ByRef province As String) As String
			If currentAddressCity >= cityList.Length Then
				currentAddressCity = 0
			End If
			Dim clItem() As String = cityList(currentAddressCity).Split(","c)
			currentAddressCity += 1
			province = clItem(1)
			Return clItem(0)
		End Function

		Private Shared randomize_Renamed As Random
		Private Shared ReadOnly Property Randomize() As Random
			Get
				If randomize_Renamed Is Nothing Then
					randomize_Renamed = New Random()
				End If
				Return randomize_Renamed
			End Get
		End Property

		Public Shared Function CreateNewPerson(ByVal uow As UnitOfWork, ByVal oid As Long) As Person
			Dim person As New Person(uow)
			person.Oid = oid
			Dim sex As PersonSex
			person.FirstName = GetNextName(sex)
			person.Sex = sex
			person.LastName = GetNextLastName()
			person.Age = Randomize.Next(70)
			Return person
		End Function

		Public Shared Function CreateNewAddress(ByVal uow As UnitOfWork, ByVal oid As Long) As Address
			Dim address As New Address(uow)
			address.Oid = oid
			address.Country = "USA"
			Dim province As String
			address.City = GetNextCity(province)
			address.Province = province
			address.Address1 = "Street" & oid.ToString()
			address.Address2 = oid.ToString()
			Return address
		End Function

		Private Shared dataLayer_Renamed As IDataLayer
		Public Shared Property DataLayer() As IDataLayer
			Get
				Return dataLayer_Renamed
			End Get
			Set(ByVal value As IDataLayer)
				dataLayer_Renamed = value
			End Set
		End Property
		Private Shared sequenceDataLayer_Renamed As IDataLayer
		Public Shared Property SequenceDataLayer() As IDataLayer
			Get
				Return sequenceDataLayer_Renamed
			End Get
			Set(ByVal value As IDataLayer)
				sequenceDataLayer_Renamed = value
			End Set
		End Property
	End Class
End Namespace
