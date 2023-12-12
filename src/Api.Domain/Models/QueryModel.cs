using System;

namespace Api.Domain.Models
{
    public class QueryModel
    {

        private int _idQuery;
        public int IdQuery
        {
            get { return _idQuery; }
            set { _idQuery = value; }
        }

        private string _reason;
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        private string _medicalRecord;
        public string MedicalRecord
        {
            get { return _medicalRecord; }
            set { _medicalRecord = value; }
        }

        private int _idDoctor;
        public int IdDoctor
        {
            get { return _idDoctor; }
            set { _idDoctor = value; }
        }
        private int _idPatient;
        public int IdPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
