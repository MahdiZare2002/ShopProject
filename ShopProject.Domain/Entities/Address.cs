using ShopProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int CustomerId { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string CompleteAddress { get; private set; }
        public int NoNumber { get; private set; }
        public bool IsActive { get; private set; }
        private Address() { }
        public Address(int customerId , string state, string city , string completeAddress, int noNumber)
        {
            CustomerId = customerId;
            State = state;
            City = city;
            CompleteAddress = completeAddress;
            NoNumber = noNumber;
        }

        public void Edit(string state, string city, string completeAddress, int noNumber)
        {
            State = state;
            City = city;
            CompleteAddress = completeAddress;
            NoNumber = noNumber;
        }

        public void ChangeActivity()
        {
            IsActive = !IsActive;
        }
    }
}
