using System;
using System.ComponentModel.DataAnnotations;

namespace ApiLibrary
{
    public class Subscriber
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }

        public Subscriber(string firstName, string lastName, string email, string mobile)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Tried to create a type Subscriber with an invalid property", "firstName");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Tried to create a type Subscriber with an invalid property", "lastName");

            if (!(new EmailAddressAttribute().IsValid(email)))
                throw new ArgumentException("Tried to create a type Subscriber with an invalid property", "email");

            if (string.IsNullOrWhiteSpace(mobile))
                throw new ArgumentException("Tried to create a type Subscriber with an invalid property", "mobile");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Mobile = mobile;
        }
    }
}
