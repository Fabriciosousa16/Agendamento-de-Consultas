using System;

namespace Api.Domain.Models
{
    public class PatientModel
    {
        private int _idDoctor;
        public int IdDoctor
        {
            get { return _idDoctor; }
            set { _idDoctor = value; }
        }

        private string _medicalPlan;
        public string MedicalPlan
        {
            get { return _medicalPlan; }
            set { _medicalPlan = value; }
        }

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
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
