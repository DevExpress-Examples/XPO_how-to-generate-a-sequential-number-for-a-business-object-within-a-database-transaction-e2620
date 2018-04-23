using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace ExplicitUnitOfWorkDemo {
    public partial class frmMain : XtraForm {
        public frmMain() {
            InitializeComponent();
        }
        private void btnRecreateAddress_Click(object sender, EventArgs e) {
            ViewRecord row = gridView1.GetFocusedRow() as ViewRecord;
            if(row == null) return;
            long personOid = RecreateAddress(row);
            UpdateRows();
            gridView1.SetFocusedRowCellValue(colOid, personOid);
        }
        private static long RecreateAddress(ViewRecord selectedRow) {
            long personOid;
            using (ExplicitUnitOfWork explicitUnitOfWork = new ExplicitUnitOfWork(DatabaseHelper.DataLayer)) {
                //Get selected person object.
                Person person = explicitUnitOfWork.GetObjectByKey<Person>(selectedRow["Oid"]);
                if(person == null || person.Address == null) 
                    throw new ArgumentNullException("person");
                //Remember person key value.
                personOid = person.Oid;
                Address address = person.Address;
                long addressOid = address.Oid;
                List<Person> referenceList = new List<Person>(address.Persons);
                //Reset references to the Address object.
                for (int i = 0; i < referenceList.Count; i++) {
                    referenceList[i].Address = null;
                }
                //Delete the Address object.
                explicitUnitOfWork.Delete(address);
                //Save changes to the database in case of an explicit transaction.
                explicitUnitOfWork.FlushChanges();

                //Create a new instance of the Address object.
                address = DatabaseHelper.CreateNewAddress(explicitUnitOfWork, addressOid);
                //Recover references to the Address object.
                for (int i = 0; i < referenceList.Count; i++) {
                    referenceList[i].Address = address;
                }
                explicitUnitOfWork.CommitChanges();
            }
            return personOid;
        }
        private void btnCreatePerson_Click(object sender, EventArgs e) {
            CreatePerson();
            UpdateRows();
        }
        private static void CreatePerson() {
            long personOid;
            using (UnitOfWork uow = new UnitOfWork(DatabaseHelper.SequenceDataLayer)) {
                Address address;
                using (SequenceGenerator<Address> sg = new SequenceGenerator<Address>(DatabaseHelper.SequenceDataLayer)) {
                    address = DatabaseHelper.CreateNewAddress(uow, sg.GetNextId());
                    uow.CommitChanges();
                    sg.Accept();
                }
                using (SequenceGenerator<Person> sg = new SequenceGenerator<Person>(DatabaseHelper.SequenceDataLayer)) {
                    Person person = DatabaseHelper.CreateNewPerson(uow, sg.GetNextId());
                    personOid = person.Oid;
                    person.Address = address;
                    uow.CommitChanges();
                    sg.Accept();
                }
            }
        }
        private void btnCreatePersons_Click(object sender, EventArgs e) {
            CreatePersons();
            UpdateRows();
        }
        private static void CreatePersons() {
            using (UnitOfWork uow = new UnitOfWork(DatabaseHelper.SequenceDataLayer)) {
                List<Address> addressList = new List<Address>();
                using (SequenceGenerator<Address> sg = new SequenceGenerator<Address>(DatabaseHelper.SequenceDataLayer)) {
                    for (int i = 0; i < 10; i++) {
                        Address address = DatabaseHelper.CreateNewAddress(uow, sg.GetNextId());
                        addressList.Add(address);
                    }
                    uow.CommitChanges();
                    sg.Accept();
                }
                using (SequenceGenerator<Person> sg = new SequenceGenerator<Person>(DatabaseHelper.SequenceDataLayer)) {
                    for (int i = 0; i < 10; i++) {
                        for (int k = 0; k < 10; k++) {
                            Person person = DatabaseHelper.CreateNewPerson(uow, sg.GetNextId());
                            person.Address = addressList[i];
                        }
                    }
                    uow.CommitChanges();
                    sg.Accept();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            UpdateRows();
        }
        private void UpdateRows() {
            xpView1.TopReturnedRecords = (int)spinEdit1.Value;
            xpView1.Reload();
        }
        private void btnClearDB_Click(object sender, EventArgs e) {
            ClearDatabase();
            UpdateRows();
        }
        private static void ClearDatabase() {
            using (UnitOfWork uow = new UnitOfWork(DatabaseHelper.DataLayer)) {
                XPCollection<Person> personList = new XPCollection<Person>(uow);
                XPCollection<Address> addressList = new XPCollection<Address>(uow);
                XPCollection<Sequence> sequencList = new XPCollection<Sequence>(uow);
                uow.Delete(personList);
                uow.Delete(addressList);
                uow.Delete(sequencList);
                uow.CommitChanges();
            }
        }
    }
}