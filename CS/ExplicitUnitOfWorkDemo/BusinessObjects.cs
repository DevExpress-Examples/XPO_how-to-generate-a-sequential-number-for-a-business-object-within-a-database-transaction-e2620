using System;
using DevExpress.Xpo;

namespace ExplicitUnitOfWorkDemo {
    public class Address : XPBaseObject {
        long oid;
        string zipCode;
        string country;
        string province;
        string city;
        string address1;
        string address2;
        [Key]
        public long Oid {
            get {
                return oid;
            }
            set {
                SetPropertyValue("Oid", ref oid, value);
            }
        }
        public string Province {
            get {
                return province;
            }
            set {
                SetPropertyValue("Province", ref province, value);
            }
        }
        public string ZipCode {
            get {
                return zipCode;
            }
            set {
                SetPropertyValue("ZipCode", ref zipCode, value);
            }
        }
        public string Country {
            get {
                return country;
            }
            set {
                SetPropertyValue("Country", ref country, value);
            }
        }
        public string City {
            get {
                return city;
            }
            set {
                SetPropertyValue("City", ref city, value);
            }
        }
        public string Address1 {
            get {
                return address1;
            }
            set {
                SetPropertyValue("Address1", ref address1, value);
            }
        }
        public string Address2 {
            get {
                return address2;
            }
            set {
                SetPropertyValue("Address2", ref address2, value);
            }
        }
        [Association]
        public XPCollection<Person> Persons {
            get {
                return GetCollection<Person>("Persons");
            }
        }
        public Address(Session session) : base(session) { }
    }
    public class Person: XPBaseObject {
        long oid;
        string firstName;
        string lastName;
        PersonSex sex;
        int age;
        Address address;
        [Key]
        public long Oid {
            get {
                return oid;
            }
            set {
                SetPropertyValue("Oid", ref oid, value);
            }
        }
        public string FirstName {
            get {
                return firstName;
            }
            set {
                SetPropertyValue("FirstName", ref firstName, value);
            }
        }
        public string LastName {
            get {
                return lastName;
            }
            set {
                SetPropertyValue("LastName", ref lastName, value);
            }
        }
        public int Age {
            get {
                return age;
            }
            set {
                SetPropertyValue("Age", ref age, value);
            }
        }
        public PersonSex Sex {
            get {
                return sex;
            }
            set {
                SetPropertyValue("Sex", ref sex, value);
            }
        }
        [Association]
        public Address Address {
            get {
                return address;
            }
            set {
                SetPropertyValue("Address", ref address, value);
            }
        }
        public Person(Session session) : base(session) { }
    }

    public enum PersonSex {
        Male,
        Female
    }
}
