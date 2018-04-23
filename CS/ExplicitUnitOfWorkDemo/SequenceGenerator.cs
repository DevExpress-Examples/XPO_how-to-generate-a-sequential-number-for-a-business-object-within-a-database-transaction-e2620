using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.DB.Exceptions;

namespace ExplicitUnitOfWorkDemo {
    //This class is used to generate sequential numbers for persistent objects.
    //Use the GetNextId method to get the next number and the Accept method, to save these changes to the database.
    public class SequenceGenerator<T> : IDisposable {
        private ExplicitUnitOfWork euow;
        private XPClassInfo classInfo;
        private Sequence seq;
        public SequenceGenerator(IDataLayer dataLayer) {
            euow = new ExplicitUnitOfWork(dataLayer);
            classInfo = euow.GetClassInfo<T>();
        }
        public void Accept(){
            euow.CommitChanges();
        }
        public long GetNextId() {
            long nextId;
            while(true) {
                try {
                    if(seq == null) {
                        seq = euow.GetObjectByKey<Sequence>(classInfo.FullName, true);
                        if(seq == null) {
                            seq = new Sequence(euow);
                            seq.TypeName = classInfo.FullName;
                            seq.NextId = 0;
                        }
                    }
                    nextId = seq.NextId;
                    seq.NextId++;
                    euow.FlushChanges();
                } catch(LockingException) {
                    seq = null;
                    continue;
                }
                break;
            }
            return nextId;
        }
        public void Close() {
            if(euow != null)
                euow.Dispose();
        }
        void IDisposable.Dispose() {
            Close();
        }
    }
    //This persistent class is used to store last sequential number for persistent objects.
    public class Sequence : XPBaseObject {
        private string typeName;
        private long nextId;
        public Sequence(Session session)
            : base(session) {
        }
        [Key]
        public string TypeName {
            get { return typeName; }
            set { SetPropertyValue("TypeName", ref typeName, value); }
        }
        public long NextId {
            get { return nextId; }
            set { SetPropertyValue("NextId", ref nextId, value); }
        }
    }
}
