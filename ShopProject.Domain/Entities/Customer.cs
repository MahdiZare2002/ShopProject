using ShopProject.Domain.Common;

namespace ShopProject.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsBlocked { get; private set; }

        private Customer() { }
        public Customer(string userName, string email, string phoneNumber)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            IsActive = false;
            IsBlocked = false;
        }

        public void Edit(string userName, string email, string phoneNumber)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void ActiveCustomer()
        {
            IsActive = true;
        }

        public void DeactiveCustomer()
        {
            IsActive = false;
        }

        public void BlockCustomer()
        {
            IsBlocked = true;
        }
    }
}
