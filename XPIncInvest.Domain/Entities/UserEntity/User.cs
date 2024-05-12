using XPIncInvest.Domain.Entities.WalletEntity;
using XPIncInvest.Domain.Enums;
using XPIncInvest.Domain.Primitives;

namespace XPIncInvest.Domain.Entities.UserEntity
{
    public class User : Entity
    {
        protected User() { }

        public User(string name, string email, Role role)
        {
            Name = name;
            Email = email;
            Role = role;
            Wallet = new Wallet();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }

        public virtual Wallet Wallet { get; set; }

    }
}
