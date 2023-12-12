using System;

namespace Api.Domain.Models
{
    public class UserModel
    {
        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        private int _idProfile;
        public int IdProfile
        {
            get { return _idProfile; }
            set { _idProfile = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
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
