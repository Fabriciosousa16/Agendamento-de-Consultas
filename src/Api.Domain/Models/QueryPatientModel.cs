using System;

namespace Api.Domain.Models
{
    public class QueryPatientModel
    {
        private int _idQueryPartient;
        public int IdQueryPartient
        {
            get { return _idQueryPartient; }
            set { _idQueryPartient = value; }
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private DateTime _EedTime;
        public DateTime EndTime
        {
            get { return _EedTime; }
            set { _EedTime = value; }
        }

        private int _idStatus;
        public int IdStatus
        {
            get { return _idStatus; }
            set { _idStatus = value; }
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
