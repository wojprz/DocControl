using DocControl.Domain.Repositories;

namespace DocControl.Domain.Entities
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Login { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public int RoleId { get; protected set; }
        public int Status { get; protected set; }

        protected User () { }

        public User(string login, string email, string password, int roleId, IEncrypter encrypter)
        {
            Id = Guid.NewGuid();
            SetLogin(login);
            SetEmail(email);
            SetPassword(password, encrypter);
            SetRole(roleId);
            SetStatus(1);
        }

        public void SetStatus(int v)
        {
            if (v == 1 || v == 0) Status = v;
            else throw new Exception();
        }

        public void SetRole(int roleId)
        {
            if (roleId == 0 || roleId == 1 || roleId == 2 || roleId == 3) RoleId = roleId;
            else throw new Exception();
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new Exception();
            if (password.Length < 3) throw new Exception();
            if (password.Length >= 20) throw new Exception();
            if (password == Password) throw new Exception();

            string salt = encrypter.GetSalt(password);
            string hash = encrypter.GetHash(password, salt);

            Password = hash;
            Salt = salt;
        }
        public void SetEmail(string email)
        {
            if (email == Email) throw new Exception();
            Email = email;
        }

        public void SetLogin(string login)
        {
            if (login.Length < 3) throw new Exception();
            if (login.Length > 20) throw new Exception();
            if (String.IsNullOrEmpty(login)) throw new Exception();
            Login = login;
        }
        
        public string GetRoleName(int roleId)
        {
            if (roleId == 0) return "Użytkownik";
            if (roleId == 1) return "Księgowość";
            if (roleId == 2) return "Zarząd";
            if (roleId == 3) return "Administrator";
            else return "Złe id roli!";
        }

    }
}
