using System;
using DevExpress.Xpo;

namespace ExplicitUnitOfWorkDemo {
    static class DatabaseHelper {
        static string[] maleNames = new string[] { "Denzel", "Stratford", "Leanian", "Patwin", "Renaldo", "Welford", "Maher", "Gregorio", "Roth",
            "Gawain", "Fiacre", "Coillcumhann", "Honi", "Westcot", "Walden", "Onfroi", "Merlow", "Atol", "Gimm", "Dumont", "Weorth", 
            "Corcoran", "Sinley", "Perekin", "Galt" };
        static string[] femaleNames = new string[] { "Tequiefah", "Zina", "Hemi Skye", "Chiziana", "Adelie", "Afric", "Laquinta", "Molli", "Cimberleigh",
            "Morissa", "Alastriona", "Ailisa", "Leontina", "Aruba", "Marilda", "Ascencion", "Lidoine", "Winema", "Eraman", "Karline", "Edwinna",
            "Yseult", "Florencia", "Bethsaida", "Aminah" };

        static string[] lastNames = new string[] { "SMITH", "JOHNSON", "WILLIAMS", "JONES", "BROWN", "DAVIS", "MILLER", "WILSON", "MOORE", "TAYLOR",
            "ANDERSON", "THOMAS", "JACKSON", "WHITE", "HARRIS", "MARTIN", "THOMPSON", "GARCIA", "MARTINEZ", "ROBINSON", "CLARK", "RODRIGUEZ",
            "LEWIS", "LEE", "WALKER", "HALL", "ALLEN", "YOUNG", "HERNANDEZ", "KING", "WRIGHT", "LOPEZ", "HILL", "SCOTT", "GREEN", "ADAMS", "BAKER",
            "GONZALEZ", "NELSON", "CARTER", "MITCHELL", "PEREZ", "ROBERTS", "TURNER", "PHILLIPS", "CAMPBELL", "PARKER", "EVANS", "EDWARDS", "COLLINS",
            "STEWART", "SANCHEZ", "MORRIS", "ROGERS", "REED", "COOK", "MORGAN", "BELL", "MURPHY", "BAILEY", "RIVERA", "COOPER", "RICHARDSON", "COX", "HOWARD",
            "WARD", "TORRES", "PETERSON", "GRAY", "RAMIREZ", "JAMES", "WATSON", "BROOKS", "KELLY", "SANDERS", "PRICE", "BENNETT", "WOOD", "BARNES", "ROSS", "HENDERSON",
            "COLEMAN", "JENKINS", "PERRY", "POWELL", "LONG", "PATTERSON", "HUGHES", "FLORES", "WASHINGTON", "BUTLER", "SIMMONS", "FOSTER", "GONZALES", "BRYANT", "ALEXANDER",
            "RUSSELL", "GRIFFIN", "DIAZ", "HAYES", "MYERS", "FORD", "HAMILTON", "GRAHAM", "SULLIVAN", "WALLACE", "WOODS", "COLE", "WEST", "JORDAN", "OWENS", "REYNOLDS", "FISHER", "ELLIS", "HARRISON" };

        static string[] cityList = new string[] { "New York,New York", "Los Angeles,California", "Chicago,Illinois", "Houston,Texas", "Phoenix,Arizona", "Philadelphia,Pennsylvania", 
            "San Antonio,Texas", "San Diego,California", "Dallas,Texas", "San Jose,California", "Detroit,Michigan", "San Francisco,California", "Jacksonville,Florida",
            "Indianapolis,Indiana", "Austin,Texas", "Columbus,Ohio", "Fort Worth,Texas", "Charlotte,North Carolina", "Memphis,Tennessee", "Boston,Massachusetts", 
            "Baltimore,Maryland", "El Paso,Texas", "Seattle,Washington", "Denver,Colorado", "Nashville,Tennessee", "Milwaukee,Wisconsin", "Washington,District of Columbia",
            "Las Vegas,Nevada", "Louisville,Kentucky", "Portland,Oregon", "Oklahoma City,Oklahoma", "Tucson,Arizona", "Atlanta,Georgia", "Albuquerque,New Mexico", "Kansas City,Missouri",
            "Fresno,California", "Sacramento,California", "Long Beach,California", "Mesa,Arizona", "Omaha,Nebraska", "Virginia Beach,Virginia", "Miami,Florida", "Cleveland,Ohio", "Oakland,California",
            "Raleigh,North Carolina", "Colorado Springs,Colorado", "Tulsa,Oklahoma", "Odessa,Texas", "Boulder,Colorado" };

        static int currentPersonMaleName = 0;
        static int currentPersonFemaleName = 0;
        static PersonSex currentPersonSex = PersonSex.Male;
        static string GetNextName(out PersonSex sex) {
            if(currentPersonSex == PersonSex.Male) {
                sex = PersonSex.Male;
                currentPersonSex = PersonSex.Female;
                if(currentPersonMaleName >= maleNames.Length) currentPersonMaleName = 0;
                return maleNames[currentPersonMaleName++];
            }
            sex = PersonSex.Female;
            currentPersonSex = PersonSex.Male;
            if(currentPersonFemaleName >= femaleNames.Length) currentPersonFemaleName = 0;
            return femaleNames[currentPersonFemaleName++];
        }

        static int currentPersonLastName = 0;
        static string GetNextLastName() {
            if(currentPersonLastName >= lastNames.Length) currentPersonLastName = 0;
            return lastNames[currentPersonLastName++];
        }

        static int currentAddressCity = 0;
        static string GetNextCity(out string province) {
            if(currentAddressCity >= cityList.Length) currentAddressCity = 0;
            string[] clItem = cityList[currentAddressCity++].Split(',');
            province = clItem[1];
            return clItem[0];
        }

        static Random randomize;
        private static Random Randomize {
            get {
                if(randomize == null) randomize = new Random();
                return randomize;
            }
        }

        public static Person CreateNewPerson(UnitOfWork uow, long oid) {
            Person person = new Person(uow);
            person.Oid = oid;
            PersonSex sex;
            person.FirstName = GetNextName(out sex);
            person.Sex = sex;
            person.LastName = GetNextLastName();
            person.Age = Randomize.Next(70);
            return person;
        }

        public static Address CreateNewAddress(UnitOfWork uow, long oid) {
            Address address = new Address(uow);
            address.Oid = oid;
            address.Country = "USA";
            string province;
            address.City = GetNextCity(out province);
            address.Province = province;
            address.Address1 = "Street" + oid.ToString();
            address.Address2 = oid.ToString();
            return address;
        }

        static IDataLayer dataLayer;
        public static IDataLayer DataLayer {
            get {
                return dataLayer;
            }
            set {
                dataLayer = value;
            }
        }
        static IDataLayer sequenceDataLayer;
        public static IDataLayer SequenceDataLayer {
            get {
                return sequenceDataLayer;
            }
            set {
                sequenceDataLayer = value;
            }
        }
    }
}
